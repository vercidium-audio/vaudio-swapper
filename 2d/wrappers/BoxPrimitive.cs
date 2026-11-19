// Human-created

namespace vaudioswapper;

public class BoxPrimitive : Primitive
{
    public new vaudio.BoxPrimitive managed => base.managed as vaudio.BoxPrimitive;
    public new vaudionativewrapper.managed.BoxPrimitive native => base.native as vaudionativewrapper.managed.BoxPrimitive;

    public BoxPrimitive() : this(USE_NATIVE) { }

    public BoxPrimitive(bool useNative)
    {
        if (useNative)
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

    /// <summary>Center of the box in world space</summary>
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

    /// <summary>Size of the box</summary>
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

    /// <summary>Rotation of the box in radians</summary>
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
