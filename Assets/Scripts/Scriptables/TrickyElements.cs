using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "TrickyElements", menuName = "ScriptableObjects/TrickyElements", order = 1)]
public class TrickyElements : ScriptableObject
{
    [Header("Shapes")]
    public List<TrickyShape> shapeTypes;

    [Header("UI Screens")]
    public SplashScreen splashScreen;
    public HomeScreen homeScreen;
    public GamePlayScreen gamePlayScreen;
    public GamePauseScreen gamePauseScreen;
    public GameOverScreen gameOverScreen;

    [Header("Particle Effects")]
    public List<GameObject> effects;

    [Header("Game Play Prefabs")]
    public GameplayManager gameplayManager;
    public Camera gamePlayCamera;

    [Header("Render Textures")]
    public RenderTexture cameraRenderTexture;
}