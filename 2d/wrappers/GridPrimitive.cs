namespace vaudioswapper;

public class GridPrimitive : Primitive
{
    public new vaudio.GridPrimitive managed => base.managed as vaudio.GridPrimitive;
    public new vaudionativewrapper.managed.GridPrimitive native => base.native as vaudionativewrapper.managed.GridPrimitive;

    public GridPrimitive(bool isNative, int width, int height)
    {
        if (isNative)
            base.native = new vaudionativewrapper.managed.GridPrimitive(width, height);
        else
            base.managed = new vaudio.GridPrimitive(width, height);
    }

    public GridPrimitive(vaudionativewrapper.managed.GridPrimitive grid)
    {
        base.native = grid;
    }

    public GridPrimitive(vaudio.GridPrimitive grid)
    {
        base.managed = grid;
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

    public vaudio.MaterialType this[int x, int y]
    {
        get => isManaged ? managed[x, y] : ToDotnet(native[x, y]);
        set
        {
            if (isManaged)
                managed[x, y] = value;
            else
                native[x, y] = ToNative(value);
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
