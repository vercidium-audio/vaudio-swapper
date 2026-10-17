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

    public string data => managed != null ? managed.data : native.data;

    public bool closed => managed != null ? managed.closed : native.closed;

    public void Destroy()
    {
        native?.Destroy();
    }
}
