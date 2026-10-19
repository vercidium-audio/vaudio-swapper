namespace vaudioswapper;

public class Polygon
{
    public readonly vaudio.Polygon managed;
    public readonly vaudionativewrapper.managed.Polygon native;

    public Polygon(vaudio.Vector[] points) : this(USE_NATIVE, points) { }

    public Polygon(bool useNative, vaudio.Vector[] points)
    {
        if (useNative)
            native = new(ToNative(points));
        else
            managed = new vaudio.Polygon(points);
    }

    public Polygon(List<vaudio.Vector> points) : this(USE_NATIVE, points) { }

    public Polygon(bool useNative, List<vaudio.Vector> points)
    {
        if (useNative)
            native = new(ToNative(points));
        else
            managed = new vaudio.Polygon(points);
    }

    internal Polygon(vaudio.Polygon polygon)
    {
        managed = polygon;
    }

    internal Polygon(vaudionativewrapper.managed.Polygon polygon)
    {
        native = polygon;
    }

    public IReadOnlyList<vaudio.Vector> points => managed != null ? managed.points : ToDotnet(native.points);

    public void Destroy()
    {
        native?.Destroy();
    }
}
