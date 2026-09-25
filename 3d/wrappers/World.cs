using System.Diagnostics;

namespace vaudioswapper;

public partial class World
{
    vaudio.UnsafeVoxelMaterialMap unsafeVoxelMaterialMap;
    NativeUnsafeVoxelMaterialMap nativeUnsafeVoxelMaterialMap;

    // Lets one managed map drive both SDKs
    unsafe sealed class NativeUnsafeVoxelMaterialMap(vaudio.UnsafeVoxelMaterialMap map) : vaudionativewrapper.managed.UnsafeVoxelMaterialMap
    {
        public readonly vaudio.UnsafeVoxelMaterialMap map = map;

        public override vaudionativewrapper.MaterialType GetMaterial(void* voxel) => ToNative(map.GetMaterial(voxel));

        public override bool IsSolid(void* voxel) => map.IsSolid(voxel);
    }

    public vaudio.UnsafeVoxelMaterialMap UnsafeVoxelMaterialMap
    {
        get => unsafeVoxelMaterialMap;
        set
        {
            if (isManaged)
                managed.UnsafeVoxelMaterialMap = value;
            else
            {
                // Reuse the adapter when re-assigning the same map, so the native wrapper re-sends rather than creating a new callback
                if (value == null)
                    nativeUnsafeVoxelMaterialMap = null;
                else if (nativeUnsafeVoxelMaterialMap?.map != value)
                    nativeUnsafeVoxelMaterialMap = new(value);

                native.UnsafeVoxelMaterialMap = nativeUnsafeVoxelMaterialMap;
            }

            unsafeVoxelMaterialMap = value;
        }
    }

    private Primitive ImportPrimitive(vaudio.Primitive e)
    {
        if (e is vaudio.PrismPrimitive p)
            return new PrismPrimitive(p);
        else if (e is vaudio.SpherePrimitive s)
            return new SpherePrimitive(s);
        else if (e is vaudio.CylinderPrimitive c)
            return new CylinderPrimitive(c);
        else if (e is vaudio.CapsulePrimitive ca)
            return new CapsulePrimitive(ca);
        else if (e is vaudio.MeshPrimitive m)
            return new MeshPrimitive(m);
        else if (e is vaudio.ConePrimitive cone)
            return new ConePrimitive(cone);
        else if (e is vaudio.RectangularConePrimitive rectCcone)
            return new RectangularConePrimitive(rectCcone);
        else if (e is vaudio.TriangularConePrimitive triCone)
            return new TriangularConePrimitive(triCone);
        else if (e is vaudio.TriangularPrismPrimitive triPrism)
            return new TriangularPrismPrimitive(triPrism);
        else if (e is vaudio.HemispherePrimitive hemisphere)
            return new HemispherePrimitive(hemisphere);
        else if (e is vaudio.VoxelPrimitive v)
            return new VoxelPrimitive(v);
        else if (e is vaudio.TrianglePrimitive tri)
            return new TrianglePrimitive(tri);
        else if (e is vaudio.DiskPrimitive disk)
            return new DiskPrimitive(disk);
        else if (e is vaudio.PlanePrimitive plane)
            return new PlanePrimitive(plane);
        else
        {
            Debug.Assert(false);
            return null;
        }
    }

    public vaudio.Vector CalculateListenerRelativePan(vaudio.Vector worldVector, float listenerPitch, float listenerYaw)
    {
        if (isManaged)
            return managed.CalculateListenerRelativePan(worldVector, listenerPitch, listenerYaw);
        else
            return ToDotnet(native.CalculateListenerRelativePan(ToNative(worldVector), listenerPitch, listenerYaw));
    }

    public vaudio.Vector ConvertWorldToListenerDirection(vaudio.Vector worldDirection, float listenerPitch, float listenerYaw)
    {
        if (isManaged)
            return managed.ConvertWorldToListenerDirection(worldDirection, listenerPitch, listenerYaw);
        else
            return ToDotnet(native.ConvertWorldToListenerDirection(ToNative(worldDirection), listenerPitch, listenerYaw));
    }

    public vaudio.Vector ConvertListenerToWorldDirection(vaudio.Vector listenerDirection, float listenerPitch, float listenerYaw)
    {
        if (isManaged)
            return managed.ConvertListenerToWorldDirection(listenerDirection, listenerPitch, listenerYaw);
        else
            return ToDotnet(native.ConvertListenerToWorldDirection(ToNative(listenerDirection), listenerPitch, listenerYaw));
    }

    public float CameraPitch
    {
        get
        {
            return isManaged ? managed.CameraPitch : native.CameraPitch;
        }
        set
        {
            if (isManaged)
                managed.CameraPitch = value;
            else
                native.CameraPitch = value;
        }
    }

    public float CameraYaw
    {
        get
        {
            return isManaged ? managed.CameraYaw : native.CameraYaw;
        }
        set
        {
            if (isManaged)
                managed.CameraYaw = value;
            else
                native.CameraYaw = value;
        }
    }

    public float FieldOfView
    {
        get
        {
            return isManaged ? managed.FieldOfView : native.FieldOfView;
        }
        set
        {
            if (isManaged)
                managed.FieldOfView = value;
            else
                native.FieldOfView = value;
        }
    }
}
