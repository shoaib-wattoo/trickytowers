using UnityEngine;

public class GameService : MonoBehaviour
{
	public bool isGameActive;
	public PlayerStats stats;
	public GameObject currentShape;

	void Awake()
	{
		isGameActive = false;
	}

}