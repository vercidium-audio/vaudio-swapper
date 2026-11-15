namespace vaudioswapper;

public class CirclePrimitive : Primitive
{
    public new vaudio.CirclePrimitive managed => base.managed as vaudio.CirclePrimitive;
    public new vaudionativewrapper.managed.CirclePrimitive native => base.native as vaudionativewrapper.managed.CirclePrimitive;

    public CirclePrimitive() : this(USE_NATIVE) { }

    public CirclePrimitive(bool useNative)
    {
        if (useNative)
            base.native = new vaudionativewrapper.managed.CirclePrimitive();
        else
            base.managed = new vaudio.CirclePrimitive();
    }

    public CirclePrimitive(vaudionativewrapper.managed.CirclePrimitive circle)
    {
        base.native = circle;
    }

    public CirclePrimitive(vaudio.CirclePrimitive circle)
    {
        base.managed = circle;
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

    /// <summary>Center of the circle in world space</summary>
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

    /// <summary>Radius of the circle</summary>
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
}
