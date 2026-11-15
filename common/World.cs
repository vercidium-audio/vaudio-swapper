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

    /// <summary>This name is displayed in the debug window. Setting null stores an empty string.</summary>
    public string Name
    {
        get => isManaged ? managed.Name : native.Name;
        set
        {
            if (isManaged)
                managed.Name = value;
            else
                native.Name = value;
        }
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

    /// <summary>
    /// The size of the world.<br/>
    /// Emitters outside the world will not be raytraced, and Primitives that are fully outside these bounds will be ignored
    /// </summary>
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

    /// <summary>
    /// The minimum bounds of the world.<br/>
    /// Emitters outside the world will not be raytraced, and Primitives that are fully outside these bounds will not affect raytracing.
    /// </summary>
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

    /// <summary>The maximum bounds of the world (Position + Size)</summary>
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

    /// <summary>The average time (in milliseconds) spent by Update on the main thread. This includes time spent handling previous raytracing results, applying new settings, processing primitive updates and submitting work to background threads.</summary>
    public double MainThreadTime => isManaged ? managed.MainThreadTime : native.MainThreadTime;
    /// <summary>The average time (in milliseconds) spent in the preparation thread before the raytracing threads begin. This phase updates the BVH (Bounding Volume Hierarchy) acceleration structure with new, modified, and removed primitives. Higher values are a result of complex scene changes.</summary>
    public double PreparationTime => isManaged ? managed.PreparationTime : native.PreparationTime;
    /// <summary>
    /// The average time (in milliseconds) spent in the raytracing threads. This is the real-world elapsed time it takes for raytracing to complete, not the sum of all thread times.<br/>
    /// This value is automatically adjusted based on how many threads perform raytracing.<br/>
    /// Use this to monitor raytracing performance and adjust ray counts if needed.
    /// </summary>
    public double RaytracingTime => isManaged ? managed.RaytracingTime : native.RaytracingTime;
    /// <summary>
    /// The average time (in milliseconds) spent in the analysing thread after the raytracing threads complete. This phase runs after raytracing completes and calculate reverb properties.<br/>
    /// Use this to monitor raytracing performance and adjust ray counts if needed.
    /// </summary>
    public double AnalysisTime => isManaged ? managed.AnalysisTime : native.AnalysisTime;
    /// <summary>The average time (in milliseconds) between when Update is invoked, and when the OnReverbUpdated callback is invoked.</summary>
    public double Latency => isManaged ? managed.Latency : native.Latency;
    /// <summary>
    /// The average time (in milliseconds) between submitting work to the background thread pool and the first worker thread waking up. High values indicate thread wake-up / scheduling latency rather than raytracing work itself.<br/>
    /// Not available in the WASM build.
    /// </summary>
    public double SubmitToWakeTime => isManaged ? managed.SubmitToWakeTime : native.SubmitToWakeTime;
    /// <summary>
    /// The average time (in milliseconds) between the first worker thread waking up and the preparation work item (BVH build) finishing. This is the real-world elapsed time spent building/updating the BVH before emitter raytracing work is fanned out to other threads.<br/>
    /// Not available in the WASM build.
    /// </summary>
    public double WakeToFanoutTime => isManaged ? managed.WakeToFanoutTime : native.WakeToFanoutTime;
    /// <summary>
    /// The average time (in milliseconds) between the preparation work item fanning out emitter work, and the last fanned-out worker thread actually waking up to start it. High values indicate OS scheduling/wake latency across multiple threads, not time spent doing raytracing work.<br/>
    /// Not available in the WASM build.
    /// </summary>
    public double FanoutToLastWakeTime => isManaged ? managed.FanoutToLastWakeTime : native.FanoutToLastWakeTime;
    /// <summary>
    /// The average time (in milliseconds) between the last fanned-out worker thread waking up and the last emitter/visualisation work item completing. This isolates actual raytracing/visualisation work and work-queue contention from thread wake-up latency.<br/>
    /// Not available in the WASM build.
    /// </summary>
    public double LastWakeToWorkTime => isManaged ? managed.LastWakeToWorkTime : native.LastWakeToWorkTime;
    /// <summary>
    /// The average time (in milliseconds) spent executing the completion work item (reverb analysis) itself. This runs inline on whichever thread finishes the last emitter/visualisation work item, immediately after the last work item completes and before the completion event is released.<br/>
    /// Not available in the WASM build.
    /// </summary>
    public double CompletionWorkTime => isManaged ? managed.CompletionWorkTime : native.CompletionWorkTime;

    /// <summary>List of grouped EAX reverb properties for all emitters. Contains parameters compatible with EAX reverb effects.</summary>
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

    /// <summary>Whether Emitters outside the world have 0 occlusion/permeation energy (true) or maximum energy (false).</summary>
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

    /// <summary>The number of rays cast this frame.</summary>
    public int RaysCastThisFrame => managed?.RaysCastThisFrame ?? native.RaysCastThisFrame;

    /// <summary>The maximum number of grouped EAX reverb properties shared across all emitters that affect grouped EAX. Higher values increase accuracy but are more expensive to run.</summary>
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

    /// <summary>Whether occlusion rays should be affected by the world bounds material</summary>
    public bool OcclusionRaysLoseEnergyFromWorldBounds
    {
        get
        {
            if (isManaged)
                return managed.OcclusionRaysLoseEnergyFromWorldBounds;
            else
                return native.OcclusionRaysLoseEnergyFromWorldBounds;
        }
        set
        {
            if (isManaged)
                managed.OcclusionRaysLoseEnergyFromWorldBounds = value;
            else
                native.OcclusionRaysLoseEnergyFromWorldBounds = value;
        }
    }

    /// <summary>The number of work items to split trails across for load balancing. A higher value helps evenly distribute work across all threads.</summary>
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

    /// <summary>The maximum amount of threads that can run in parallel. On WASM all worlds share a single thread pool, so this is a global setting via ThreadSettings.MaximumConcurrencyLevel. The maximum amount of threads that can run in parallel for this world</summary>
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

    /// <summary>A custom logging callback. Defaults to Console.WriteLine()</summary>
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

    /// <summary>Meters per world unit. Affects air absorption and reverb calculation.</summary>
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

    /// <summary>Inverse speed of sound in seconds per meter. Affects reverb calculations.</summary>
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

    /// <summary>Low-frequency reference (Hz) for air absorption, reverb, and material scattering</summary>
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

    /// <summary>High-frequency reference (Hz) for air absorption, reverb, and material scattering</summary>
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

    /// <summary>Air absorption settings. Set to null to disable air absorption.</summary>
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

    public bool HasMaterial(vaudio.MaterialType type)
    {
        if (isManaged)
            return managed.HasMaterial(type);
        else
            return native.HasMaterial(ToNative(type));
    }

    /// <summary>This callback is invoked after EAX reverb results are updated. This gives you a chance to update your EAX effects, so they can be applied to an emitter in its Emitter.OnRaytracingComplete callback. After this, each emitter's callbacks are invoked, and then OnRaytracingResultsHandled is invoked.</summary>
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

    /// <summary>Whether to log memory allocation warnings.</summary>
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

    /// <summary>Whether to render the raytracing simulation in a separate window (dev build only)</summary>
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

    /// <summary>Whether the debug window can independently move its camera around (dev build only)</summary>
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

    /// <summary>The position of the camera in the debug window (dev build only)</summary>
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

    /// <summary>Whether to render rays in the debug window (dev build only)</summary>
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

    /// <summary>Whether to render primitives in the debug window (dev build only)</summary>
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

    /// <summary>The speed of the camera in the debug window (dev build only)</summary>
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

    /// <summary>Coordinate system used in the debug window and when calculating listener-relative reverb directionality</summary>
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

    /// <summary>The time spent (in milliseconds) rendering the debug window (dev build only)</summary>
    public double RenderTime
    {
        get => isManaged ? managed.RenderTime : native.RenderTime;
    }

    /// <summary>The position of the debug window (dev build only)</summary>
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

    /// <summary>The size of the debug window (dev build only)</summary>
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

    /// <summary>The size of visualisation rays in the debug window (dev build only)</summary>
    public float VisualisationScale
    {
        get => isManaged ? managed.VisualisationScale : native.VisualisationScale;
        set
        {
            if (isManaged)
                managed.VisualisationScale = value;
            else
                native.VisualisationScale = value;
        }
    }
}
