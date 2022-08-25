using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using MiniClip.Challenge.Gameplay;
using MiniClip.Challenge.UI;

[CreateAssetMenu(fileName = "TrickyElements", menuName = "ScriptableObjects/TrickyElements", order = 1)]
public class TrickyElements : ScriptableObject
{
    [Header("Game Variables")]
    [HideInInspector] public float shapeSpawnDelay = 1;
    [HideInInspector] public int winHeight = 15;
    [HideInInspector] public int incrementHeightFactor = 2;
    [HideInInspector] public int totalLifes = 5;
    [HideInInspector] public float normalFallingSpeed = 5f;
    [HideInInspector] public float fastFallingSpeed = 15f;

    [Header("Shapes")]
    public List<TrickyShape> shapeTypes;
    public TrickyShape finalShape;

    [Header("UI Screens")]
    public SplashScreen splashScreen;
    public HomeScreen homeScreen;
    public GamePlayScreen gamePlayScreen;

    [Header("UI Popups")]
    public ProfilePopup profilePopup;
    public SettingsPopup settingsPopup;
    public CommonPopup commonPopup;
    public PausePopup pausePopup;
    public GameWinPopup gameWinPopup;
    public GameLosePopup gameLosePopup;
    public GameFailPopup gameFailPopup;

    [Header("Particle Effects")]
    public List<GameObject> effects;

    [Header("Game Play Prefabs")]
    public GameplayManager gameplayManager;
    public Camera gamePlayCamera;

    [Header("Render Textures")]
    public RenderTexture cameraRenderTexture;

    [Header("Sprites")]
    public Sprite starSprite;
    public Sprite starPlaceHolderSprite;
}