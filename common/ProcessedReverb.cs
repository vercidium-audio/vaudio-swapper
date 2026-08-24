namespace vaudioswapper;

public class ProcessedReverb
{
    public bool isManaged => native == null;
    public vaudionativewrapper.managed.ProcessedReverb native;
    public vaudio.ProcessedReverb managed;

    public float OutsidePercent => isManaged ? managed.OutsidePercent : native.OutsidePercent;
}
