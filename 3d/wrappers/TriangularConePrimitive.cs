// Human-created

namespace vaudioswapper;

public class TriangularConePrimitive : Primitive
{
    public new vaudio.TriangularConePrimitive managed => base.managed as vaudio.TriangularConePrimitive;
    public new vaudionativewrapper.managed.TriangularConePrimitive native => base.native as vaudionativewrapper.managed.TriangularConePrimitive;

    public TriangularConePrimitive() : this(USE_NATIVE) { }

    public TriangularConePrimitive(bool useNative)
    {
        if (useNative)
            base.native = new vaudionativewrapper.managed.TriangularConePrimitive();
        else
            base.managed = new vaudio.TriangularConePrimitive();
    }

    public TriangularConePrimitive(vaudionativewrapper.managed.TriangularConePrimitive prim)
    {
        base.native = prim;
    }

    public TriangularConePrimitive(vaudio.TriangularConePrimitive prim)
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

    /// <summary>The radius of the triangular base</summary>
    public float radius
    {
        get => isManaged ? managed.radius : native.radius;
        set
        {
            if (isManaged)
                managed.radius = value;
            else
                native.radius = value;
        }
    }

    /// <summary>The height of the cone</summary>
    public float height
    {
        get => isManaged ? managed.height : native.height;
        set
        {
            if (isManaged)
                managed.height = value;
            else
                native.height = value;
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
}
