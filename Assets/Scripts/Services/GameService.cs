using UnityEngine;

public class GameService : MonoBehaviour
{
	public bool isGameActive;
	public GameObject currentShape;

	void Awake()
	{
		isGameActive = false;
	}

}