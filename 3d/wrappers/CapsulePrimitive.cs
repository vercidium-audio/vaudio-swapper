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

    public CapsulePrimitive(vaudionativewrapper.managed.CapsulePrimitive prim)
    {
        base.native = prim;
    }

    public CapsulePrimitive(vaudio.CapsulePrimitive prim)
    {
        base.managed = prim;
    }

    /// <summary>Controls the amount of energy lost when rays bounce off this primitive and pass through it</summary>
    public vaudio.MaterialType material
    {
        get => isManaged ? managed.material : (vaudio.MaterialType)native.material;
        set
        {
            if (isManaged)
                managed.material = value;
            else
                native.material = (vaudionativewrapper.MaterialType)value;
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

    /// <summary>Length of the body between the spherical caps</summary>
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
