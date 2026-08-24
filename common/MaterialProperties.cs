namespace vaudioswapper;

public class MaterialProperties
{
    public bool isManaged => native == null;
    public vaudionativewrapper.managed.MaterialProperties native;
    public vaudio.MaterialProperties managed;

    internal static MaterialProperties FromNative(IntPtr world, int id) => new() { native = new(world, id) };

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
