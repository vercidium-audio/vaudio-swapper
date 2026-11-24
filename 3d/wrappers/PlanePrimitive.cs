// Human-created

namespace vaudioswapper;

public class PlanePrimitive : Primitive
{
    public new vaudio.PlanePrimitive managed => base.managed as vaudio.PlanePrimitive;
    public new vaudionativewrapper.managed.PlanePrimitive native => base.native as vaudionativewrapper.managed.PlanePrimitive;

    public PlanePrimitive() : this(USE_NATIVE) { }

    public PlanePrimitive(bool useNative)
    {
        if (useNative)
            base.native = new vaudionativewrapper.managed.PlanePrimitive();
        else
            base.managed = new vaudio.PlanePrimitive();
    }

    public PlanePrimitive(vaudionativewrapper.managed.PlanePrimitive prim)
    {
        base.native = prim;
    }

    public PlanePrimitive(vaudio.PlanePrimitive prim)
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

    /// <summary>Width of the plane</summary>
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

    /// <summary>Height of the plane</summary>
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
