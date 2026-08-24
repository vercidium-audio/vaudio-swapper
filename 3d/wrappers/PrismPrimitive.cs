namespace vaudioswapper;

public class PrismPrimitive : Primitive
{
    public new vaudio.PrismPrimitive managed => base.managed as vaudio.PrismPrimitive;
    public new vaudionativewrapper.managed.PrismPrimitive native => base.native as vaudionativewrapper.managed.PrismPrimitive;

    public PrismPrimitive(bool isNative)
    {
        if (isNative)
            base.native = new vaudionativewrapper.managed.PrismPrimitive();
        else
            base.managed = new vaudio.PrismPrimitive();
    }

    public PrismPrimitive(vaudionativewrapper.managed.PrismPrimitive prism)
    {
        base.native = prism;
    }

    public PrismPrimitive(vaudio.PrismPrimitive prism)
    {
        base.managed = prism;
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
