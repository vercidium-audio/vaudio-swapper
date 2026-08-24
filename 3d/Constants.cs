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