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

    /// <summary>Scale of each local axis: X is the distance between adjacent samples along local X, Y multiplies every height, and Z is the distance between adjacent samples along local Z. Defaults to (1, 1, 1)</summary>
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

    /// <summary>Must only contain rotation and translation components, not scale. Use scale instead</summary>
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

    /// <summary>Number of samples along local X</summary>
    public int sizeX => isManaged ? managed.sizeX : native.sizeX;

    /// <summary>Number of samples along local Z</summary>
    public int sizeY => isManaged ? managed.sizeY : native.sizeY;

    /// <summary>The heightmap's copy of the heights, sizeX * sizeY values in row-major order</summary>
    public ReadOnlySpan<float> heights => isManaged ? managed.heights : native.heights;

    /// <summary>The heightmap's copy of the holes, (sizeX - 1) * (sizeY - 1) values in row-major order. Empty if it has no holes</summary>
    public ReadOnlySpan<bool> holes => isManaged ? managed.holes : native.holes;
}
