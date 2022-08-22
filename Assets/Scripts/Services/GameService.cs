using UnityEngine;
using System;
using System.Collections.Generic;

public class GameService : MonoBehaviour
{
	public GameMode gameMode;
	public GameStatus gameStatus;
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



	#region GamePlay Managers

	public GameplayManager SpawnGamePlay(GameplayOwner gameplayOwner)
	{
		GameplayManager gameplayManager = Instantiate(Services.TrickyElements.gameplayManager);
		gameplayManager.owner = gameplayOwner;
		gameplayManager.gameObject.name = "GamePlay-" + gameplayOwner;
		Services.CameraService.AssignPlayerCamera(gameplayManager);
		gameplayManager.Init();

		if (gameplayOwner == GameplayOwner.Player1)
			gameplayManager.transform.position = Vector3.zero;
		else
			gameplayManager.transform.position = new Vector3(200, 0, 0);

		return gameplayManager;
	}

	public GameplayManager GetPlayerManager(GameplayOwner gameplayOwner)
	{
		if (gameplayOwner == GameplayOwner.Player1)
			return player1_Manager;

		return player2_Manager;
	}

	public void DestryoGameplayManager()
	{
		if (Services.GameService.gameMode == GameMode.SinglePlayer)
		{
			Destroy(Services.GameService.player1_Manager.gameObject);
		}
		else if (Services.GameService.gameMode == GameMode.MultiPlayer)
		{
			Destroy(Services.GameService.player1_Manager.gameObject);
			Destroy(Services.GameService.player2_Manager.gameObject);
		}
	}

	#endregion



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



    #region Game Finisher

    public void OnGameFinish(GameplayOwner owner, bool isWin)
    {
		if(gameMode == GameMode.SinglePlayer)
        {
			Services.PlayerService.IncrementPlayerLevel(1);

			if(isWin)
				SetState(typeof(GameWinState));
			else
				SetState(typeof(GameLoseState));
		}

		if (gameMode == GameMode.MultiPlayer)
        {
			if (owner == GameplayOwner.Player1 && isWin)
				SetState(typeof(GameWinState));

			if (owner == GameplayOwner.Player1 && !isWin)
				SetState(typeof(GameLoseState));

			if (owner == GameplayOwner.Player2 && isWin)
				SetState(typeof(GameLoseState));

			if (owner == GameplayOwner.Player2 && !isWin)
				SetState(typeof(GameWinState));
		}
    }

	public int GetGameFinisherHeight()
	{
		return Services.TrickyElements.winHeight + (Services.TrickyElements.incrementHeightFactor * Services.PlayerService._player.level);
	}

	#endregion

}