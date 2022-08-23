using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using MiniClip.Challenge.Gameplay;
using MiniClip.Challenge.UI;

[CreateAssetMenu(fileName = "TrickyElements", menuName = "ScriptableObjects/TrickyElements", order = 1)]
public class TrickyElements : ScriptableObject
{
    [Header("Game Variables")]
    public float shapeSpawnDelay;
    public int winHeight = 40;
    public int incrementHeightFactor = 2;
    public int totalLifes = 5;
    public float normalFallingSpeed = 2f;
    public float fastFallingSpeed = 5f;

    [Header("Shapes")]
    public List<TrickyShape> shapeTypes;

    [Header("UI Screens")]
    public SplashScreen splashScreen;
    public HomeScreen homeScreen;
    public GamePlayScreen gamePlayScreen;
    public GamePauseScreen gamePauseScreen;
    public GameWinScreen gameWinScreen;
    public GameLoseScreen gameLoseScreen;

    [Header("UI Popups")]
    public ProfilePopup profilePopup;
    public SettingsPopup settingsPopup;
    public CommonPopup commonPopup;

    [Header("Particle Effects")]
    public List<GameObject> effects;

    [Header("Game Play Prefabs")]
    public GameplayManager gameplayManager;
    public Camera gamePlayCamera;

    [Header("Render Textures")]
    public RenderTexture cameraRenderTexture;
}