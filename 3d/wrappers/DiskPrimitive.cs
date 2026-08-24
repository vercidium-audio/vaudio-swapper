namespace vaudioswapper;

public class DiskPrimitive : Primitive
{
    public new vaudio.DiskPrimitive managed => base.managed as vaudio.DiskPrimitive;
    public new vaudionativewrapper.managed.DiskPrimitive native => base.native as vaudionativewrapper.managed.DiskPrimitive;

    public DiskPrimitive()
    {
        if (USE_NATIVE)
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
