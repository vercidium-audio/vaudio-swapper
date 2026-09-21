using System.Runtime.CompilerServices;

namespace vaudioswapper;

internal static partial class Constants
{
    internal static List<vaudionativewrapper.Vector> ToNative(List<vaudio.Vector> v) => Unsafe.As<List<vaudio.Vector>, List<vaudionativewrapper.Vector>>(ref v);
    internal static List<vaudio.Vector> ToDotnet(List<vaudionativewrapper.Vector> v) => Unsafe.As<List<vaudionativewrapper.Vector>, List<vaudio.Vector>>(ref v);

    internal static vaudionativewrapper.Vector ToNative(vaudio.Vector v) => new(v.X, v.Y, v.Z);
    internal static vaudio.Vector ToDotnet(vaudionativewrapper.Vector v) => new(v.X, v.Y, v.Z);

    internal static vaudionativewrapper.Vector? ToNative(vaudio.Vector? v) => v is vaudio.Vector vec ? new(vec.X, vec.Y, vec.Z) : null;
    internal static vaudio.Vector? ToDotnet(vaudionativewrapper.Vector? v) => v is vaudionativewrapper.Vector vec ? new(vec.X, vec.Y, vec.Z) : null;

    internal static vaudionativewrapper.Matrix ToNative(vaudio.Matrix v) => Unsafe.As<vaudio.Matrix, vaudionativewrapper.Matrix>(ref v);
    internal static vaudio.Matrix ToDotnet(vaudionativewrapper.Matrix v) => Unsafe.As<vaudionativewrapper.Matrix, vaudio.Matrix>(ref v);
}

public static class VercidiumAudio
{
    public static bool IsProduction => USE_NATIVE ? vaudionativewrapper.VersionBindings.IsProduction() : vaudio.VercidiumAudio.IsProduction;

    public static int MajorVersion
    {
        get
        {
            if (USE_NATIVE)
            {
                vaudionativewrapper.VersionBindings.GetVersion(out int major, out _, out _);
                return major;
            }

            return vaudio.VercidiumAudio.MajorVersion;
        }
    }

    public static int MinorVersion
    {
        get
        {
            if (USE_NATIVE)
            {
                vaudionativewrapper.VersionBindings.GetVersion(out _, out int minor, out _);
                return minor;
            }

            return vaudio.VercidiumAudio.MinorVersion;
        }
    }

    public static int PatchVersion
    {
        get
        {
            if (USE_NATIVE)
            {
                vaudionativewrapper.VersionBindings.GetVersion(out _, out _, out int patch);
                return patch;
            }

            return vaudio.VercidiumAudio.PatchVersion;
        }
    }
}