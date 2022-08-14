using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "TrickyElements", menuName = "ScriptableObjects/TrickyElements", order = 1)]
public class TrickyElements : ScriptableObject
{
    [Header("Sprites")]
    public List<Sprite> tetrisSprites;

    [Header("UI Screens")]
    public SplashScreen splashScreen;
    public HomeScreen homeScreen;
}