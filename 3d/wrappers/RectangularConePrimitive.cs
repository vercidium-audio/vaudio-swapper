namespace vaudioswapper;

public class RectangularConePrimitive : Primitive
{
    public new vaudio.RectangularConePrimitive managed => base.managed as vaudio.RectangularConePrimitive;
    public new vaudionativewrapper.managed.RectangularConePrimitive native => base.native as vaudionativewrapper.managed.RectangularConePrimitive;

    public RectangularConePrimitive()
    {
        if (USE_NATIVE)
            base.native = new vaudionativewrapper.managed.RectangularConePrimitive();
        else
            base.managed = new vaudio.RectangularConePrimitive();
    }

    public RectangularConePrimitive(vaudionativewrapper.managed.RectangularConePrimitive prim)
    {
        base.native = prim;
    }

    public RectangularConePrimitive(vaudio.RectangularConePrimitive prim)
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

    public float width
    {
        get => isManaged ? managed.width : native.width;
        set
        {
            if (isManaged)
                managed.width = value;
            else
                native.width = value;
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
