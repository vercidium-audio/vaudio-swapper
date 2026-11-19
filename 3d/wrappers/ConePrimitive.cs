namespace vaudioswapper;

public class ConePrimitive : Primitive
{
    public new vaudio.ConePrimitive managed => base.managed as vaudio.ConePrimitive;
    public new vaudionativewrapper.managed.ConePrimitive native => base.native as vaudionativewrapper.managed.ConePrimitive;

    public ConePrimitive() : this(USE_NATIVE) { }

    public ConePrimitive(bool useNative)
    {
        if (useNative)
            base.native = new vaudionativewrapper.managed.ConePrimitive();
        else
            base.managed = new vaudio.ConePrimitive();
    }

    public ConePrimitive(vaudionativewrapper.managed.ConePrimitive prim)
    {
        base.native = prim;
    }

    public ConePrimitive(vaudio.ConePrimitive prim)
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

    /// <summary>Radius of the cone base</summary>
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
