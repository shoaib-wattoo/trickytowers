﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BacklogType
{
    DisablePreviousScreen,
    KeepPreviousScreen,
    ClearTop,
    Ignore,
    RemovePreviousScreen
}

public enum ColorTheme
{
    PASTEL,
    GRAM
}

public enum InputMethod
{
    KeyboardInput,
    MouseInput,
    TouchInput
}

public enum Screens
{
    SPLASH,
    HOME,
    PLAY,
    PAUSE,
    OVER
}

public enum ShapeType
{
    I,
    T,
    O,
    L,
    J,
    S,
    Z
}

public enum GameplayOwner
{
    Player,
    Opponent
}

public enum Effects
{
    CartoonyBodySlam,
    ChestAppearBlue,
    ChestAppearPurple,
    ChestAppearWhite,
    ChestAppearYellow,
    ConfettiBlastBlue,
    FlashExplosion,
    FlashExplosion2,
    FlashExplosionRadial,
    HeartPoof,
    SmokeExplosionWhite,
    SoftBodySlam
}