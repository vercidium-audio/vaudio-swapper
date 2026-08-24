namespace vaudioswapper;

public class CylinderPrimitive : Primitive
{
    public new vaudio.CylinderPrimitive managed => base.managed as vaudio.CylinderPrimitive;
    public new vaudionativewrapper.managed.CylinderPrimitive native => base.native as vaudionativewrapper.managed.CylinderPrimitive;

    public CylinderPrimitive(bool isNative)
    {
        if (isNative)
            base.native = new vaudionativewrapper.managed.CylinderPrimitive();
        else
            base.managed = new vaudio.CylinderPrimitive();
    }

    public CylinderPrimitive(vaudionativewrapper.managed.CylinderPrimitive prim)
    {
        base.native = prim;
    }

    public CylinderPrimitive(vaudio.CylinderPrimitive prim)
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
