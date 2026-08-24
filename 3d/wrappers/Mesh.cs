namespace vaudioswapper;

public class Mesh
{
    internal readonly vaudio.Mesh managed;
    internal readonly vaudionativewrapper.managed.Mesh native;
    internal readonly bool isManaged;

    public Mesh(bool isNative, vaudio.Vector[] vertices, vaudio.Vector minBounds, vaudio.Vector maxBounds)
    {
        isManaged = !isNative;

        if (isNative)
            native = new(ToNative(vertices),
                         ToNative(minBounds),
                         ToNative(maxBounds));
        else
            managed = new vaudio.Mesh(vertices, minBounds, maxBounds);
    }

    public Mesh(bool isNative, List<vaudio.Vector> vertices, vaudio.Vector minBounds, vaudio.Vector maxBounds)
    {
        isManaged = !isNative;

        if (isNative)
            native = new(ToNative(vertices),
                         ToNative(minBounds),
                         ToNative(maxBounds));
        else
            managed = new vaudio.Mesh(vertices, minBounds, maxBounds);
    }

    public void Destroy()
    {
        if (isManaged)
            return;

        native.Destroy();
    }
}
