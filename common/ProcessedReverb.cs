// Human-created

namespace vaudioswapper;

public class ProcessedReverb
{
    public bool isManaged => native == null;
    public vaudionativewrapper.managed.ProcessedReverb native;
    public vaudio.ProcessedReverb managed;

    /// <summary>
    /// The percentage of ambient occlusion energy that reached the edge of the world
    /// </summary>
    public float OutsidePercent => isManaged ? managed.OutsidePercent : native.OutsidePercent;
}
