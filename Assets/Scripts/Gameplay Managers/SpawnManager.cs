using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    GameplayManager gameplayManager;

    private void Awake()
    {
        gameplayManager = GetComponent<GameplayManager>();
    }

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
	{
		// Random Shape
   		 int i = Random.Range(0, Services.TrickyElements.shapeTypes.Count);

		// Spawn shape at current Position
		GameObject temp = Instantiate(Services.TrickyElements.shapeTypes[i]);
        temp.transform.position = gameplayManager.blockHolder.position;
        Services.GameService.currentShape = temp.GetComponent<TrickyShape>();
        temp.transform.parent = gameplayManager.blockHolder;
        Services.InputService.isActive = true;
    }
}
