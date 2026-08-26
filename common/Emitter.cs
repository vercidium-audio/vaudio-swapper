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

    public bool Initialising
    {
        get => isManaged ? managed.Initialising : native.Initialising;
    }

    public bool PendingRemoval
    {
        get => isManaged ? managed.PendingRemoval : native.PendingRemoval;
    }

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

    public int GroupedEAXIndex => isManaged ? managed.GroupedEAXIndex : native.GroupedEAXIndex;

    public float OutsidePercent => isManaged ? managed.OutsidePercent : native.OutsidePercent;

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

    public int Type
    {
        get => isManaged ? managed.Type : native.Type;
        set
        {
            if (isManaged)
                managed.Type = value;
            else
                native.Type = value;
        }
    }

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

    public bool CastsRays => isManaged ? managed.CastsRays : native.CastsRays;

    public bool WithinWorldBounds => isManaged ? managed.WithinWorldBounds : native.WithinWorldBounds;

    public int TrailCount => isManaged ? managed.TrailCount : native.TrailCount;
    public int TrailBounceCount => isManaged ? managed.TrailBounceCount : native.TrailBounceCount;

    public bool ReverbEnabled => isManaged ? managed.ReverbEnabled : native.ReverbEnabled;
    public bool OcclusionEnabled => isManaged ? managed.OcclusionEnabled : native.OcclusionEnabled;
    public bool PermeationEnabled => isManaged ? managed.PermeationEnabled : native.PermeationEnabled;
    public bool AmbientOcclusionEnabled => isManaged ? managed.AmbientOcclusionEnabled : native.AmbientOcclusionEnabled;
    public bool AmbientPermeationEnabled => isManaged ? managed.AmbientPermeationEnabled : native.AmbientPermeationEnabled;
    public bool VisualisationEnabled => isManaged ? managed.VisualisationEnabled : native.VisualisationEnabled;

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

    public int RefreshRayCount
    {
        get => isManaged ? managed.RefreshRayCount : native.RefreshRayCount;
        set
        {
            if (isManaged)
                managed.RefreshRayCount = value;
            else
                native.RefreshRayCount = value;
        }
    }

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
}
