namespace vaudioswapper;

public class AirAbsorptionSettings
{
    public vaudionativewrapper.managed.AirAbsorptionSettings native;
    public vaudio.AirAbsorptionSettings managed;
    bool isManaged => managed != null;

    public AirAbsorptionSettings() : this(USE_NATIVE) { }

    public AirAbsorptionSettings(bool useNative)
    {
        if (useNative)
            native = new();
        else
            managed = new();
    }

    public AirAbsorptionSettings(vaudio.AirAbsorptionSettings managed)
    {
        this.managed = managed;
    }

    public AirAbsorptionSettings(vaudionativewrapper.managed.AirAbsorptionSettings native)
    {
        this.native = native;
    }

    public void Destroy()
    {
            native?.Destroy();
    }

    public float Humidity
    {
        get => isManaged ? managed.Humidity : native.Humidity;
        set
        {
            if (isManaged)
                managed.Humidity = value;
            else
                native.Humidity = value;
        }
    }

    public float Temperature
    {
        get => isManaged ? managed.Temperature : native.Temperature;
        set
        {
            if (isManaged)
                managed.Temperature = value;
            else
                native.Temperature = value;
        }
    }

    public float Pressure
    {
        get => isManaged ? managed.Pressure : native.Pressure;
        set
        {
            if (isManaged)
                managed.Pressure = value;
            else
                native.Pressure = value;
        }
    }

    public vaudionativewrapper.AirAbsorptionFormulaDelegate SetCustomFormulaLF(Func<float, float> value)
    {
        if (isManaged)
        {
            managed.CustomFormulaLF = value;
            return null;
        }

        return native.SetCustomFormulaLF(value);
    }

    public vaudionativewrapper.AirAbsorptionFormulaDelegate SetCustomFormulaHF(Func<float, float> value)
    {
        if (isManaged)
        {
            managed.CustomFormulaHF = value;
            return null;
        }

        return native.SetCustomFormulaHF(value);
    }
}
