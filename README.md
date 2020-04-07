# Integrating Unreal Engine 4 Project with CMake project and boost library

This repository is attachment to Quick Turn Studios's blog article:
[Integration Unreal Engine 4 with CMake project and boost library](https://quickturnstudio.com/ue4-cmake-project-boost-integration/)

## General requirements

* CMake at least in 3.10 version
* Boost library (tested on version 1.72)
* Unreal Engine (tested on version 4.24.3)

#### Installing CMake

Download and install
[CMake](https://github.com/Kitware/CMake/releases/download/v3.16.5/cmake-3.16.5-win64-x64.msi).
During installation choose to add CMake to environment PATH  variable. 

#### Installing MSVC

Download [Visual Studio](https://visualstudio.microsoft.com/pl/vs/older-downloads/)
(recommended Visual Studio 2017, you can find older versions on bottom).

In main screen of Visual Studio installer choose More->Import configuration and choose
`config/configurationFor2017.vsconfig` and then install.

#### Installing boost

Download boost 1.72 library from
[here](https://dl.bintray.com/boostorg/release/1.72.0/source/boost_1_72_0.7z).

Extract it and add path to this directory to environment variable PATH.

## Building

### Game Model

To compile game model project just use CMake.
Create folder and run `cmd.exe` or Git Bash inside that directory 

```cmd
cmake .. -G "Visual Studio 15 2017" -A x64 -T host=x64
```

Visual Studio solution file should be generated. Open it and compile.

### Unreal Engine 4 View

Go to `ue4view/TurnBasedGame`
directory and open `TurnBasedGame.uproject`.
Unreal Engine should ask about rebuilding project. Press Yes.
Rebuilding can take few minutes, because UE4 project automatically compile game model.

To edit C++ code or build system of UE4 project right click on the
`TurnBasedGame.uproject` file and choose "Generate Visual Studio project files".
You can create this also in UE4 Editor in menu File -> Generate Visual Studio Project.

## Common problems

### I try to open `TurnBasedGame.uproject` file, but build fails

1. Check if your repository is not in path with spaces.
1. Check if Game Model is able to compile. UE4 project cannot be build if game model build fails.

## Credits

Project is created and supported by:

<a href="https://quickturnstudio.com/qtgithub">
    <img align="middle" width="222" src="https://github.com/Quick-Turn-Studio/CLionSupportForQt/raw/master/resources/quick-turn-studio-logo.png" alt="Quick Turn Studio website"/>
</a>

1. Check if your repository is not in path with spaces.
1. Check Game Model is able to compile. UE4 project cannot be build if game model build fails.

Follow us on:
<div style="text-align: center; display: inline-block; ">
    <a  href="https://www.linkedin.com/company/quick-turn-studio">
        <img style="margin-right: 10px;" src="https://github.com/Quick-Turn-Studio/CLionSupportForQt/raw/master/resources/linkedin-logo.png" alt="LinkedIn" width="30"/>
    </a>    
    <a href="https://www.facebook.com/QuickTurnStudio/">
        <img src="https://github.com/Quick-Turn-Studio/CLionSupportForQt/raw/master/resources/facebook-logo.png" alt="Facebook" width="30"/>
    </a>
</div>