using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using MiniClip.Challenge.Gameplay;
using MiniClip.Challenge.UI;

[CreateAssetMenu(fileName = "TrickyElements", menuName = "ScriptableObjects/TrickyElements", order = 1)]
public class TrickyElements : ScriptableObject
{
    [Header("Game Variables")]
    public float shapeSpawnDelay = 1;
    public int winHeight = 15;
    public int incrementHeightFactor = 2;
    public int totalLifes = 5;
    public float normalFallingSpeed = 5f;
    public float fastFallingSpeed = 15f;
    public float shapesGravity = 1f;
    public float shapesMass = 0.1f;

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