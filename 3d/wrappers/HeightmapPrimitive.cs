namespace vaudioswapper;

public class HeightmapPrimitive : Primitive
{
    public new vaudio.HeightmapPrimitive managed => base.managed as vaudio.HeightmapPrimitive;
    public new vaudionativewrapper.managed.HeightmapPrimitive native => base.native as vaudionativewrapper.managed.HeightmapPrimitive;

    public HeightmapPrimitive(float[] heights, int sizeX, int sizeY) : this(USE_NATIVE, heights, [], sizeX, sizeY) { }

    public HeightmapPrimitive(float[] heights, bool[] holes, int sizeX, int sizeY) : this(USE_NATIVE, heights, holes, sizeX, sizeY) { }

    public HeightmapPrimitive(bool useNative, float[] heights, int sizeX, int sizeY) : this(useNative, heights, [], sizeX, sizeY) { }

    public HeightmapPrimitive(bool useNative, float[] heights, bool[] holes, int sizeX, int sizeY)
    {
        if (useNative)
            base.native = new vaudionativewrapper.managed.HeightmapPrimitive(heights, holes, sizeX, sizeY);
        else
            base.managed = new vaudio.HeightmapPrimitive(heights, holes, sizeX, sizeY);
    }

    public HeightmapPrimitive(vaudionativewrapper.managed.HeightmapPrimitive prim)
    {
        base.native = prim;
    }

    public HeightmapPrimitive(vaudio.HeightmapPrimitive prim)
    {
        base.managed = prim;
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

    public vaudio.Matrix transform
    {
        get => isManaged ? managed.transform : ToDotnet(native.transform);
        set
        {
            if (isManaged)
                managed.transform = value;
            else
                native.transform = ToNative(value);
        }
    }

    public int sizeX => isManaged ? managed.sizeX : native.sizeX;

    public int sizeY => isManaged ? managed.sizeY : native.sizeY;

    public ReadOnlySpan<float> heights => isManaged ? managed.heights : native.heights;

    public ReadOnlySpan<bool> holes => isManaged ? managed.holes : native.holes;
}
