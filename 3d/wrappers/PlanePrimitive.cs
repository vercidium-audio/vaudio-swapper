namespace vaudioswapper;

public class PlanePrimitive : Primitive
{
    public new vaudio.PlanePrimitive managed => base.managed as vaudio.PlanePrimitive;
    public new vaudionativewrapper.managed.PlanePrimitive native => base.native as vaudionativewrapper.managed.PlanePrimitive;

    public PlanePrimitive()
    {
        if (IS_NATIVE)
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
