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
