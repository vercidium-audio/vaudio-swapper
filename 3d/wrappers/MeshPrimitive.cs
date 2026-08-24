namespace vaudioswapper;

public class MeshPrimitive : Primitive
{
    public new vaudio.MeshPrimitive managed => base.managed as vaudio.MeshPrimitive;
    public new vaudionativewrapper.managed.MeshPrimitive native => base.native as vaudionativewrapper.managed.MeshPrimitive;

    public MeshPrimitive(vaudio.MaterialType material, List<vaudio.Vector> vertices, vaudio.Vector minBounds, vaudio.Vector maxBounds, vaudio.Matrix transform)
    {
        if (IS_NATIVE)
            base.native = new vaudionativewrapper.managed.MeshPrimitive(ToNative(material),
                                                                        ToNative(vertices.ToArray()),
                                                                        ToNative(minBounds),
                                                                        ToNative(maxBounds),
                                                                        ToNative(transform));
        else
            base.managed = new vaudio.MeshPrimitive(material, vertices, minBounds, maxBounds, transform);
    }

    public MeshPrimitive(vaudio.MaterialType material, vaudio.Vector[] vertices, vaudio.Vector minBounds, vaudio.Vector maxBounds, vaudio.Matrix transform)
    {
        if (IS_NATIVE)
            base.native = new vaudionativewrapper.managed.MeshPrimitive(ToNative(material),
                                                                        ToNative(vertices),
                                                                        ToNative(minBounds),
                                                                        ToNative(maxBounds),
                                                                        ToNative(transform));
        else
            base.managed = new vaudio.MeshPrimitive(material, vertices, minBounds, maxBounds, transform);
    }

    public MeshPrimitive(vaudio.MaterialType material, Mesh mesh, vaudio.Matrix transform)
    {
        if (IS_NATIVE)
            base.native = new vaudionativewrapper.managed.MeshPrimitive(ToNative(material),
                                                                        mesh.native,
                                                                        ToNative(transform));
        else
            base.managed = new vaudio.MeshPrimitive(material, mesh.managed, transform);
    }

    public MeshPrimitive(vaudionativewrapper.managed.MeshPrimitive prim)
    {
        base.native = prim;
    }

    public MeshPrimitive(vaudio.MeshPrimitive prim)
    {
        base.managed = prim;
    }

    public vaudio.MaterialType material
    {
        get => isManaged ? managed.material : (vaudio.MaterialType)native.material;
        set
        {
            if (isManaged)
                managed.material = value;
            else
                native.material = (vaudionativewrapper.MaterialType)value;
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

    public void DisposeBuffer()
    {
        if (isManaged)
            managed.DisposeBuffer();
        else
        {
            // No buffers in native
        }
    }
}
