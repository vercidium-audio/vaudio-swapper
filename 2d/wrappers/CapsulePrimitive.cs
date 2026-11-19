// Human-created

namespace vaudioswapper;

public class CapsulePrimitive : Primitive
{
    public new vaudio.CapsulePrimitive managed => base.managed as vaudio.CapsulePrimitive;
    public new vaudionativewrapper.managed.CapsulePrimitive native => base.native as vaudionativewrapper.managed.CapsulePrimitive;

    public CapsulePrimitive() : this(USE_NATIVE) { }

    public CapsulePrimitive(bool useNative)
    {
        if (useNative)
            base.native = new vaudionativewrapper.managed.CapsulePrimitive();
        else
            base.managed = new vaudio.CapsulePrimitive();
    }

    public CapsulePrimitive(vaudionativewrapper.managed.CapsulePrimitive oval)
    {
        base.native = oval;
    }

    public CapsulePrimitive(vaudio.CapsulePrimitive oval)
    {
        base.managed = oval;
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

    /// <summary>Center of the capsule in world space</summary>
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

    /// <summary>Radius of the capsule</summary>
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

    /// <summary>Length of the body between the semicircular caps. The total length of the capsule is length + 2 * radius</summary>
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

    /// <summary>Rotation of the capsule in radians</summary>
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
