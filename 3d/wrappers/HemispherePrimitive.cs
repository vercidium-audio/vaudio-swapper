// Human-created

namespace vaudioswapper;

public class HemispherePrimitive : Primitive
{
    public new vaudio.HemispherePrimitive managed => base.managed as vaudio.HemispherePrimitive;
    public new vaudionativewrapper.managed.HemispherePrimitive native => base.native as vaudionativewrapper.managed.HemispherePrimitive;

    public HemispherePrimitive() : this(USE_NATIVE) { }

    public HemispherePrimitive(bool useNative)
    {
        if (useNative)
            base.native = new vaudionativewrapper.managed.HemispherePrimitive();
        else
            base.managed = new vaudio.HemispherePrimitive();
    }

    public HemispherePrimitive(vaudionativewrapper.managed.HemispherePrimitive prim)
    {
        base.native = prim;
    }

    public HemispherePrimitive(vaudio.HemispherePrimitive prim)
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

    /// <summary>Radius of the hemisphere</summary>
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
