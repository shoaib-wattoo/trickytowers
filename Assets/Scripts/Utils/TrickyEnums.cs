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
    LIGHT,
    DARK
}

public enum InputMethod
{
    KeyboardInput,
    MouseInput
}

public enum Screens
{
    SPLASH,
    HOME,
    PLAY,
    PAUSE,
    WIN,
    LOSE
}

public enum Popups
{
    PROFILE,
    SETTINGS
}

public enum GameplayOwner
{
    Player1,
    Player2
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

public enum GameMode
{
    SinglePlayer,
    MultiPlayer
}

public enum GameStatus
{
    TOSTART,
    ONGOING,
    PAUSED,
    WON,
    LOST
}