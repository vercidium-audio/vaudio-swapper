namespace vaudioswapper;

public class LinePrimitive : Primitive
{
    public new vaudio.LinePrimitive managed => base.managed as vaudio.LinePrimitive;
    public new vaudionativewrapper.managed.LinePrimitive native => base.native as vaudionativewrapper.managed.LinePrimitive;

    public LinePrimitive()
    {
        if (IS_NATIVE)
            base.native = new vaudionativewrapper.managed.LinePrimitive();
        else
            base.managed = new vaudio.LinePrimitive();
    }

    public LinePrimitive(vaudionativewrapper.managed.LinePrimitive line)
    {
        base.native = line;
    }

    public LinePrimitive(vaudio.LinePrimitive line)
    {
        base.managed = line;
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

    public vaudio.Vector start
    {
        get => isManaged ? managed.start : ToDotnet(native.start);
        set
        {
            if (isManaged)
                managed.start = value;
            else
                native.start = ToNative(value);
        }
    }

    public vaudio.Vector end
    {
        get => isManaged ? managed.end : ToDotnet(native.end);
        set
        {
            if (isManaged)
                managed.end = value;
            else
                native.end = ToNative(value);
        }
    }
}
