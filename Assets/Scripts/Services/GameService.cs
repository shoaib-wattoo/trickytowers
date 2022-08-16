using UnityEngine;

public class GameService : MonoBehaviour
{
	public bool isGameActive;
	public ColorService colorService;
	public GameObject currentShape;

	void Awake()
	{
		isGameActive = false;
	}

}