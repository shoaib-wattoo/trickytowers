using UnityEngine;
using UnityEditor;

public class GameControls : EditorWindow {

    TrickyElements trickyElements = null;

    float shapeSpawnDelay;
    int winHeight;
    int incrementHeightFactor;
    int totalLifes;
    float normalFallingSpeed;
    float fastFallingSpeed;
    float shapesGravity;
    float shapesMass;

    [MenuItem("Tools/Game Controls")]
	public static void ShowWindow ()
	{
		GetWindow<GameControls>("Game Controls Editor");
    }

    private void OnEnable()
    {
        LoadAsset();
    }

    void OnGUI ()
	{

        if (trickyElements != null)
        {
            GUILayout.Label("Tweak the following game controls :", EditorStyles.boldLabel);

            shapeSpawnDelay = EditorGUILayout.FloatField("Shape Spawn Delay :", shapeSpawnDelay);
            winHeight = EditorGUILayout.IntField("Win Height :", winHeight);
            incrementHeightFactor = EditorGUILayout.IntField("Increment Height Factor :", incrementHeightFactor);
            totalLifes = EditorGUILayout.IntField("Total Lifes :", totalLifes);
            normalFallingSpeed = EditorGUILayout.FloatField("Normal Falling Speed :", normalFallingSpeed);
            fastFallingSpeed = EditorGUILayout.FloatField("Fast Falling Speed :", fastFallingSpeed);
            shapesGravity = EditorGUILayout.FloatField("Shapes Gravity :", shapesGravity);
            shapesMass = EditorGUILayout.FloatField("Shapes Mass :", shapesMass);

            if (GUILayout.Button("Save"))
            {
                Save();
            }
        }
        else
        {
            GUILayout.Label("File not found", EditorStyles.boldLabel);
        }
    }
	
	void Save()
    {
        Debug.Log("Saved");
        trickyElements.shapeSpawnDelay = shapeSpawnDelay;
        trickyElements.winHeight = winHeight;
        trickyElements.incrementHeightFactor = incrementHeightFactor;
        trickyElements.totalLifes = totalLifes;
        trickyElements.normalFallingSpeed = normalFallingSpeed;
        trickyElements.fastFallingSpeed = fastFallingSpeed;
        trickyElements.shapesGravity = shapesGravity;
        trickyElements.shapesMass = shapesMass;

        EditorUtility.SetDirty(trickyElements);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    public void LoadAsset()
    {
        string[] result = AssetDatabase.FindAssets("TrickyElementsSO");

        if (result.Length > 1)
        {
            Debug.LogError("More than 1 Asset founded");
            return;
        }

        if (result.Length == 0)
        {
            Debug.Log("Asset not found");
            return;
        }
        else
        {
            string path = AssetDatabase.GUIDToAssetPath(result[0]);
            trickyElements = (TrickyElements)AssetDatabase.LoadAssetAtPath(path, typeof(TrickyElements));
            Debug.Log("Found Asset File !!!");
        }

        shapeSpawnDelay = trickyElements.shapeSpawnDelay;
        winHeight = trickyElements.winHeight;
        incrementHeightFactor = trickyElements.incrementHeightFactor;
        totalLifes = trickyElements.totalLifes;
        normalFallingSpeed = trickyElements.normalFallingSpeed;
        fastFallingSpeed = trickyElements.fastFallingSpeed;
        shapesGravity = trickyElements.shapesGravity;
        shapesMass = trickyElements.shapesMass;
    }
}
