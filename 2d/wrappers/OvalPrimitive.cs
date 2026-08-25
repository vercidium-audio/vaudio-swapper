namespace vaudioswapper;

public class OvalPrimitive : Primitive
{
    public new vaudio.OvalPrimitive managed => base.managed as vaudio.OvalPrimitive;
    public new vaudionativewrapper.managed.OvalPrimitive native => base.native as vaudionativewrapper.managed.OvalPrimitive;

    public OvalPrimitive() : this(USE_NATIVE) { }

    public OvalPrimitive(bool useNative)
    {
        if (useNative)
            base.native = new vaudionativewrapper.managed.OvalPrimitive();
        else
            base.managed = new vaudio.OvalPrimitive();
    }

    public OvalPrimitive(vaudionativewrapper.managed.OvalPrimitive oval)
    {
        base.native = oval;
    }

    public OvalPrimitive(vaudio.OvalPrimitive oval)
    {
        base.managed = oval;
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

    public float radiusX
    {
        get => isManaged ? managed.radiusX : native.radiusX;
        set
        {
            if (isManaged)
                managed.radiusX = value;
            else
                native.radiusX = value;
        }
    }

    public float radiusY
    {
        get => isManaged ? managed.radiusY : native.radiusY;
        set
        {
            if (isManaged)
                managed.radiusY = value;
            else
                native.radiusY = value;
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
