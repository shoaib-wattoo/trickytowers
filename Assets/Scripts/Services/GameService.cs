using UnityEngine;
using System;
using System.Collections.Generic;

public class GameService : MonoBehaviour
{
	public bool isGameActive;
	public ColorService colorService;
	public GameplayManager player1_Manager;
	public GameplayManager player2_Manager;

	void Awake()
	{
		isGameActive = false;
	}

	private _StatesBase currentState;
	public _StatesBase State
	{
		get { return currentState; }
	}

	public void SpawnGamePlay(GameplayOwner gameplayOwner)
    {
		GameplayManager gameplayManager =  Instantiate(Services.TrickyElements.gameplayManager);
		gameplayManager.owner = gameplayOwner;
		gameplayManager.gameObject.name = "GamePlay-"+gameplayOwner;
		gameplayManager.Init();
	}

	public GameplayManager GetPlayerManager(GameplayOwner gameplayOwner)
    {
		if (gameplayOwner == GameplayOwner.Player1)
			return player1_Manager;

		return player2_Manager;
	}

	//Changes the current game state
	public void SetState(System.Type newStateType)
	{
		if (currentState != null)
		{
			currentState.OnDeactivate();
		}

		currentState = GetComponentInChildren(newStateType) as _StatesBase;
		if (currentState != null)
		{
			currentState.OnActivate();
		}
	}

	void Update()
	{
		if (currentState != null)
		{
			currentState.OnUpdate();
		}
	}

	#region Shape Shadow

	public void SetShadowScale(GameplayOwner gameplayOwner, TrickyShape shape)
    {
		GetPlayerManager(gameplayOwner).SetShadowScale(shape);
	}

	public void SetShadowPosition(GameplayOwner gameplayOwner, Vector3 position)
	{
		GetPlayerManager(gameplayOwner).SetShadowPosition(position);
	}

	public void DisableShadowShape(GameplayOwner gameplayOwner, TrickyShape shape)
	{
		GetPlayerManager(gameplayOwner).DisableShadowShape(shape);
	}

	#endregion

	#region Game Play Shapes

	public void RemoveShapePlacedFromList(GameplayOwner gameplayOwner, TrickyShape shape)
    {
		GetPlayerManager(gameplayOwner).RemoveShapePlacedFromList(shape);
    }

	public void AddShapePlacedInList(GameplayOwner gameplayOwner, TrickyShape shape)
	{
		GetPlayerManager(gameplayOwner).AddShapePlacedInList(shape);
	}

	public void SpawnShape(GameplayOwner gameplayOwner, float delay)
    {
		GetPlayerManager(gameplayOwner).SpawnShape(delay);

	}

	public void SetCurrentCurrentShape(GameplayOwner gameplayOwner, TrickyShape shape)
	{
		GetPlayerManager(gameplayOwner).currentShape = shape;

	}

	public void RemoveCurrentShape(GameplayOwner gameplayOwner)
	{
		GetPlayerManager(gameplayOwner).currentShape = null;

	}

	#endregion

}