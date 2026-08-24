namespace vaudioswapper;

public class CapsulePrimitive : Primitive
{
    public new vaudio.CapsulePrimitive managed => base.managed as vaudio.CapsulePrimitive;
    public new vaudionativewrapper.managed.CapsulePrimitive native => base.native as vaudionativewrapper.managed.CapsulePrimitive;

    public CapsulePrimitive(bool isNative)
    {
        if (isNative)
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
