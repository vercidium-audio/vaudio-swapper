namespace vaudioswapper;

public class ConePrimitive : Primitive
{
    public new vaudio.ConePrimitive managed => base.managed as vaudio.ConePrimitive;
    public new vaudionativewrapper.managed.ConePrimitive native => base.native as vaudionativewrapper.managed.ConePrimitive;

    public ConePrimitive(bool isNative)
    {
        if (isNative)
            base.native = new vaudionativewrapper.managed.ConePrimitive();
        else
            base.managed = new vaudio.ConePrimitive();
    }

    public ConePrimitive(vaudionativewrapper.managed.ConePrimitive prim)
    {
        base.native = prim;
    }

    public ConePrimitive(vaudio.ConePrimitive prim)
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
