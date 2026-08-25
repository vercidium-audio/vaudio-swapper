using System.Runtime.InteropServices;

namespace vaudioswapper;

public unsafe class LowPassFilter
{
    public bool isManaged => native == null;
    public vaudionativewrapper.LowPassFilter* native;
    public vaudio.LowPassFilter managed;

    bool freeInFinaliser;

    public LowPassFilter(vaudionativewrapper.LowPassFilter* native)
    {
        this.native = native;
    }

    public LowPassFilter(vaudio.LowPassFilter managed)
    {
        this.managed = managed;
    }

    public LowPassFilter() : this(USE_NATIVE) { }

    public LowPassFilter(bool useNative)
    {
        if (USE_NATIVE)
        {
            native = (vaudionativewrapper.LowPassFilter*)NativeMemory.AllocZeroed((nuint)sizeof(vaudionativewrapper.LowPassFilter));
            freeInFinaliser = true;
        }
        else
            managed = new vaudio.LowPassFilter();
    }

    public bool Exists => isManaged ? managed != null : native != null;

    public float GainLF
    {
        get => isManaged ? managed.GainLF : native->gainLF;
        set
        {
            if (isManaged)
                managed.GainLF = value;
            else
                native->gainLF = value;
        }
    }

    public float GainHF
    {
        get => isManaged ? managed.GainHF : native->gainHF;
        set
        {
            if (isManaged)
                managed.GainHF = value;
            else
                native->gainHF = value;
        }
    }

    ~LowPassFilter()
    {
        if (freeInFinaliser)
        {
            NativeMemory.Free(native);
            native = null;
        }
    }
}
