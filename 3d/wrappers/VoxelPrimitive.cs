namespace vaudioswapper;

public class VoxelPrimitive : Primitive
{
    public new vaudio.VoxelPrimitive managed => base.managed as vaudio.VoxelPrimitive;
    public new vaudionativewrapper.managed.VoxelPrimitive native => base.native as vaudionativewrapper.managed.VoxelPrimitive;

    public readonly int width;
    public readonly int height;
    public readonly int depth;

    public VoxelPrimitive(int width, int height, int depth)
    {
        this.width = width;
        this.height = height;
        this.depth = depth;

        if (IS_NATIVE)
            base.native = new vaudionativewrapper.managed.VoxelPrimitive(width, height, depth);
        else
            base.managed = new vaudio.VoxelPrimitive(width, height, depth);
    }

    public VoxelPrimitive(vaudionativewrapper.managed.VoxelPrimitive prim)
    {
        base.native = prim;
    }

    public VoxelPrimitive(vaudio.VoxelPrimitive prim)
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

    public vaudio.MaterialType this[int x, int y, int z]
    {
        get => isManaged ? managed.data[x, y, z] : ToDotnet(native[x, y, z]);
        set
        {
            if (isManaged)
                managed.data[x, y, z] = value;
            else
                native[x, y, z] = ToNative(value);
        }
    }

    public void SetDataDirty()
    {
        if (isManaged)
            managed.SetDataDirty();
        else
            native.SetDataDirty();
    }
}
