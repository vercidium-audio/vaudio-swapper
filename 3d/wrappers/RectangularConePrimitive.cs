namespace vaudioswapper;

public class RectangularConePrimitive : Primitive
{
    public new vaudio.RectangularConePrimitive managed => base.managed as vaudio.RectangularConePrimitive;
    public new vaudionativewrapper.managed.RectangularConePrimitive native => base.native as vaudionativewrapper.managed.RectangularConePrimitive;

    public RectangularConePrimitive() : this(USE_NATIVE) { }

    public RectangularConePrimitive(bool useNative)
    {
        if (useNative)
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

    /// <summary>Width of the rectangular base</summary>
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

    /// <summary>Length of the rectangular base</summary>
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

    /// <summary>Height of the cone</summary>
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
