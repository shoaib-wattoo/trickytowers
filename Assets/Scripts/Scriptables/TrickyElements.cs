using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "TrickyElements", menuName = "ScriptableObjects/TrickyElements", order = 1)]
public class TrickyElements : ScriptableObject
{
    [Header("Shapes")]
    public List<GameObject> shapeTypes;

    [Header("UI Screens")]
    public SplashScreen splashScreen;
    public HomeScreen homeScreen;
}