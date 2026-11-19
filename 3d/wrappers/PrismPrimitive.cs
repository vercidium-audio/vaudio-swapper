namespace vaudioswapper;

public class PrismPrimitive : Primitive
{
    public new vaudio.PrismPrimitive managed => base.managed as vaudio.PrismPrimitive;
    public new vaudionativewrapper.managed.PrismPrimitive native => base.native as vaudionativewrapper.managed.PrismPrimitive;

    public PrismPrimitive() : this(USE_NATIVE) { }

    public PrismPrimitive(bool useNative)
    {
        if (useNative)
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

    /// <summary>Size of the prism</summary>
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
