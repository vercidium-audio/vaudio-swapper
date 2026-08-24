namespace vaudioswapper;

// NOTE: native/2d has no vaPathPrimitive* exports yet (native port deferred, see
// project_pathprimitive_analytic_bezier memory) - the native side of this wrapper
// will fail at the DLL boundary until that port lands. Wrapper added for API parity.
public class PathPrimitive : Primitive
{
    public new vaudio.PathPrimitive managed => base.managed as vaudio.PathPrimitive;
    public new vaudionativewrapper.managed.PathPrimitive native => base.native as vaudionativewrapper.managed.PathPrimitive;

    public PathPrimitive(string svgPath)
    {
        if (USE_NATIVE)
            base.native = new vaudionativewrapper.managed.PathPrimitive(svgPath);
        else
            base.managed = new vaudio.PathPrimitive { svgPath = svgPath };
    }

    public PathPrimitive(vaudionativewrapper.managed.PathPrimitive path)
    {
        base.native = path;
    }

    public PathPrimitive(vaudio.PathPrimitive path)
    {
        base.managed = path;
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

    public string svgPath
    {
        get => isManaged ? managed.svgPath : native.svgPath;
        set
        {
            if (isManaged)
                managed.svgPath = value;
            else
                native.svgPath = value;
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
}
