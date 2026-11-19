// Human-created

namespace vaudioswapper;

/// <summary>
/// Wrap a native or managed PathPrimitive in the 2D SDK
/// </summary>
public class PathPrimitive : Primitive
{
    /// <summary>The C# PathPrimitive</summary>
    public new vaudio.PathPrimitive managed => base.managed as vaudio.PathPrimitive;

    /// <summary>The native PathPrimitive</summary>
    public new vaudionativewrapper.managed.PathPrimitive native => base.native as vaudionativewrapper.managed.PathPrimitive;

    Path _svgPath;

    /// <summary>Create a PathPrimitive based on which SDK the Path was created in</summary>
    public PathPrimitive(Path svgPath)
    {
        if (svgPath.native != null)
            base.native = new vaudionativewrapper.managed.PathPrimitive(svgPath.native);
        else
            base.managed = new vaudio.PathPrimitive(svgPath.managed);

        _svgPath = svgPath;
    }

    /// <summary>Create a PathPrimitive using the SDK set via <see cref="USE_NATIVE"/></summary>
    public PathPrimitive(string svgPath) : this(USE_NATIVE, svgPath) { }

    /// <summary>Create a PathPrimitive using either the C# or native SDK</summary>
    public PathPrimitive(bool useNative, string svgPath)
    {
        if (useNative)
        {
            base.native = new vaudionativewrapper.managed.PathPrimitive(svgPath);
            _svgPath = new Path(native.svgPath);
        }
        else
        {
            base.managed = new vaudio.PathPrimitive(svgPath);
            _svgPath = new Path(managed.svgPath);
        }
    }

    /// <summary>Wrap an existing C# PathPrimitive</summary>
    public PathPrimitive(vaudio.PathPrimitive path)
    {
        base.managed = path;
        _svgPath = new Path(path.svgPath);
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

    /// <summary>Shared, pre-parsed local-space SVG path, before rotation, scale and position are applied</summary>
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

    /// <summary>Position of the path in world space</summary>
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

    /// <summary>Rotation of the path in radians</summary>
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

    /// <summary>Scale applied to the local-space path, before rotation and position</summary>
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
