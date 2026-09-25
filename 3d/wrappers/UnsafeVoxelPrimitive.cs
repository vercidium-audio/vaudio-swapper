namespace vaudioswapper;

public unsafe class UnsafeVoxelPrimitive : Primitive
{
    public new vaudio.UnsafeVoxelPrimitive managed => base.managed as vaudio.UnsafeVoxelPrimitive;
    public new vaudionativewrapper.managed.UnsafeVoxelPrimitive native => base.native as vaudionativewrapper.managed.UnsafeVoxelPrimitive;

    public readonly void* data;
    public readonly int width, height, depth;
    public readonly int stride;
    public readonly int xPitch, yPitch, zPitch;

    public UnsafeVoxelPrimitive(void* data, int width, int height, int depth, int stride) : this(USE_NATIVE, data, width, height, depth, stride) { }

    public UnsafeVoxelPrimitive(bool useNative, void* data, int width, int height, int depth, int stride) : this(useNative, data, width, height, depth, stride, height * depth, depth, 1) { }

    public UnsafeVoxelPrimitive(void* data, int width, int height, int depth, int stride, int xPitch, int yPitch, int zPitch) : this(USE_NATIVE, data, width, height, depth, stride, xPitch, yPitch, zPitch) { }

    public UnsafeVoxelPrimitive(bool useNative, void* data, int width, int height, int depth, int stride, int xPitch, int yPitch, int zPitch)
    {
        this.data = data;
        this.width = width;
        this.height = height;
        this.depth = depth;
        this.stride = stride;
        this.xPitch = xPitch;
        this.yPitch = yPitch;
        this.zPitch = zPitch;

        if (useNative)
            base.native = new vaudionativewrapper.managed.UnsafeVoxelPrimitive(data, width, height, depth, stride, xPitch, yPitch, zPitch);
        else
            base.managed = new vaudio.UnsafeVoxelPrimitive(data, width, height, depth, stride, xPitch, yPitch, zPitch);
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

    public vaudio.MaterialType GetMaterial(int x, int y, int z) => isManaged ? managed.GetMaterial(x, y, z) : ToDotnet(native.GetMaterial(x, y, z));

    public bool IsSolid(int x, int y, int z) => isManaged ? managed.IsSolid(x, y, z) : native.IsSolid(x, y, z);

    public void SetDataDirty()
    {
        if (isManaged)
            managed.SetDataDirty();
        else
            native.SetDataDirty();
    }
}
