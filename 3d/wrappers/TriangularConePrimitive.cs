namespace vaudioswapper;

public class TriangularConePrimitive : Primitive
{
    public new vaudio.TriangularConePrimitive managed => base.managed as vaudio.TriangularConePrimitive;
    public new vaudionativewrapper.managed.TriangularConePrimitive native => base.native as vaudionativewrapper.managed.TriangularConePrimitive;

    public TriangularConePrimitive()
    {
        if (USE_NATIVE)
            base.native = new vaudionativewrapper.managed.TriangularConePrimitive();
        else
            base.managed = new vaudio.TriangularConePrimitive();
    }

    public TriangularConePrimitive(vaudionativewrapper.managed.TriangularConePrimitive prim)
    {
        base.native = prim;
    }

    public TriangularConePrimitive(vaudio.TriangularConePrimitive prim)
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

    public float height
    {
        get => isManaged ? managed.height : native.height;
        set
        {
            if (isManaged)
                managed.height = value;
            else
                native.height = value;
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
