// Human-created

namespace vaudioswapper;

public class CylinderPrimitive : Primitive
{
    public new vaudio.CylinderPrimitive managed => base.managed as vaudio.CylinderPrimitive;
    public new vaudionativewrapper.managed.CylinderPrimitive native => base.native as vaudionativewrapper.managed.CylinderPrimitive;

    public CylinderPrimitive() : this(USE_NATIVE) { }

    public CylinderPrimitive(bool useNative)
    {
        if (useNative)
            base.native = new vaudionativewrapper.managed.CylinderPrimitive();
        else
            base.managed = new vaudio.CylinderPrimitive();
    }

    public CylinderPrimitive(vaudionativewrapper.managed.CylinderPrimitive prim)
    {
        base.native = prim;
    }

    public CylinderPrimitive(vaudio.CylinderPrimitive prim)
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

    /// <summary>Radius of the cylinder</summary>
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

    /// <summary>Length of the cylinder body</summary>
    public float length
    {
        get => isManaged ? managed.length : native.length;
        set
        {
            if (isManaged)
                managed.length = value;
            else
                native.length = value;
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
