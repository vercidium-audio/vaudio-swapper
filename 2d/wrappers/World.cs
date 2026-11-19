// Human-created

using System.Diagnostics;

namespace vaudioswapper;

public partial class World
{
    Primitive ImportPrimitive(vaudio.Primitive e)
    {
        if (e is vaudio.LinePrimitive line)
            return new LinePrimitive(line);
        else if (e is vaudio.CirclePrimitive circle)
            return new CirclePrimitive(circle);
        else if (e is vaudio.OvalPrimitive oval)
            return new OvalPrimitive(oval);
        else if (e is vaudio.CapsulePrimitive capsule)
            return new CapsulePrimitive(capsule);
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

    /// <summary>Convert a rotation value to a listener-relative direction</summary>
    public vaudio.Vector CalculateListenerRelativePan(vaudio.Vector worldVector, float listenerRotation)
    {
        if (isManaged)
            return managed.CalculateListenerRelativePan(worldVector, listenerRotation);
        else
            return ToDotnet(native.CalculateListenerRelativePan(ToNative(worldVector), listenerRotation));
    }

    /// <summary>Convert a world-space direction to a listener-relative direction</summary>
    public vaudio.Vector ConvertWorldToListenerDirection(vaudio.Vector worldDirection, float listenerRotation)
    {
        if (isManaged)
            return managed.ConvertWorldToListenerDirection(worldDirection, listenerRotation);
        else
            return ToDotnet(native.ConvertWorldToListenerDirection(ToNative(worldDirection), listenerRotation));
    }

    /// <summary>Convert a listener-relative direction to a world-space direction</summary>
    public vaudio.Vector ConvertListenerToWorldDirection(vaudio.Vector listenerDirection, float listenerRotation)
    {
        if (isManaged)
            return managed.ConvertListenerToWorldDirection(listenerDirection, listenerRotation);
        else
            return ToDotnet(native.ConvertListenerToWorldDirection(ToNative(listenerDirection), listenerRotation));
    }

    /// <summary>The rotation of the camera in the debug window (dev build only)</summary>
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

    /// <summary>The zoom of the camera in the debug window (dev build only)</summary>
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
