namespace vaudioswapper;

public class Mesh
{
    internal readonly vaudio.Mesh managed;
    internal readonly vaudionativewrapper.managed.Mesh native;

    public Mesh(vaudio.Vector[] vertices, vaudio.Vector minBounds, vaudio.Vector maxBounds)
    {
        if (USE_NATIVE)
            native = new(ToNative(vertices),
                         ToNative(minBounds),
                         ToNative(maxBounds));
        else
            managed = new vaudio.Mesh(vertices, minBounds, maxBounds);
    }

    public Mesh(List<vaudio.Vector> vertices, vaudio.Vector minBounds, vaudio.Vector maxBounds)
    {
        if (USE_NATIVE)
            native = new(ToNative(vertices),
                         ToNative(minBounds),
                         ToNative(maxBounds));
        else
            managed = new vaudio.Mesh(vertices, minBounds, maxBounds);
    }

    public void Destroy()
    {
        native?.Destroy();
    }
}
