namespace vaudioswapper;

public class TrianglePrimitive : Primitive
{
    public new vaudio.TrianglePrimitive managed => base.managed as vaudio.TrianglePrimitive;
    public new vaudionativewrapper.managed.TrianglePrimitive native => base.native as vaudionativewrapper.managed.TrianglePrimitive;

    public TrianglePrimitive(bool isNative)
    {
        if (isNative)
            base.native = new vaudionativewrapper.managed.TrianglePrimitive();
        else
            base.managed = new vaudio.TrianglePrimitive();
    }

    public TrianglePrimitive(vaudionativewrapper.managed.TrianglePrimitive prim)
    {
        base.native = prim;
    }

    public TrianglePrimitive(vaudio.TrianglePrimitive prim)
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

    public vaudio.Vector position0
    {
        get => isManaged ? managed.position0 : ToDotnet(native.position0);
        set
        {
            if (isManaged)
                managed.position0 = value;
            else
                native.position0 = ToNative(value);
        }
    }

    public vaudio.Vector position1
    {
        get => isManaged ? managed.position1 : ToDotnet(native.position1);
        set
        {
            if (isManaged)
                managed.position1 = value;
            else
                native.position1 = ToNative(value);
        }
    }

    public vaudio.Vector position2
    {
        get => isManaged ? managed.position2 : ToDotnet(native.position2);
        set
        {
            if (isManaged)
                managed.position2 = value;
            else
                native.position2 = ToNative(value);
        }
    }
}
