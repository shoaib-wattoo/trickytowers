using UnityEngine;

public class GameService : MonoBehaviour
{
	public bool isGameActive;
	public PlayerStats stats;

	void Awake()
	{
		isGameActive = false;
	}

}