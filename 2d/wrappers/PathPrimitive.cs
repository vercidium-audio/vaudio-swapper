namespace vaudioswapper;

public class PathPrimitive : Primitive
{
    public new vaudio.PathPrimitive managed => base.managed as vaudio.PathPrimitive;
    public new vaudionativewrapper.managed.PathPrimitive native => base.native as vaudionativewrapper.managed.PathPrimitive;

    Path _svgPath;

    // Native or managed is decided by which SDK the path was created with
    public PathPrimitive(Path svgPath)
    {
        if (svgPath.native != null)
            base.native = new vaudionativewrapper.managed.PathPrimitive(svgPath.native);
        else
            base.managed = new vaudio.PathPrimitive(svgPath.managed);

        _svgPath = svgPath;
    }

    public PathPrimitive(vaudio.PathPrimitive path)
    {
        base.managed = path;
        _svgPath = new Path(path.svgPath);
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

    public Path svgPath
    {
        get => _svgPath;
        set
        {
            if (isManaged)
                managed.svgPath = value.managed;
            else
                native.svgPath = value.native;

            _svgPath = value;
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
}
