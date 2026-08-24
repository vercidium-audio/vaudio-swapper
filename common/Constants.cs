global using static vaudioswapper.Constants;
using System.Runtime.CompilerServices;

namespace vaudioswapper;

internal static partial class Constants
{
    internal static vaudionativewrapper.MaterialType ToNative(vaudio.MaterialType v) => (vaudionativewrapper.MaterialType)v;
    internal static vaudio.MaterialType ToDotnet(vaudionativewrapper.MaterialType v) => (vaudio.MaterialType)v;

    internal static vaudionativewrapper.Vector[] ToNative(vaudio.Vector[] v) => Unsafe.As<vaudio.Vector[], vaudionativewrapper.Vector[]>(ref v);
    internal static vaudio.Vector[] ToDotnet(vaudionativewrapper.Vector[] v) => Unsafe.As<vaudionativewrapper.Vector[], vaudio.Vector[]>(ref v);

    internal static vaudionativewrapper.managed.MaterialProperties ToNative(nint world, int type, vaudio.MaterialProperties material)
    {
        return new vaudionativewrapper.managed.MaterialProperties(world, type)
        {
            AbsorptionLF = material.AbsorptionLF,
            AbsorptionHF = material.AbsorptionHF,
            Scattering = material.Scattering,
            TransmissionLF = material.TransmissionLF,
            TransmissionHF = material.TransmissionHF,
            FlatTransmissionLF = material.FlatTransmissionLF,
            FlatTransmissionHF = material.FlatTransmissionHF
        };
    }

    internal static vaudio.MaterialProperties ToDotnet(nint world, int type, vaudionativewrapper.managed.MaterialProperties material)
    {
        return new vaudio.MaterialProperties(
            material.AbsorptionLF,
            material.AbsorptionHF,
            material.Scattering,
            material.TransmissionLF,
            material.TransmissionHF,
            material.FlatTransmissionLF,
            material.FlatTransmissionHF
        );
    }

    internal static vaudionativewrapper.Color ToNative(vaudio.Color v) => new(v.R, v.G, v.B, v.A);
    internal static vaudio.Color ToDotnet(vaudionativewrapper.Color v) => new(v.R, v.G, v.B, v.A);

    internal static vaudionativewrapper.managed.CustomEAXFormulas ToNative(vaudio.CustomEAXFormulas material)
    {
        return new CustomEAXFormulasAdapter(material);
    }
}
