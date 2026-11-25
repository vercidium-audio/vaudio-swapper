// Human-created

namespace vaudioswapper;

public class DiskPrimitive : Primitive
{
    public new vaudio.DiskPrimitive managed => base.managed as vaudio.DiskPrimitive;
    public new vaudionativewrapper.managed.DiskPrimitive native => base.native as vaudionativewrapper.managed.DiskPrimitive;

    public DiskPrimitive() : this(USE_NATIVE) { }

    public DiskPrimitive(bool useNative)
    {
        if (useNative)
            base.native = new vaudionativewrapper.managed.DiskPrimitive();
        else
            base.managed = new vaudio.DiskPrimitive();
    }

    public DiskPrimitive(vaudionativewrapper.managed.DiskPrimitive prim)
    {
        base.native = prim;
    }

    public DiskPrimitive(vaudio.DiskPrimitive prim)
    {
        base.managed = prim;
    }

    /// <summary>Controls the amount of energy lost when rays bounce off this primitive and pass through it</summary>
    public vaudio.MaterialType material
    {
        get => isManaged ? managed.material : ToDotnet(native.material);
        set
        {
            if (isManaged)
                managed.material = value;
            else
                native.material = ToNative(value);
        }
    }

    /// <summary>Radius of the disk</summary>
    public float radius
    {
        get => isManaged ? managed.radius : native.radius;
        set
        {
            if (isManaged)
                managed.radius = value;
            else
                native.radius = value;
        }
    }

    /// <summary>Must only contain rotation and translation components, not scale</summary>
    public vaudio.Matrix transform
    {
        get => isManaged ? managed.transform : ToDotnet(native.transform);
        set
        {
            if (isManaged)
                managed.transform = value;
            else
                native.transform = ToNative(value);
        }
    }
}
