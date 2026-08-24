namespace vaudioswapper;

public class EAXReverb
{
    public bool isManaged => native == null;
    public vaudionativewrapper.managed.EAXReverb native;
    public vaudio.EAXReverb managed;

    public bool Exists
    {
        get
        {
            if (isManaged)
                return managed != null;

            return native != null;
        }
    }

    public float ReflectionsDelay
    {
        get
        {
            if (isManaged)
                return managed.ReflectionsDelay;
            else
                return native.ReflectionsDelay;
        }
    }

    public float Density
    {
        get
        {
            if (isManaged)
                return managed.Density;
            else
                return native.Density;
        }
    }

    public float Diffusion
    {
        get
        {
            if (isManaged)
                return managed.Diffusion;
            else
                return native.Diffusion;
        }
    }

    public float GainLF
    {
        get
        {
            if (isManaged)
                return managed.GainLF;
            else
                return native.GainLF;
        }
    }

    public float GainHF
    {
        get
        {
            if (isManaged)
                return managed.GainHF;
            else
                return native.GainHF;
        }
    }

    public float Gain
    {
        get
        {
            if (isManaged)
                return managed.Gain;
            else
                return native.Gain;
        }
    }

    public float DecayTime
    {
        get
        {
            if (isManaged)
                return managed.DecayTime;
            else
                return native.DecayTime;
        }
    }

    public float DecayLFRatio
    {
        get
        {
            if (isManaged)
                return managed.DecayLFRatio;
            else
                return native.DecayLFRatio;
        }
    }

    public float DecayHFRatio
    {
        get
        {
            if (isManaged)
                return managed.DecayHFRatio;
            else
                return native.DecayHFRatio;
        }
    }

    public float ReflectionsGain
    {
        get
        {
            if (isManaged)
                return managed.ReflectionsGain;
            else
                return native.ReflectionsGain;
        }
    }

    public float LateReverbGain
    {
        get
        {
            if (isManaged)
                return managed.LateReverbGain;
            else
                return native.LateReverbGain;
        }
    }

    public float LateReverbDelay
    {
        get
        {
            if (isManaged)
                return managed.LateReverbDelay;
            else
                return native.LateReverbDelay;
        }
    }

    public float EchoTime
    {
        get
        {
            if (isManaged)
                return managed.EchoTime;
            else
                return native.EchoTime;
        }
    }

    public float EchoDepth
    {
        get
        {
            if (isManaged)
                return managed.EchoDepth;
            else
                return native.EchoDepth;
        }
    }

    public float ModulationTime
    {
        get
        {
            if (isManaged)
                return managed.ModulationTime;
            else
                return native.ModulationTime;
        }
    }

    public float ModulationDepth
    {
        get
        {
            if (isManaged)
                return managed.ModulationDepth;
            else
                return native.ModulationDepth;
        }
    }

    public float AirAbsorptionGainHF
    {
        get
        {
            if (isManaged)
                return managed.AirAbsorptionGainHF;
            else
                return native.AirAbsorptionGainHF;
        }
    }

    public float HFReference
    {
        get
        {
            if (isManaged)
                return managed.HFReference;
            else
                return native.HFReference;
        }
    }

    public float LFReference
    {
        get
        {
            if (isManaged)
                return managed.LFReference;
            else
                return native.LFReference;
        }
    }

    public float RoomRolloffFactor
    {
        get
        {
            if (isManaged)
                return managed.RoomRolloffFactor;
            else
                return native.RoomRolloffFactor;
        }
    }

    public int DecayHFLimit
    {
        get
        {
            if (isManaged)
                return managed.DecayHFLimit;
            else
                return native.DecayHFLimit;
        }
    }

    public vaudio.Vector? GetRelativeDirection(Emitter emitter)
    {
        if (isManaged)
            return managed.RelativeDirections.TryGetValue(emitter.managed, out var v) ? v : null;
        else
            return ToDotnet(native.GetRelativeDirection(emitter.native));
    }

    public float? GetRelativeGain(Emitter emitter)
    {
        if (isManaged)
            return managed.RelativeGains.TryGetValue(emitter.managed, out var v) ? v : null;
        else
            return native.GetRelativeGain(emitter.native);
    }
}
