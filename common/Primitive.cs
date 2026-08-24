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
}
