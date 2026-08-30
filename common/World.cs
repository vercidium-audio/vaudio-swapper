namespace vaudioswapper;

public partial class World
{
    public bool isManaged => native == null;
    public vaudionativewrapper.managed.World native;
    public vaudio.World managed;

    public World() : this(USE_NATIVE) { }

    public World(bool useNative)
    {
        if (useNative)
            native = new();
        else
            managed = new();
    }

    public void Destroy()
    {
        if (isManaged)
            managed.Dispose();
        else
            native.Destroy();
    }

    public void Update()
    {
        if (isManaged)
            managed.Update();
        else
            native.Update();
    }

    public void Wait()
    {
        if (isManaged)
            managed.Wait();
        else
            native.Wait();
    }

    public void Export(string fileName)
    {
        if (isManaged)
            managed.Export(fileName);
        else
            native.Export(fileName);
    }

    public void Import(string fileName, out List<Emitter> emitters, out List<Primitive> primitives)
    {
        emitters = [];
        primitives = [];

        if (isManaged)
        {
            managed.Import(fileName, out var vaEmitters, out var vaPrimitives);

            foreach (var e in vaEmitters)
                emitters.Add(new(e));

            foreach (var e in vaPrimitives)
                primitives.Add(ImportPrimitive(e));
        }
        else
        {
            native.Import(fileName, out var vaEmitters);

            foreach (var e in vaEmitters)
                emitters.Add(new(e));
        }
    }

    public void AddMaterial(vaudio.MaterialType type, vaudio.MaterialProperties material, vaudio.Color color)
    {
        if (isManaged)
            managed.AddMaterial(type, material, color);
        else
        {
            var nativeMaterial = native.CreateMaterial((vaudionativewrapper.MaterialType)type);

            // Must set these AFTER adding it to the world, since we use vaWorldMaterial* calls to edit the material
            nativeMaterial.AbsorptionLF = material.AbsorptionLF;
            nativeMaterial.AbsorptionHF = material.AbsorptionHF;
            nativeMaterial.Scattering = material.Scattering;
            nativeMaterial.TransmissionLF = material.TransmissionLF;
            nativeMaterial.TransmissionHF = material.TransmissionHF;
            nativeMaterial.FlatTransmissionLF = material.FlatTransmissionLF;
            nativeMaterial.FlatTransmissionHF = material.FlatTransmissionHF;

            native.SetMaterialColor((int)type, new vaudionativewrapper.Color(color.R, color.G, color.B, color.A));
        }
    }

    public void SetMaterialColor(vaudio.MaterialType type, vaudio.Color color)
    {
        if (isManaged)
        {
            managed.SetMaterialColor(type, color);
        }
        else
        {
            native.SetMaterialColor((int)ToNative(type), ToNative(color));
        }
    }

    public vaudio.Color GetMaterialColor(vaudio.MaterialType type)
    {
        if (isManaged)
            return managed.GetMaterialColor(type);
        else
            return ToDotnet(native.GetMaterialColor((int)ToNative(type)));
    }

    public void AddPrimitive(Primitive primitive)
    {
        if (isManaged)
            managed.AddPrimitive(primitive.managed);
        else
            native.AddPrimitive(primitive.native);
    }

    public void RemovePrimitive(Primitive primitive)
    {
        if (isManaged)
            managed.RemovePrimitive(primitive.managed);
        else
            native.RemovePrimitive(primitive.native);
    }

    public Emitter AddEmitter(Emitter emitter)
    {
        if (isManaged)
            managed.AddEmitter(emitter.managed);
        else
            native.AddEmitter(emitter.native);

        return emitter;
    }

    public void RemoveEmitter(Emitter emitter)
    {
        if (isManaged)
            managed.RemoveEmitter(emitter.managed);
        else
            native.RemoveEmitter(emitter.native);
    }

    public int GetEmitterCount()
    {
        if (isManaged)
        {
#if FALSE
            return managed.Emitters.Count;
#else
    return 0;
#endif
        }
        else
            return native.GetEmitterCount();
    }

    public vaudio.Vector Size
    {
        get => isManaged ? managed.Size : ToDotnet(native.Size);
        set
        {
            if (isManaged)
                managed.Size = value;
            else
                native.Size = ToNative(value);
        }
    }

    public vaudio.Vector Position
    {
        get => isManaged ? managed.Position : ToDotnet(native.Position);
        set
        {
            if (isManaged)
                managed.Position = value;
            else
                native.Position = ToNative(value);
        }
    }

    public vaudio.Vector MaxBounds
    {
        get => isManaged ? managed.MaxBounds : ToDotnet(native.MaxBounds);
        set
        {
            if (isManaged)
                managed.MaxBounds = value;
            else
                native.MaxBounds = ToNative(value);
        }
    }

    public double MainThreadTime => isManaged ? managed.MainThreadTime : native.MainThreadTime;
    public double PreparationTime => isManaged ? managed.PreparationTime : native.PreparationTime;
    public double RaytracingTime => isManaged ? managed.RaytracingTime : native.RaytracingTime;
    public double AnalysisTime => isManaged ? managed.AnalysisTime : native.AnalysisTime;
    public double SubmitToWakeTime => isManaged ? managed.SubmitToWakeTime : native.SubmitToWakeTime;
    public double WakeToFanoutTime => isManaged ? managed.WakeToFanoutTime : native.WakeToFanoutTime;
    public double FanoutToLastWakeTime => isManaged ? managed.FanoutToLastWakeTime : native.FanoutToLastWakeTime;
    public double LastWakeToWorkTime => isManaged ? managed.LastWakeToWorkTime : native.LastWakeToWorkTime;
    public double CompletionWorkTime => isManaged ? managed.CompletionWorkTime : native.CompletionWorkTime;

    public List<EAXReverb> GroupedEAX
    {
        get
        {
            List<EAXReverb> results = [];

            if (isManaged)
            {
                foreach (var thing in managed.GroupedEAX)
                    results.Add(new EAXReverb() { managed = thing });
            }
            else
            {
                foreach (var thing in native.GroupedEAX)
                    results.Add(new EAXReverb() { native = thing });
            }

            return results;
        }
    }

    public bool EmittersOutsideTheWorldAreMuffled
    {
        get => managed?.EmittersOutsideTheWorldAreMuffled ?? native.EmittersOutsideTheWorldAreMuffled;
        set
        {
            if (isManaged)
                managed.EmittersOutsideTheWorldAreMuffled = value;
            else
                native.EmittersOutsideTheWorldAreMuffled = value;
        }
    }

    public bool WorldIsIndoors
    {
        get => managed?.WorldIsIndoors ?? native.WorldIsIndoors;
        set
        {
            if (isManaged)
                managed.WorldIsIndoors = value;
            else
                native.WorldIsIndoors = value;
        }
    }

    public bool Initialising => managed?.Initialising ?? native.Initialising;

    public int RaysCastThisFrame => managed?.RaysCastThisFrame ?? native.RaysCastThisFrame;

    public int MaximumGroupedEAXCount
    {
        get
        {
            if (isManaged)
                return managed.MaximumGroupedEAXCount;
            else
                return native.MaximumGroupedEAXCount;
        }
        set
        {
            if (isManaged)
                managed.MaximumGroupedEAXCount = value;
            else
                native.MaximumGroupedEAXCount = value;
        }
    }

    public int WorkItemCount
    {
        get
        {
            if (isManaged)
                return managed.WorkItemCount;
            else
                return native.WorkItemCount;
        }
        set
        {
            if (isManaged)
                managed.WorkItemCount = value;
            else
                native.WorkItemCount = value;
        }
    }

    public int MaximumConcurrencyLevel
    {
        get
        {
            if (isManaged)
                return managed.MaximumConcurrencyLevel;
            else
                return native.MaximumConcurrencyLevel;
        }
        set
        {
            if (isManaged)
                managed.MaximumConcurrencyLevel = value;
            else
                native.MaximumConcurrencyLevel = value;
        }
    }

    public Action<string> LogCallback
    {
        set
        {
            if (isManaged)
                managed.LogCallback = value;
            else
                native.LogCallback = value;
        }
    }

    public float MetersPerUnit
    {
        get
        {
            if (isManaged)
                return managed.MetersPerUnit;
            else
                return native.MetersPerUnit;
        }
        set
        {
            if (isManaged)
                managed.MetersPerUnit = value;
            else
                native.MetersPerUnit = value;
        }
    }

    public float InverseSpeedOfSound
    {
        get
        {
            if (isManaged)
                return managed.InverseSpeedOfSound;
            else
                return native.InverseSpeedOfSound;
        }
        set
        {
            if (isManaged)
                managed.InverseSpeedOfSound = value;
            else
                native.InverseSpeedOfSound = value;
        }
    }

    public float ReferenceFrequencyLF
    {
        get
        {
            if (isManaged)
                return managed.ReferenceFrequencyLF;
            else
                return native.ReferenceFrequencyLF;
        }
        set
        {
            if (isManaged)
                managed.ReferenceFrequencyLF = value;
            else
                native.ReferenceFrequencyLF = value;
        }
    }

    public float ReferenceFrequencyHF
    {
        get
        {
            if (isManaged)
                return managed.ReferenceFrequencyHF;
            else
                return native.ReferenceFrequencyHF;
        }
        set
        {
            if (isManaged)
                managed.ReferenceFrequencyHF = value;
            else
                native.ReferenceFrequencyHF = value;
        }
    }

    public AirAbsorptionSettings AirAbsorption
    {
        get
        {
            return isManaged ? new AirAbsorptionSettings(managed.AirAbsorption) : new AirAbsorptionSettings(native.AirAbsorption);
        }
        set
        {
            if (isManaged)
                managed.AirAbsorption = value?.managed;
            else if (value == null)
                vaudionativewrapper.WorldBindings.SetAirAbsorption(native.native, IntPtr.Zero);
            else
                native.AirAbsorption = value.native;
        }
    }

    public vaudionativewrapper.managed.CustomEAXFormulaCallbacks UpdateCustomEAXFormulas(vaudio.CustomEAXFormulas formulas)
    {
        if (isManaged)
        {
            managed.CustomEAXFormulas = formulas;
            return null;
        }
        else
        {
            return native.UpdateCustomEAXFormulas(ToNative(formulas));
        }
    }

    public MaterialProperties GetMaterial(vaudio.MaterialType type)
    {
        if (isManaged)
            return new MaterialProperties() { managed = managed.GetMaterial(type) };
        else
            return new MaterialProperties() { native = native.GetMaterial(ToNative(type)) };
    }

    public Action OnReverbUpdated
    {
        set
        {
            if (isManaged)
                managed.OnReverbUpdated = value;
            else
                native.OnReverbUpdated = value;
        }
    }

    public void SetLogCallback(Action<string> callback)
    {
        if (isManaged)
            managed.LogCallback = callback;
        else
            native.LogCallback = callback;
    }

    public bool LogMemoryAllocationWarnings
    {
        get => isManaged ? managed.LogMemoryAllocationWarnings : native.LogMemoryAllocationWarnings;
        set
        {
            if (isManaged)
                managed.LogMemoryAllocationWarnings = value;
            else
                native.LogMemoryAllocationWarnings = value;
        }
    }

    public bool RenderingEnabled
    {
        get
        {
            return isManaged ? managed.RenderingEnabled : native.RenderingEnabled;
        }
        set
        {
            if (isManaged)
                managed.RenderingEnabled = value;
            else
                native.RenderingEnabled = value;
        }
    }

    public bool ManualCamera
    {
        get
        {
            return isManaged ? managed.ManualCamera : native.ManualCamera;
        }
        set
        {
            if (isManaged)
                managed.ManualCamera = value;
            else
                native.ManualCamera = value;
        }
    }

    public vaudio.Vector CameraPosition
    {
        get
        {
            return isManaged ? managed.CameraPosition : ToDotnet(native.CameraPosition);
        }
        set
        {
            if (isManaged)
                managed.CameraPosition = value;
            else
                native.CameraPosition = ToNative(value);
        }
    }

    public bool ShouldRenderRays
    {
        get
        {
            return isManaged ? managed.ShouldRenderRays : native.ShouldRenderRays;
        }
        set
        {
            if (isManaged)
                managed.ShouldRenderRays = value;
            else
                native.ShouldRenderRays = value;
        }
    }

    public bool ShouldRenderPrimitives
    {
        get
        {
            return isManaged ? managed.ShouldRenderPrimitives : native.ShouldRenderPrimitives;
        }
        set
        {
            if (isManaged)
                managed.ShouldRenderPrimitives = value;
            else
                managed.ShouldRenderPrimitives = value;
        }
    }

    public float CameraSpeed
    {
        get
        {
            return isManaged ? managed.CameraSpeed : native.CameraSpeed;
        }
        set
        {
            if (isManaged)
                managed.CameraSpeed = value;
            else
                native.CameraSpeed = value;
        }
    }

    public vaudio.CoordinateSystem CoordinateSystem
    {
        get
        {
            return isManaged ? managed.CoordinateSystem : (vaudio.CoordinateSystem)native.CoordinateSystem;
        }
        set
        {
            if (isManaged)
                managed.CoordinateSystem = value;
            else
                native.CoordinateSystem = (vaudionativewrapper.CoordinateSystem)value;
        }
    }

    public double RenderTime
    {
        get => isManaged ? managed.RenderTime : native.RenderTime;
    }

    public vaudio.UIVector WindowPosition
    {
        get =>  isManaged ? managed.WindowPosition : new(native.WindowPosition);
        set
        {
            if (isManaged)
                managed.WindowPosition = value;
            else
                native.WindowPosition = ((int)value.X, (int)value.Y);
        }
    }

    public vaudio.UIVector WindowSize
    {
        get => isManaged ? managed.WindowSize : new(native.WindowSize);
        set
        {
            if (isManaged)
                managed.WindowSize = value;
            else
                native.WindowSize = ((int)value.X, (int)value.Y);
        }
    }
}
