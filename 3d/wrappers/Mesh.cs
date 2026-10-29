using System.Runtime.InteropServices;

namespace vaudioswapper;

public class Mesh
{
    public readonly vaudio.Mesh managed;
    public readonly vaudionativewrapper.managed.Mesh native;

    public Mesh(List<vaudio.Vector> vertices, vaudio.Vector minBounds, vaudio.Vector maxBounds) : this(USE_NATIVE, vertices, minBounds, maxBounds) { }

    public Mesh(bool useNative, List<vaudio.Vector> vertices, vaudio.Vector minBounds, vaudio.Vector maxBounds) : this(useNative, CollectionsMarshal.AsSpan(vertices), minBounds, maxBounds) { }

    public Mesh(ReadOnlySpan<vaudio.Vector> vertices, vaudio.Vector minBounds, vaudio.Vector maxBounds) : this(USE_NATIVE, vertices, minBounds, maxBounds) { }

    public Mesh(bool useNative, ReadOnlySpan<vaudio.Vector> vertices, vaudio.Vector minBounds, vaudio.Vector maxBounds)
    {
        if (useNative)
            native = new(ToNative(vertices),
                         ToNative(minBounds),
                         ToNative(maxBounds));
        else
            managed = new vaudio.Mesh(vertices, minBounds, maxBounds);
    }

    public Mesh(vaudio.Mesh mesh)
    {
        managed = mesh;
    }

    public Mesh(vaudionativewrapper.managed.Mesh mesh)
    {
        native = mesh;
    }

    public Mesh(vaudio.Mesh managed)
    {
        this.managed = managed;
    }

    public Mesh(vaudionativewrapper.managed.Mesh native)
    {
        this.native = native;
    }

    public void Destroy()
    {
        native?.Destroy();
    }
}
