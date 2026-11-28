# Vercidium Audio

This is a .NET 'swapper' that wraps both Vercidium Audio C# and C SDKs:
- Set `vaudioswapper.Settings.USE_NATIVE = false;` to use C#
- Set `vaudioswapper.Settings.USE_NATIVE = true;` to use C

## Setup

This repository requires:
- Vercidium Audio v1.12.0. Download it from [vercidium.com](https://vercidium.com)
- [vaudio-native-wrapper](https://github.com/vercidium-audio/vaudio-native-wrapper) must be cloned alongside this repository

> Please note that the Vercidium Audio SDK is not free for commercial use. See [vercidium.com/eula](https://vercidium.com/eula)

To use the C# SDK, copy `vaudio.dll` and `vaudio.xml` from the `dotnet/dev` folder in the Vercidium Audio SDK, to the `3d/lib` folder.

To use the native C SDK, ensure your project copies `vaudionative.dll` to your build folder.

To use the debug window with the dev SDK, ensure your project copies the files from the SDK's `3d/debug-window/{platform}` folder to your build folder, next to `vaudio.dll` and `vaudionative.dll`. Both C# and C SDKs use the same debug window.

## Features

- Muffle sounds in real time
- Accurate reverb in any environment
- Innovative event-based raytracing system
- Realistic energy-based model with materials
- Dynamic scene updates - automatically handles moving objects

## References
- [Vercidum Audio documentation](https://vercidium.com/docs)

## Licencing

The Vercidium Audio SDK is free for non-commercial products only. To purchase a licence for commercial use, head over to the [Vercidium Audio website](https://vercidium.com).
