namespace vaudioswapper;

public class PolygonPrimitive : Primitive
{
    public new vaudio.PolygonPrimitive managed => base.managed as vaudio.PolygonPrimitive;
    public new vaudionativewrapper.managed.PolygonPrimitive native => base.native as vaudionativewrapper.managed.PolygonPrimitive;

    Polygon _polygon;

    // Native or managed is decided by which SDK the polygon was created with
    public PolygonPrimitive(Polygon polygon)
    {
        if (polygon.native != null)
            base.native = new vaudionativewrapper.managed.PolygonPrimitive(polygon.native);
        else
            base.managed = new vaudio.PolygonPrimitive(polygon.managed);

        _polygon = polygon;
    }

    public PolygonPrimitive(vaudio.Vector[] points) : this(USE_NATIVE, points) { }

    public PolygonPrimitive(bool useNative, vaudio.Vector[] points)
    {
        if (useNative)
        {
            base.native = new vaudionativewrapper.managed.PolygonPrimitive(ToNative(points));
            _polygon = new Polygon(native.polygon);
        }
        else
        {
            base.managed = new vaudio.PolygonPrimitive(points);
            _polygon = new Polygon(managed.polygon);
        }
    }

    public PolygonPrimitive(vaudio.PolygonPrimitive polygon)
    {
        base.managed = polygon;
        _polygon = new Polygon(polygon.polygon);
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

    /// <summary>Shared local-space points, before rotation, scale and position are applied</summary>
    public Polygon polygon
    {
        get => _polygon;
        set
        {
            if (isManaged)
                managed.polygon = value.managed;
            else
                native.polygon = value.native;

            _polygon = value;
        }
    }

    /// <summary>Position of the polygon in world space</summary>
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

    /// <summary>Rotation of the polygon in radians</summary>
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

    /// <summary>Scale applied to the local-space points, before rotation and position</summary>
    public vaudio.Vector scale
    {
        get => isManaged ? managed.scale : ToDotnet(native.scale);
        set
        {
            if (isManaged)
                managed.scale = value;
            else
                native.scale = ToNative(value);
        }
    }

    /// <summary>Whether the last point should connect back to the first</summary>
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
