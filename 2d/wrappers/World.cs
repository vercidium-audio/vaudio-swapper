using System.Diagnostics;

namespace vaudioswapper;

public partial class World
{
    private Primitive ImportPrimitive(vaudio.Primitive e)
    {
        if (e is vaudio.LinePrimitive line)
            return new LinePrimitive(line);
        else if (e is vaudio.CirclePrimitive circle)
            return new CirclePrimitive(circle);
        else if (e is vaudio.OvalPrimitive oval)
            return new OvalPrimitive(oval);
        else if (e is vaudio.BoxPrimitive box)
            return new BoxPrimitive(box);
        else if (e is vaudio.PolygonPrimitive polygon)
            return new PolygonPrimitive(polygon);
        else if (e is vaudio.PathPrimitive path)
            return new PathPrimitive(path);
        else if (e is vaudio.GridPrimitive grid)
            return new GridPrimitive(grid);
        else
        {
            Debug.Assert(false);
            return null;
        }
    }

    public vaudio.Vector CalculateListenerRelativePan(vaudio.Vector worldVector, float listenerRotation)
    {
        if (isManaged)
            return managed.CalculateListenerRelativePan(worldVector, listenerRotation);
        else
            return ToDotnet(native.CalculateListenerRelativePan(ToNative(worldVector), listenerRotation));
    }

    public vaudio.Vector ConvertWorldToListenerDirection(vaudio.Vector worldDirection, float listenerRotation)
    {
        if (isManaged)
            return managed.ConvertWorldToListenerDirection(worldDirection, listenerRotation);
        else
            return ToDotnet(native.ConvertWorldToListenerDirection(ToNative(worldDirection), listenerRotation));
    }

    public vaudio.Vector ConvertListenerToWorldDirection(vaudio.Vector listenerDirection, float listenerRotation)
    {
        if (isManaged)
            return managed.ConvertListenerToWorldDirection(listenerDirection, listenerRotation);
        else
            return ToDotnet(native.ConvertListenerToWorldDirection(ToNative(listenerDirection), listenerRotation));
    }

    public float CameraRotation
    {
        get
        {
            return isManaged ? managed.CameraRotation : native.CameraRotation;
        }
        set
        {
            if (isManaged)
                managed.CameraRotation = value;
            else
                native.CameraRotation = value;
        }
    }

    public float CameraZoom
    {
        get
        {
            return isManaged ? managed.CameraZoom : native.CameraZoom;
        }
        set
        {
            if (isManaged)
                managed.CameraZoom = value;
            else
                native.CameraZoom = value;
        }
    }
}
