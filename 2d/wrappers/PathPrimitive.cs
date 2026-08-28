namespace vaudioswapper;

public class PathPrimitive : Primitive
{
    public new vaudio.PathPrimitive managed => base.managed as vaudio.PathPrimitive;
    public new vaudionativewrapper.managed.PathPrimitive native => base.native as vaudionativewrapper.managed.PathPrimitive;

    public PathPrimitive(string svgPath) : this(USE_NATIVE, svgPath) { }

    public PathPrimitive(bool useNative, string svgPath)
    {
        if (useNative)
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
