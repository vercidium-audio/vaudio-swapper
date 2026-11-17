// Human-created

namespace vaudioswapper;

public unsafe partial class Emitter
{
    public bool isManaged => native == null;
    public vaudionativewrapper.managed.Emitter native;
    public vaudio.Emitter managed;

    public Emitter(vaudionativewrapper.managed.Emitter native)
    {
        this.native = native;
    }

    public Emitter(IntPtr native)
    {
        this.native = new(native);
    }

    public Emitter() : this(USE_NATIVE) { }

    public Emitter(bool useNative)
    {
        if (useNative)
            native = new();
        else
            managed = new();
    }

    public void Destroy()
    {
        if (!isManaged)
            native.Destroy();
    }

    /// <summary>True if this emitter hasn't cast its own reverb and ambient rays yet.</summary>
    public bool Initialising
    {
        get => isManaged ? managed.Initialising : native.Initialising;
    }

    /// <summary>Whether this emitter will be removed from the world when its reverb tail finishes playing. While true, changing this emitter's properties (excluding Name, UserData, LogCallback, LogErrorCallback, OnRemoved and KeepReverbTailAlive) or adding targets throws an InvalidOperationException.</summary>
    public bool PendingRemoval
    {
        get => isManaged ? managed.PendingRemoval : native.PendingRemoval;
    }

    /// <summary>
    /// Suspended emitters will not re-cast their rays, but will still be raytraced by other emitters as muffling targets.<br/>
    /// When un-suspended, all of its rays are re-cast, and it can join a cluster again.
    /// </summary>
    public bool Suspended
    {
        get => isManaged ? managed.Suspended : native.Suspended;
        set
        {
            if (isManaged)
                managed.Suspended = value;
            else
                native.Suspended = value;
        }
    }

    /// <summary>Whether this emitter's EAX is blended into the World.GroupedEAX list. Set this to false for listener emitters</summary>
    public bool AffectsGroupedEAX
    {
        get => isManaged ? managed.AffectsGroupedEAX : native.AffectsGroupedEAX;
        set
        {
            if (isManaged)
                managed.AffectsGroupedEAX = value;
            else
                native.AffectsGroupedEAX = value;
        }
    }

    /// <summary>Whether this emitter is kept alive while its reverb tail continues to play. Setting this to false while PendingRemoval is true removes the emitter on the next World.Update.</summary>
    public bool KeepReverbTailAlive
    {
        get => isManaged ? managed.KeepReverbTailAlive : native.KeepReverbTailAlive;
        set
        {
            if (isManaged)
                managed.KeepReverbTailAlive = value;
            else
                native.KeepReverbTailAlive = value;
        }
    }

    /// <summary>The index of this emitter's EAX object in World.GroupedEAX</summary>
    public int GroupedEAXIndex => isManaged ? managed.GroupedEAXIndex : native.GroupedEAXIndex;

    /// <summary>The percentage of ambient occlusion rays that reached the edge of the world.</summary>
    public float OutsidePercent => isManaged ? managed.OutsidePercent : native.OutsidePercent;

    /// <summary>Whether reverb gain and direction will be calculated relative to this emitter. Set to true for your main listener emitter.</summary>
    public bool HasRelativeReverb
    {
        get => isManaged ? managed.HasRelativeReverb : native.HasRelativeReverb;
        set
        {
            if (isManaged)
                managed.HasRelativeReverb = value;
            else
                native.HasRelativeReverb = value;
        }
    }

    /// <summary>
    /// Reverb directionality is calculated in two stages:<br/>
    /// - First the average direction from this emitter to all of another emitter's reverb bounce positions is calculated. This direction is called the 'directional reverb vector'.<br/>
    /// - Second this vector is normalised using the RelativeReverbInnerThreshold and RelativeReverbOuterThreshold bounds.<br/>
    /// For reference, a vector of (0, 0, 0) has no direction, so you'll hear the reverb all around you. A vector of (0.5f, 0, 0) has reverb mostly coming from the right.<br/>
    /// If the magnitude of the directional reverb vector is lower than RelativeReverbInnerThreshold, reverb will not be directional (sounds like the reverb is all around you).<br/>
    /// Reduce this value to make it easier to hear directional reverb.<br/>
    /// Increase this value to make it harder to hear directional reverb.
    /// </summary>
    public float RelativeReverbInnerThreshold
    {
        get => isManaged ? managed.RelativeReverbInnerThreshold : native.RelativeReverbInnerThreshold;
        set
        {
            if (isManaged)
                managed.RelativeReverbInnerThreshold = value;
            else
                native.RelativeReverbInnerThreshold = value;
        }
    }

    /// <summary>
    /// Reverb directionality is calculated in two stages:<br/>
    /// - First the average direction from this emitter to all of another emitter's reverb bounce positions is calculated. This direction is called the 'directional reverb vector'.<br/>
    /// - Second this vector is normalised using the RelativeReverbInnerThreshold and RelativeReverbOuterThreshold bounds.<br/>
    /// For reference, a vector of (0, 0, 0) has no direction, so you'll hear the reverb all around you. A vector of (0.5f, 0, 0) has reverb mostly coming from the right.<br/>
    /// If the magnitude of the directional reverb vector is higher than RelativeReverbOuterThreshold, reverb will be fully directional.<br/>
    /// Reduce this value to make it easier to hear directional reverb.<br/>
    /// Increase this value to make it harder to hear directional reverb.
    /// </summary>
    public float RelativeReverbOuterThreshold
    {
        get => isManaged ? managed.RelativeReverbOuterThreshold : native.RelativeReverbOuterThreshold;
        set
        {
            if (isManaged)
                managed.RelativeReverbOuterThreshold = value;
            else
                native.RelativeReverbOuterThreshold = value;
        }
    }

    /// <summary>Whether to clamp this emitter's position within the world bounds.</summary>
    public bool ClampPosition
    {
        get => isManaged ? managed.ClampPosition : native.ClampPosition;
        set
        {
            if (isManaged)
                managed.ClampPosition = value;
            else
                native.ClampPosition = value;
        }
    }

    /// <summary>This name is displayed in the debug window. Setting null stores an empty string.</summary>
    public string Name
    {
        get => isManaged ? managed.Name : native.Name;
        set
        {
            if (isManaged)
                managed.Name = value;
            else
                native.Name = value;
        }
    }

    /// <summary>Custom user data.</summary>
    public object UserData
    {
        get => isManaged ? managed.UserData : native.UserData;
        set
        {
            if (isManaged)
                managed.UserData = value;
            else
                throw new InvalidOperationException("Cannot assign UserData to a native emitter");
        }
    }

    /// <summary>
    /// Contains EAX reverb properties. This object is null until this emitter casts its reverb rays for the first time.<br/>
    /// See Initialising and OnRaytracingComplete
    /// </summary>
    public EAXReverb EAX
    {
        get
        {
            if (isManaged)
                return new EAXReverb { managed = managed.EAX };
            else
                return new EAXReverb { native = native.EAX };
        }
    }

    /// <summary>
    /// Contains data gathered by reverb rays. This object is null until this emitter casts its reverb rays for the first time.<br/>
    /// See Initialising and OnRaytracingComplete
    /// </summary>
    public ProcessedReverb ProcessedReverb
    {
        get
        {
            if (isManaged)
                return new ProcessedReverb { managed = managed.ProcessedReverb };
            else
                return new ProcessedReverb { native = native.ProcessedReverb };
        }
    }

    /// <summary>
    /// Contains the low- and high-frequency volume of ambient sounds. This object is null until this emitter casts its ambient rays for the first time, and null if neither ambient occlusion nor ambient permeation is enabled.<br/>
    /// See Initialising and OnRaytracingComplete
    /// </summary>
    public LowPassFilter AmbientFilter
    {
        get
        {
            if (isManaged)
                return new LowPassFilter(managed.AmbientFilter);
            else
                return new LowPassFilter(native.AmbientFilter);
        }
    }

    /// <summary>Number of reverb rays to cast</summary>
    public int ReverbRayCount
    {
        get => isManaged ? managed.ReverbRayCount : native.ReverbRayCount;
        set
        {
            if (isManaged)
                managed.ReverbRayCount = value;
            else
                native.ReverbRayCount = value;
        }
    }

    /// <summary>Number of bounces per reverb ray</summary>
    public int ReverbBounceCount
    {
        get => isManaged ? managed.ReverbBounceCount : native.ReverbBounceCount;
        set
        {
            if (isManaged)
                managed.ReverbBounceCount = value;
            else
                native.ReverbBounceCount = value;
        }
    }

    /// <summary>Number of occlusion rays to cast</summary>
    public int OcclusionRayCount
    {
        get => isManaged ? managed.OcclusionRayCount : native.OcclusionRayCount;
        set
        {
            if (isManaged)
                managed.OcclusionRayCount = value;
            else
                native.OcclusionRayCount = value;
        }
    }

    /// <summary>Maximum number of bounces per occlusion ray</summary>
    public int OcclusionBounceCount
    {
        get => isManaged ? managed.OcclusionBounceCount : native.OcclusionBounceCount;
        set
        {
            if (isManaged)
                managed.OcclusionBounceCount = value;
            else
                native.OcclusionBounceCount = value;
        }
    }

    /// <summary>Number of permeation rays to cast</summary>
    public int PermeationRayCount
    {
        get => isManaged ? managed.PermeationRayCount : native.PermeationRayCount;
        set
        {
            if (isManaged)
                managed.PermeationRayCount = value;
            else
                native.PermeationRayCount = value;
        }
    }

    /// <summary>Number of bounces per permeation ray</summary>
    public int PermeationBounceCount
    {
        get => isManaged ? managed.PermeationBounceCount : native.PermeationBounceCount;
        set
        {
            if (isManaged)
                managed.PermeationBounceCount = value;
            else
                native.PermeationBounceCount = value;
        }
    }

    /// <summary>Number of ambient occlusion rays to cast</summary>
    public int AmbientOcclusionRayCount
    {
        get => isManaged ? managed.AmbientOcclusionRayCount : native.AmbientOcclusionRayCount;
        set
        {
            if (isManaged)
                managed.AmbientOcclusionRayCount = value;
            else
                native.AmbientOcclusionRayCount = value;
        }
    }

    /// <summary>Number of bounces per ambient occlusion ray</summary>
    public int AmbientOcclusionBounceCount
    {
        get => isManaged ? managed.AmbientOcclusionBounceCount : native.AmbientOcclusionBounceCount;
        set
        {
            if (isManaged)
                managed.AmbientOcclusionBounceCount = value;
            else
                native.AmbientOcclusionBounceCount = value;
        }
    }

    /// <summary>Number of ambient permeation rays to cast</summary>
    public int AmbientPermeationRayCount
    {
        get => isManaged ? managed.AmbientPermeationRayCount : native.AmbientPermeationRayCount;
        set
        {
            if (isManaged)
                managed.AmbientPermeationRayCount = value;
            else
                native.AmbientPermeationRayCount = value;
        }
    }

    /// <summary>Number of bounces per ambient permeation ray</summary>
    public int AmbientPermeationBounceCount
    {
        get => isManaged ? managed.AmbientPermeationBounceCount : native.AmbientPermeationBounceCount;
        set
        {
            if (isManaged)
                managed.AmbientPermeationBounceCount = value;
            else
                native.AmbientPermeationBounceCount = value;
        }
    }

    /// <summary>Number of visualisation rays to cast</summary>
    public int VisualisationRayCount
    {
        get => isManaged ? managed.VisualisationRayCount : native.VisualisationRayCount;
        set
        {
            if (isManaged)
                managed.VisualisationRayCount = value;
            else
                native.VisualisationRayCount = value;
        }
    }

    /// <summary>Number of bounces per visualisation ray</summary>
    public int VisualisationBounceCount
    {
        get => isManaged ? managed.VisualisationBounceCount : native.VisualisationBounceCount;
        set
        {
            if (isManaged)
                managed.VisualisationBounceCount = value;
            else
                native.VisualisationBounceCount = value;
        }
    }

    /// <summary>How often (in milliseconds) to cast visualisation rays</summary>
    public int VisualisationUpdateFrequency
    {
        get => isManaged ? managed.VisualisationUpdateFrequency : native.VisualisationUpdateFrequency;
        set
        {
            if (isManaged)
                managed.VisualisationUpdateFrequency = value;
            else
                native.VisualisationUpdateFrequency = value;
        }
    }

    /// <summary>Whether this emitter casts any rays (excluding visualisation rays)</summary>
    public bool CreatesTrails => isManaged ? managed.CreatesTrails : native.CreatesTrails;

    /// <summary>
    /// Whether this emitter is within World.Position and World.MaxBounds.<br/>
    /// Emitters outside the world bounds will not be raytraced. Set ClampPosition to true to keep this emitter within the world bounds.<br/>
    /// If ClampPosition is false and any of the OverridePositions are outside the world bounds, this emitter is also outside the world bounds.
    /// </summary>
    public bool WithinWorldBounds => isManaged ? managed.WithinWorldBounds : native.WithinWorldBounds;

    /// <summary>The number of trails that will be created for this emitter</summary>
    public int TrailCount => isManaged ? managed.TrailCount : native.TrailCount;
    /// <summary>The number of bounces per trail</summary>
    public int TrailBounceCount => isManaged ? managed.TrailBounceCount : native.TrailBounceCount;

    /// <summary>True if both ReverbRayCount and ReverbBounceCount are greater than zero</summary>
    public bool ReverbEnabled => isManaged ? managed.ReverbEnabled : native.ReverbEnabled;
    /// <summary>True if both OcclusionRayCount and OcclusionBounceCount are greater than zero</summary>
    public bool OcclusionEnabled => isManaged ? managed.OcclusionEnabled : native.OcclusionEnabled;
    /// <summary>True if both PermeationRayCount and PermeationBounceCount are greater than zero</summary>
    public bool PermeationEnabled => isManaged ? managed.PermeationEnabled : native.PermeationEnabled;
    /// <summary>True if both AmbientOcclusionRayCount and AmbientOcclusionBounceCount are greater than zero</summary>
    public bool AmbientOcclusionEnabled => isManaged ? managed.AmbientOcclusionEnabled : native.AmbientOcclusionEnabled;
    /// <summary>True if both AmbientPermeationRayCount and AmbientPermeationBounceCount are greater than zero</summary>
    public bool AmbientPermeationEnabled => isManaged ? managed.AmbientPermeationEnabled : native.AmbientPermeationEnabled;
    /// <summary>True if both VisualisationRayCount and VisualisationBounceCount are greater than zero, and VisualisationCallback is assigned</summary>
    public bool VisualisationEnabled => isManaged ? managed.VisualisationEnabled : native.VisualisationEnabled;

    /// <summary>How long (in milliseconds) the echogram records data for. Returning reverb rays after this period will be ignored</summary>
    public int MaxEchogramTime
    {
        get => isManaged ? managed.MaxEchogramTime : native.MaxEchogramTime;
        set
        {
            if (isManaged)
                managed.MaxEchogramTime = value;
            else
                native.MaxEchogramTime = value;
        }
    }

    /// <summary>The length (in milliseconds) of each entry in the echogram</summary>
    public int EchogramGranularity
    {
        get => isManaged ? managed.EchogramGranularity : native.EchogramGranularity;
        set
        {
            if (isManaged)
                managed.EchogramGranularity = value;
            else
                native.EchogramGranularity = value;
        }
    }

    /// <summary>
    /// Controls the number of trails that are 'refreshed' each frame.<br/>
    /// Refreshing a trail involves re-casting the first ray, and if it hits a different position than last time, the entire trail will be trimmed and recalculated.<br/>
    /// RefreshDistanceThreshold controls the allowed distance between new and old bounce positions.
    /// </summary>
    public int TrailRefreshCount
    {
        get => isManaged ? managed.TrailRefreshCount : native.TrailRefreshCount;
        set
        {
            if (isManaged)
                managed.TrailRefreshCount = value;
            else
                native.TrailRefreshCount = value;
        }
    }

    /// <summary>The allowed distance between new and old bounce positions when refreshing trails. See TrailRefreshCount for more information.</summary>
    public float RefreshDistanceThreshold
    {
        get => isManaged ? managed.RefreshDistanceThreshold : native.RefreshDistanceThreshold;
        set
        {
            if (isManaged)
                managed.RefreshDistanceThreshold = value;
            else
                native.RefreshDistanceThreshold = value;
        }
    }

    /// <summary>The percentage of returning energy required for reverb to be at full volume.</summary>
    public float ReverbEnergyCap
    {
        get => isManaged ? managed.ReverbEnergyCap : native.ReverbEnergyCap;
        set
        {
            if (isManaged)
                managed.ReverbEnergyCap = value;
            else
                native.ReverbEnergyCap = value;
        }
    }

    /// <summary>The percentage of occlusion energy required for this emitter to be at full volume. Defaults to 15% of the other emitter's OcclusionRayCount. This field does nothing if a custom GainFormula is provided.</summary>
    public float OcclusionEnergyCap
    {
        get => isManaged ? managed.OcclusionEnergyCap : native.OcclusionEnergyCap;
        set
        {
            if (isManaged)
                managed.OcclusionEnergyCap = value;
            else
                native.OcclusionEnergyCap = value;
        }
    }

    /// <summary>
    /// The percentage of permeation energy required for this emitter to be at full volume. Defaults to 15% of the other emitter's PermeationRayCount * PermeationBounceCount.<br/>
    /// This field does nothing if a custom GainFormula is provided.
    /// </summary>
    public float PermeationEnergyCap
    {
        get => isManaged ? managed.PermeationEnergyCap : native.PermeationEnergyCap;
        set
        {
            if (isManaged)
                managed.PermeationEnergyCap = value;
            else
                native.PermeationEnergyCap = value;
        }
    }

    /// <summary>The percentage of occlusion energy required for ambience to be at full volume.</summary>
    public float AmbientOcclusionEnergyCap
    {
        get => isManaged ? managed.AmbientOcclusionEnergyCap : native.AmbientOcclusionEnergyCap;
        set
        {
            if (isManaged)
                managed.AmbientOcclusionEnergyCap = value;
            else
                native.AmbientOcclusionEnergyCap = value;
        }
    }

    /// <summary>The percentage of permeation energy required for ambience to be at full volume.</summary>
    public float AmbientPermeationEnergyCap
    {
        get => isManaged ? managed.AmbientPermeationEnergyCap : native.AmbientPermeationEnergyCap;
        set
        {
            if (isManaged)
                managed.AmbientPermeationEnergyCap = value;
            else
                native.AmbientPermeationEnergyCap = value;
        }
    }

    /// <summary>The loudest linear volume (0–1) this emitter's dry source will ever be played at by the consuming application. Used to estimate how long the emitter's reverb tail stays audible in EAXUtils.GetEffectiveTailSeconds - a quieter source reaches an inaudible reverb tail sooner.</summary>
    public float MaxVolume
    {
        get => isManaged ? managed.MaxVolume : native.MaxVolume;
        set
        {
            if (isManaged)
                managed.MaxVolume = value;
            else
                native.MaxVolume = value;
        }
    }

    /// <summary>Optimisation field - permeation rays will stop bouncing when their energy drops below this threshold</summary>
    public float MinimumPermeationEnergy
    {
        get => isManaged ? managed.MinimumPermeationEnergy : native.MinimumPermeationEnergy;
        set
        {
            if (isManaged)
                managed.MinimumPermeationEnergy = value;
            else
                native.MinimumPermeationEnergy = value;
        }
    }

    /// <summary>Optimisation field - reverb rays will stop bouncing when their energy drops below this threshold</summary>
    public float MinimumReverbEnergy
    {
        get => isManaged ? managed.MinimumReverbEnergy : native.MinimumReverbEnergy;
        set
        {
            if (isManaged)
                managed.MinimumReverbEnergy = value;
            else
                native.MinimumReverbEnergy = value;
        }
    }

    /// <summary>Optimisation field - occlusion rays will stop bouncing when their low-frequency energy drops below this threshold</summary>
    public float MinimumOcclusionEnergy
    {
        get => isManaged ? managed.MinimumOcclusionEnergy : native.MinimumOcclusionEnergy;
        set
        {
            if (isManaged)
                managed.MinimumOcclusionEnergy = value;
            else
                native.MinimumOcclusionEnergy = value;
        }
    }

    /// <summary>Optimisation field - ambient permeation rays will stop permeating when their energy drops below this threshold</summary>
    public float MinimumAmbientPermeationEnergy
    {
        get => isManaged ? managed.MinimumAmbientPermeationEnergy : native.MinimumAmbientPermeationEnergy;
        set
        {
            if (isManaged)
                managed.MinimumAmbientPermeationEnergy = value;
            else
                native.MinimumAmbientPermeationEnergy = value;
        }
    }

    /// <summary>Optimisation field - ambient occlusion rays will stop bouncing when their low-frequency energy drops below this threshold</summary>
    public float MinimumAmbientOcclusionEnergy
    {
        get => isManaged ? managed.MinimumAmbientOcclusionEnergy : native.MinimumAmbientOcclusionEnergy;
        set
        {
            if (isManaged)
                managed.MinimumAmbientOcclusionEnergy = value;
            else
                native.MinimumAmbientOcclusionEnergy = value;
        }
    }

    /// <summary>
    /// Seed used to randomise scattering vectors.<br/>
    /// Warning: changing this at runtime will clear the ray cache.
    /// </summary>
    public int ScatteringSeed
    {
        get => isManaged ? managed.ScatteringSeed : native.ScatteringSeed;
        set
        {
            if (isManaged)
                managed.ScatteringSeed = value;
            else
                native.ScatteringSeed = value;
        }
    }

    /// <summary>Seed used to randomise visualisation rays. If null, a random visualisation seed is generated each time</summary>
    public int? VisualisationSeed
    {
        get => isManaged ? managed.VisualisationSeed : native.VisualisationSeed;
        set
        {
            if (isManaged)
                managed.VisualisationSeed = value;
            else
                native.VisualisationSeed = value;
        }
    }

    public void AddTarget(Emitter target)
    {
        if (isManaged)
            managed.AddTarget(target.managed);
        else
            native.AddTarget(target.native);
    }

    public void RemoveTarget(Emitter target)
    {
        if (isManaged)
            managed.RemoveTarget(target.managed);
        else
            native.RemoveTarget(target.native);
    }

    public bool HasTarget(Emitter target)
    {
        if (isManaged)
            return managed.HasTarget(target.managed);
        else
            return native.HasTarget(target.native);
    }

    public bool HasRaytracedTarget(Emitter target)
    {
        if (isManaged)
            return managed.HasRaytracedTarget(target.managed);
        else
            return native.HasRaytracedTarget(target.native);
    }

    public LowPassFilter GetTargetFilter(Emitter target)
    {
        if (isManaged)
            return new LowPassFilter(managed.GetTargetFilter(target.managed));
        else
            return new LowPassFilter(native.GetTargetFilter(target.native));
    }

    public void ResetTrails()
    {
        if (isManaged)
            managed.ResetTrails();
        else
            native.ResetTrails();
    }

    /// <summary>This callback is invoked when this emitter has cast its reverb and ambient rays for the first time.</summary>
    public Action OnRaytracingComplete
    {
        set
        {
            if (isManaged)
            {
                managed.OnRaytracingComplete = value;
            }
            else
            {
                native.OnRaytracingComplete = value;
            }
        }
    }

    /// <summary>
    /// This callback is invoked once this emitter has been removed from the World and the raytracing threads no longer read it.<br/>
    /// It's invoked inside World.Update or World.Wait once the next raytracing results are handled, inside World.RemoveEmitter if no raytracing results are pending, or inside World.Dispose. If it casts reverb rays and AffectsGroupedEAX is true, removal itself waits until its reverb tail finishes playing, and during that time PendingRemoval is set to true.<br/>
    /// The callback is cleared once invoked. If the emitter is re-added to the same world before then, it isn't invoked, and is kept for the next removal.
    /// </summary>
    public Action OnRemoved
    {
        set
        {
            if (isManaged)
            {
                managed.OnRemoved = value;
            }
            else
            {
                native.OnRemoved = value;
            }
        }
    }

    /// <summary>
    /// This callback is invoked when another emitter raytraces this emitter for the first time.<br/>
    /// The first argument is the other emitter that raytraced this emitter.
    /// </summary>
    public Action<Emitter> OnRaytracedByAnotherEmitter
    {
        set
        {
            if (isManaged)
            {
                if (value != null)
                    managed.OnRaytracedByAnotherEmitter = (e) => value.Invoke(new Emitter(e));
                else
                    managed.OnRaytracedByAnotherEmitter = null;
            }
            else
            {
                if (value != null)
                    native.OnRaytracedByAnotherEmitter = (e) => value.Invoke(new Emitter(e));
                else
                    native.OnRaytracedByAnotherEmitter = null;
            }
        }
    }

    public Func<bool, int, int, int, float, float, float> GainFormula
    {
        set
        {
            if (isManaged)
                managed.GainFormula = value;
            else
                native.GainFormula = value;
        }
    }

    public Func<bool, int, int, int, float, float, float> AmbientGainFormula
    {
        set
        {
            if (isManaged)
                managed.AmbientGainFormula = value;
            else
                native.AmbientGainFormula = value;
        }
    }

    /// <summary>A custom log callback. Defaults to Console.WriteLine()</summary>
    public Action<string> LogCallback
    {
        set
        {
            if (isManaged)
                managed.LogCallback = value;
            else
                native.LogCallback = value;

        }
    }

    /// <summary>A custom error log callback. Defaults to Console.Error.WriteLine()</summary>
    public Action<string> LogErrorCallback
    {
        set
        {
            if (isManaged)
                managed.LogErrorCallback = value;
            else
                native.LogErrorCallback = value;
        }
    }

    /// <summary>The color of ray trails in the debug window (dev build only)</summary>
    public vaudio.Color TrailColor
    {
        get => isManaged ? managed.TrailColor : ToDotnet(native.TrailColor);
        set
        {
            if (isManaged)
                managed.TrailColor = value;
            else
                native.TrailColor = ToNative(value);
        }
    }

    /// <summary>The color of reverb rays in the debug window (dev build only)</summary>
    public vaudio.Color ReverbColor
    {
        get => isManaged ? managed.ReverbColor : ToDotnet(native.ReverbColor);
        set
        {
            if (isManaged)
                managed.ReverbColor = value;
            else
                native.ReverbColor = ToNative(value);
        }
    }

    /// <summary>The color of occlusion rays in the debug window (dev build only)</summary>
    public vaudio.Color OcclusionColor
    {
        get => isManaged ? managed.OcclusionColor : ToDotnet(native.OcclusionColor);
        set
        {
            if (isManaged)
                managed.OcclusionColor = value;
            else
                native.OcclusionColor = ToNative(value);
        }
    }

    /// <summary>The color of permeation rays in the debug window (dev build only)</summary>
    public vaudio.Color PermeationColor
    {
        get => isManaged ? managed.PermeationColor : ToDotnet(native.PermeationColor);
        set
        {
            if (isManaged)
                managed.PermeationColor = value;
            else
                native.PermeationColor = ToNative(value);
        }
    }

    /// <summary>The color of ambient permeation rays in the debug window (dev build only)</summary>
    public vaudio.Color AmbientPermeationColor
    {
        get => isManaged ? managed.AmbientPermeationColor : ToDotnet(native.AmbientPermeationColor);
        set
        {
            if (isManaged)
                managed.AmbientPermeationColor = value;
            else
                native.AmbientPermeationColor = ToNative(value);
        }
    }

    /// <summary>Whether to render each trail a different color in the debug window (dev build only)</summary>
    public bool RandomTrailColor
    {
        get => isManaged ? managed.RandomTrailColor : native.RandomTrailColor;
        set
        {
            if (isManaged)
                managed.RandomTrailColor = value;
            else
                native.RandomTrailColor = value;
        }
    }

    public Emitter(vaudio.Emitter managed)
    {
        this.managed = managed;
    }

    /// <summary>World-space position. Can be a Vector, FuncPosition, or any class that inherits from IPosition</summary>
    public vaudio.IPosition Position
    {
        get => isManaged ? managed.Position : ToDotnet(native.Position);
        set
        {
            if (isManaged)
                managed.Position = value;
            else
                native.Position = ToNative(value.GetPosition());
        }
    }

    /// <summary>
    /// When defined, rays will be cast in round-robin from these positions rather than the default Position.<br/>
    /// If any position is outside the world bounds and ClampPosition is true, they are clamped within the world bounds. If ClampPosition is false, a warning is logged and this emitter is treated as outside the world, see WithinWorldBounds.<br/>
    /// Set to null or an empty array to revert back to using the default Position.<br/>
    /// A copy of the provided array will be stored.<br/>
    /// Warning: changing this at runtime will clear the ray cache.
    /// </summary>
    public vaudio.Vector[] OverridePositions
    {
        set
        {
            if (isManaged)
                managed.OverridePositions = value;
            else
                native.OverridePositions = ToNative(value);
        }
    }

    /// <summary>
    /// When defined, rays will be cast in these directions rather than the default ray directions.<br/>
    /// Set to null or an empty array to revert back to using the default directions.<br/>
    /// A copy of the provided array will be stored.<br/>
    /// Warning: changing this at runtime will clear the ray cache.
    /// </summary>
    public vaudio.Vector[] OverrideRayDirections
    {
        set
        {
            if (isManaged)
                managed.OverrideRayDirections = value;
            else
                native.OverrideRayDirections = ToNative(value);
        }
    }

    public void SetOverridePositions(vaudio.Vector[] positions) => OverridePositions = positions;
    public void SetOverrideRayDirections(vaudio.Vector[] directions) => OverrideRayDirections = directions;

    /// <summary>This callback is invoked with the position and normal of each bounce of each visualisation ray. Do not modify the array or access it outside this callback.</summary>
    public Action<VisualisationData[]> VisualisationCallback
    {
        set
        {
            if (isManaged)
            {
                if (value != null)
                    managed.VisualisationCallback = (data) => value(Array.ConvertAll(data, d => new VisualisationData { Position = d.position, Normal = d.normal }));
                else
                    managed.VisualisationCallback = null;
            }
            else
            {
                if (value != null)
                    native.VisualisationCallback = (data) => value(Array.ConvertAll(data, d => new VisualisationData { Position = ToDotnet(d.position), Normal = ToDotnet(d.normal) }));
                else
                    native.VisualisationCallback = null;
            }
        }
    }

    /// <summary>
    /// Whether this emitter can share its rays with other nearby emitters that also have clustering enabled.<br/>
    /// A cluster casts its reverb, ambient occlusion, ambient permeation, occlusion and permeation rays outwards from each emitter in the cluster in round robin, and each emitter shares the same reverb, EAX and ambience results.<br/>
    /// The cluster uses the highest ray count, bounce count and MaxEchogramTime of its emitters. Its occlusion and permeation rays are cast towards the targets of every emitter in the cluster, and each emitter only gets low pass filters for its own targets.<br/>
    /// Emitters only cluster with others that are within line of sight and have the same EchogramGranularity, and never with their own targets. Emitters with OverridePositions or OverrideRayDirections set never cluster.
    /// </summary>
    public bool ClusteringEnabled
    {
        get => isManaged ? managed.ClusteringEnabled : native.ClusteringEnabled;
        set
        {
            if (isManaged)
                managed.ClusteringEnabled = value;
            else
                native.ClusteringEnabled = value;
        }
    }

    /// <summary>The maximum distance between this emitter and the centre of a cluster, for it to share that cluster's rays. If two emitters have different distances, the smaller one is used. Only used if ClusteringEnabled is true.</summary>
    public float ClusteringDistance
    {
        get => isManaged ? managed.ClusteringDistance : native.ClusteringDistance;
        set
        {
            if (isManaged)
                managed.ClusteringDistance = value;
            else
                native.ClusteringDistance = value;
        }
    }

    /// <summary>
    /// Whether this emitter groups its targets into clusters, to reduce the number of occlusion and permeation rays it casts.<br/>
    /// Within each cluster, this emitter casts occlusion and permeation rays towards the targets in the cluster in round robin, and each target gets the same low pass filter.<br/>
    /// This is set on the emitter that casts the rays (e.g. the listener), not on its targets. For sharing rays between emitters, see ClusteringEnabled.<br/>
    /// If this emitter is in a cluster with other emitters that have targets, its targets are only clustered if all of them have this enabled, using the smallest TargetClusteringDistance.
    /// </summary>
    public bool TargetClusteringEnabled
    {
        get => isManaged ? managed.TargetClusteringEnabled : native.TargetClusteringEnabled;
        set
        {
            if (isManaged)
                managed.TargetClusteringEnabled = value;
            else
                native.TargetClusteringEnabled = value;
        }
    }

    /// <summary>The maximum distance between two of this emitter's targets for them to be in the same cluster. Only used if TargetClusteringEnabled is true.</summary>
    public float TargetClusteringDistance
    {
        get => isManaged ? managed.TargetClusteringDistance : native.TargetClusteringDistance;
        set
        {
            if (isManaged)
                managed.TargetClusteringDistance = value;
            else
                native.TargetClusteringDistance = value;
        }
    }

}
