namespace vaudioswapper;

internal static partial class Constants
{
    internal static List<vaudionativewrapper.Vector> ToNative(List<vaudio.Vector> v) => v.ConvertAll(x => ToNative(x));
    internal static List<vaudio.Vector> ToDotnet(List<vaudionativewrapper.Vector> v) => v.ConvertAll(x => ToDotnet(x));

    internal static vaudionativewrapper.Vector ToNative(vaudio.Vector v) => new(v.X, v.Y);
    internal static vaudio.Vector ToDotnet(vaudionativewrapper.Vector v) => new(v.X, v.Y);

    internal static vaudionativewrapper.Vector? ToNative(vaudio.Vector? v) => v is vaudio.Vector vec ? new(vec.X, vec.Y) : null;
    internal static vaudio.Vector? ToDotnet(vaudionativewrapper.Vector? v) => v is vaudionativewrapper.Vector vec ? new(vec.X, vec.Y) : null;
}
