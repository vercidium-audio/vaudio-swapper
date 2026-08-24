namespace vaudioswapper;

public class TriangularPrismPrimitive : Primitive
{
    public new vaudio.TriangularPrismPrimitive managed => base.managed as vaudio.TriangularPrismPrimitive;
    public new vaudionativewrapper.managed.TriangularPrismPrimitive native => base.native as vaudionativewrapper.managed.TriangularPrismPrimitive;

    public TriangularPrismPrimitive()
    {
        if (USE_NATIVE)
            base.native = new vaudionativewrapper.managed.TriangularPrismPrimitive();
        else
            base.managed = new vaudio.TriangularPrismPrimitive();
    }

    public TriangularPrismPrimitive(vaudionativewrapper.managed.TriangularPrismPrimitive prim)
    {
        base.native = prim;
    }

    public TriangularPrismPrimitive(vaudio.TriangularPrismPrimitive prim)
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
