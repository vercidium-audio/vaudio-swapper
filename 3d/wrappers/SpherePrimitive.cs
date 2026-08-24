namespace vaudioswapper;

public class SpherePrimitive : Primitive
{
    public new vaudio.SpherePrimitive managed => base.managed as vaudio.SpherePrimitive;
    public new vaudionativewrapper.managed.SpherePrimitive native => base.native as vaudionativewrapper.managed.SpherePrimitive;

    public SpherePrimitive()
    {
        if (USE_NATIVE)
            base.native = new vaudionativewrapper.managed.SpherePrimitive();
        else
            base.managed = new vaudio.SpherePrimitive();
    }

    public SpherePrimitive(vaudionativewrapper.managed.SpherePrimitive sphere)
    {
        base.native = sphere;
    }

    public SpherePrimitive(vaudio.SpherePrimitive sphere)
    {
        base.managed = sphere;
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

    public vaudio.Vector center
    {
        get => isManaged ? managed.center : ToDotnet(native.center);
        set
        {
            if (isManaged)
                managed.center = value;
            else
                native.center = ToNative(value);
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
}
