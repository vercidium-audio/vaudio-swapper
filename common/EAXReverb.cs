// Human-created

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

    /// <summary>Delay before early reflections are heard, in seconds (0–0.3)</summary>
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

    /// <summary>Modal density of the late reverberation (0–1)</summary>
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

    /// <summary>Echo diffusion of the late reverberation (0–1)</summary>
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

    /// <summary>Low-frequency gain of the reverb (0–1)</summary>
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

    /// <summary>High-frequency gain of the reverb (0–1)</summary>
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

    /// <summary>Overall linear gain of the reverb (0–1)</summary>
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

    /// <summary>Reverberation decay time at mid frequencies, in seconds (0.1–20)</summary>
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

    /// <summary>Ratio of low-frequency decay time to mid-frequency decay time (0.1–2)</summary>
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

    /// <summary>Ratio of high-frequency decay time to mid-frequency decay time (0.1–2)</summary>
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

    /// <summary>Linear gain of early reflections (0–3.16)</summary>
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

    /// <summary>Linear gain of late reverberation (0–10)</summary>
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

    /// <summary>Delay of late reverberation relative to early reflections, in seconds (0–0.1)</summary>
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

    /// <summary>Cycling time of the echo effect, in seconds (0.075–0.25)</summary>
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

    /// <summary>Amplitude of the echo effect (0–1)</summary>
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

    /// <summary>Cycling time of the modulation effect, in seconds (0.04–4)</summary>
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

    /// <summary>Amplitude of the modulation effect (0–1)</summary>
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

    /// <summary>Linear gain applied per meter of distance for high-frequency air absorption (0.892–1)</summary>
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

    /// <summary>Reference frequency for high-frequency decay ratio, in Hz (1000–20000)</summary>
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

    /// <summary>Reference frequency for low-frequency decay ratio, in Hz (20–1000)</summary>
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

    /// <summary>Rolloff factor for reflected sound sources (0–10)</summary>
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

    /// <summary>Whether to limit high-frequency decay time to the air absorption limit (0 or 1)</summary>
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
            return managed.HasRelativeResults(emitter.managed) ? managed.GetRelativeDirection(emitter.managed) : null;
        else
            return ToDotnet(native.GetRelativeDirection(emitter.native));
    }

    public float? GetRelativeGain(Emitter emitter)
    {
        if (isManaged)
            return managed.HasRelativeResults(emitter.managed) ? managed.GetRelativeGain(emitter.managed) : null;
        else
            return native.GetRelativeGain(emitter.native);
    }
}
