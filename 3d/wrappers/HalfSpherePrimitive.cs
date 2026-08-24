namespace vaudioswapper;

public class HalfSpherePrimitive : Primitive
{
    public new vaudio.HalfSpherePrimitive managed => base.managed as vaudio.HalfSpherePrimitive;
    public new vaudionativewrapper.managed.HalfSpherePrimitive native => base.native as vaudionativewrapper.managed.HalfSpherePrimitive;

    public HalfSpherePrimitive(bool isNative)
    {
        if (isNative)
            base.native = new vaudionativewrapper.managed.HalfSpherePrimitive();
        else
            base.managed = new vaudio.HalfSpherePrimitive();
    }

    public HalfSpherePrimitive(vaudionativewrapper.managed.HalfSpherePrimitive prim)
    {
        base.native = prim;
    }

    public HalfSpherePrimitive(vaudio.HalfSpherePrimitive prim)
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
