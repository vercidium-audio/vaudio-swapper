namespace vaudioswapper;

public class Path
{
    public readonly vaudio.Path managed;
    public readonly vaudionativewrapper.managed.Path native;

    public Path(string data) : this(USE_NATIVE, data) { }

    public Path(bool useNative, string data)
    {
        if (useNative)
            native = new(data);
        else
            managed = new vaudio.Path(data);
    }

    internal Path(vaudio.Path path)
    {
        managed = path;
    }

    internal Path(vaudionativewrapper.managed.Path path)
    {
        native = path;
    }

    /// <summary>The SVG path data this path was parsed from</summary>
    public string data => managed != null ? managed.data : native.data;

    /// <summary>Whether the path ends with Z/z</summary>
    public bool closed => managed != null ? managed.closed : native.closed;

    public void Destroy()
    {
        native?.Destroy();
    }
}
