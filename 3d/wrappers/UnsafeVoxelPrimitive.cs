// Human-created

namespace vaudioswapper;

public unsafe class UnsafeVoxelPrimitive : Primitive
{
    public new vaudio.UnsafeVoxelPrimitive managed => base.managed as vaudio.UnsafeVoxelPrimitive;
    public new vaudionativewrapper.managed.UnsafeVoxelPrimitive native => base.native as vaudionativewrapper.managed.UnsafeVoxelPrimitive;

    /// <summary>Pointer to the first voxel. Owned by the caller</summary>
    public readonly void* data;
    public readonly int width, height, depth;
    /// <summary>Size of each voxel in bytes</summary>
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

    /// <summary>Scale of the voxels</summary>
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

    /// <summary>Must only contain rotation and translation components, not scale</summary>
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

    /// <summary>
    /// Invoked on the main thread once this primitive has been removed from its world and the raytracing threads no longer use its voxel data.<br/>
    /// This is invoked by World.Update, or by World.RemovePrimitive if this primitive was never sent to the raytracing threads.
    /// </summary>
    public Action OnRemoved
    {
        get => isManaged ? managed.OnRemoved : native.OnRemoved;
        set
        {
            if (isManaged)
                managed.OnRemoved = value;
            else
                native.OnRemoved = value;
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
