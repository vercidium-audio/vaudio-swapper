namespace vaudioswapper;

public class BoxPrimitive : Primitive
{
    public new vaudio.BoxPrimitive managed => base.managed as vaudio.BoxPrimitive;
    public new vaudionativewrapper.managed.BoxPrimitive native => base.native as vaudionativewrapper.managed.BoxPrimitive;

    public BoxPrimitive()
    {
        if (IS_NATIVE)
            base.native = new vaudionativewrapper.managed.BoxPrimitive();
        else
            base.managed = new vaudio.BoxPrimitive();
    }

    public BoxPrimitive(vaudionativewrapper.managed.BoxPrimitive box)
    {
        base.native = box;
    }

    public BoxPrimitive(vaudio.BoxPrimitive box)
    {
        base.managed = box;
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

    public vaudio.Vector position
    {
        get => isManaged ? managed.position : ToDotnet(native.position);
        set
        {
            if (isManaged)
                managed.position = value;
            else
                native.position = ToNative(value);
        }
    }

    public vaudio.Vector size
    {
        get => isManaged ? managed.size : ToDotnet(native.size);
        set
        {
            if (isManaged)
                managed.size = value;
            else
                native.size = ToNative(value);
        }
    }

    public float rotation
    {
        get => isManaged ? managed.rotation : native.rotation;
        set
        {
            if (isManaged)
                managed.rotation = value;
            else
                native.rotation = value;
        }
    }
}
