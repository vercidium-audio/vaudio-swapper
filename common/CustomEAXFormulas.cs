namespace vaudioswapper;

internal unsafe class CustomEAXFormulasAdapter : vaudionativewrapper.managed.CustomEAXFormulas
{
    private readonly vaudio.CustomEAXFormulas inner;

    public CustomEAXFormulasAdapter(vaudio.CustomEAXFormulas inner)
    {
        this.inner = inner;
    }

    public override void Initialise(vaudionativewrapper.ProcessedReverb* processed, float totalReturnedEnergyLF, float totalReturnedEnergyHF, float echogramGranularity, float[] echogramLF, float[] echogramHF, float[] echogramAverage)
    {
        var managedProcessed = new vaudio.ProcessedReverb
        {
            ReturnedPercent = processed->returnedPercent,
            OutsidePercent = processed->outsidePercent,
            MeasuredDecayTimeLF = processed->measuredDecayTimeLF,
            MeasuredDecayTimeHF = processed->measuredDecayTimeHF,
            MaterialRoughness = processed->materialRoughness,
            MaterialAbsorptionLF = processed->materialAbsorptionLF,
            MaterialAbsorptionHF = processed->materialAbsorptionHF
        };

        inner.Initialise(managedProcessed, totalReturnedEnergyLF, totalReturnedEnergyHF, echogramGranularity, echogramLF, echogramHF, echogramAverage);
    }

    public override float CalculateDiffusion() => inner.CalculateDiffusion();

    public override float CalculateDensity() => inner.CalculateDensity();

    public override float CalculateReflectionsDelay(float energyThreshold) => inner.CalculateReflectionsDelay(energyThreshold);

    public override float CalculateLateReverbDelay() => inner.CalculateLateReverbDelay();

    public override void CalculateFrequencyGains(float referenceEnergy, out float lfGain, out float hfGain) => inner.CalculateFrequencyGains(referenceEnergy, out lfGain, out hfGain);

    public override void CalculateReflectionsAndLateReverbGain(float earlyLateTransitionMs, float referenceEnergy, out float reflectionsGain, out float lateReverbGain) => inner.CalculateReflectionsAndLateReverbGain(earlyLateTransitionMs, referenceEnergy, out reflectionsGain, out lateReverbGain);

    public override float CalculateRT60(float[] echogram) => inner.CalculateRT60(echogram);
}
