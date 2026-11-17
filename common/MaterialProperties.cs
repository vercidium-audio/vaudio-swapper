// Human-created

namespace vaudioswapper;

public class MaterialProperties
{
    public bool isManaged => native == null;
    public vaudionativewrapper.managed.MaterialProperties native;
    public vaudio.MaterialProperties managed;

    internal static MaterialProperties FromNative(IntPtr world, int id) => new() { native = new(world, id) };

    /// <summary>Percentage of low-frequency energy that is lost on each bounce</summary>
    public float AbsorptionLF
    {
        get => isManaged ? managed.AbsorptionLF : native.AbsorptionLF;
        set
        {
            if (isManaged)
                managed.AbsorptionLF = value;
            else
                native.AbsorptionLF = value;
        }
    }

    /// <summary>Percentage of high-frequency energy that is lost on each bounce</summary>
    public float AbsorptionHF
    {
        get => isManaged ? managed.AbsorptionHF : native.AbsorptionHF;
        set
        {
            if (isManaged)
                managed.AbsorptionHF = value;
            else
                native.AbsorptionHF = value;
        }
    }

    /// <summary>Scattering strength, where 0.0 has no scattering and 1.0 skews the reflected ray direction by up to 90 degrees</summary>
    public float Scattering
    {
        get => isManaged ? managed.Scattering : native.Scattering;
        set
        {
            if (isManaged)
                managed.Scattering = value;
            else
                native.Scattering = value;
        }
    }

    /// <summary>How many meters a ray must travel through a primitive before it loses all low-frequency energy</summary>
    public float TransmissionLF
    {
        get => isManaged ? managed.TransmissionLF : native.TransmissionLF;
        set
        {
            if (isManaged)
                managed.TransmissionLF = value;
            else
                native.TransmissionLF = value;
        }
    }

    /// <summary>How many meters a ray must travel through a primitive before it loses all high-frequency energy</summary>
    public float TransmissionHF
    {
        get => isManaged ? managed.TransmissionHF : native.TransmissionHF;
        set
        {
            if (isManaged)
                managed.TransmissionHF = value;
            else
                native.TransmissionHF = value;
        }
    }

    /// <summary>Percentage of low-frequency energy lost when a ray touches a primitive with Primitive.UseFlatTransmission set to true, instead of calculating how long the ray spent inside it</summary>
    public float FlatTransmissionLF
    {
        get => isManaged ? managed.FlatTransmissionLF : native.FlatTransmissionLF;
        set
        {
            if (isManaged)
                managed.FlatTransmissionLF = value;
            else
                native.FlatTransmissionLF = value;
        }
    }

    /// <summary>Percentage of high-frequency energy lost when a ray touches a primitive with Primitive.UseFlatTransmission set to true, instead of calculating how long the ray spent inside it</summary>
    public float FlatTransmissionHF
    {
        get => isManaged ? managed.FlatTransmissionHF : native.FlatTransmissionHF;
        set
        {
            if (isManaged)
                managed.FlatTransmissionHF = value;
            else
                native.FlatTransmissionHF = value;
        }
    }
}
