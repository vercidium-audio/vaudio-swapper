// Human-created

namespace vaudioswapper;

public abstract class Primitive
{
    public bool isManaged => native == null;
    public vaudionativewrapper.managed.Primitive native;
    public vaudio.Primitive managed;

    public void Destroy()
    {
        if (!isManaged)
            native.Destroy();
    }

    /// <summary>
    /// Whether rays lose a flat percentage of energy when they touch this primitive, instead of calculating how long the ray spent inside it.<br/>
    /// Flat primitives (e.g. Disk, Plane, Triangle, Line) force this to true and throw if set to false.
    /// </summary>
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
