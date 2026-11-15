namespace vaudioswapper;

public class ProcessedReverb
{
    public bool isManaged => native == null;
    public vaudionativewrapper.managed.ProcessedReverb native;
    public vaudio.ProcessedReverb managed;

    /// <summary>
    /// The percentage of energy that escaped outside (hit the world edge).<br/>
    /// Calculated as raw.OutsideTotal / (ReverbRayCount * ReverbBounceCount)
    /// </summary>
    public float OutsidePercent => isManaged ? managed.OutsidePercent : native.OutsidePercent;
}
