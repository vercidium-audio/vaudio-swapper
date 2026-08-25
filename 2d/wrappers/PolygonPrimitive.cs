namespace vaudioswapper;

public class PolygonPrimitive : Primitive
{
    public new vaudio.PolygonPrimitive managed => base.managed as vaudio.PolygonPrimitive;
    public new vaudionativewrapper.managed.PolygonPrimitive native => base.native as vaudionativewrapper.managed.PolygonPrimitive;

    public PolygonPrimitive(List<vaudio.Vector> points) : this(USE_NATIVE, points) { }

    public PolygonPrimitive(bool useNative, List<vaudio.Vector> points)
    {
        if (useNative)
            base.native = new vaudionativewrapper.managed.PolygonPrimitive(ToNative(points));
        else
            base.managed = new vaudio.PolygonPrimitive { points = points };
    }

    public PolygonPrimitive(vaudionativewrapper.managed.PolygonPrimitive polygon)
    {
        base.native = polygon;
    }

    public PolygonPrimitive(vaudio.PolygonPrimitive polygon)
    {
        base.managed = polygon;
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

    public List<vaudio.Vector> points
    {
        get => isManaged ? managed.points : new List<vaudio.Vector>(ToDotnet(native.points));
        set
        {
            if (isManaged)
                managed.points = value;
            else
                native.points = ToNative(value).ToArray();
        }
    }

    public vaudio.Vector position
    {
        get => isManaged ? managed.position : ToDotnet(native.position);
        set
        {
            if (isManaged)
                managed.position = value;
            else
                native.position = ToNative(value);
        }
    }

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

    public float scale
    {
        get => isManaged ? managed.scale : native.scale;
        set
        {
            if (isManaged)
                managed.scale = value;
            else
                native.scale = value;
        }
    }

    public bool UseFlatTransmission
    {
        get => isManaged ? managed.UseFlatTransmission : native.UseFlatTransmission;
        set
        {
            if (isManaged)
                managed.UseFlatTransmission = value;
            else
                native.UseFlatTransmission = value;
        }
    }

    public bool enclosed
    {
        get => isManaged ? managed.enclosed : native.enclosed;
        set
        {
            if (isManaged)
                managed.enclosed = value;
            else
                native.enclosed = value;
        }
    }
}
