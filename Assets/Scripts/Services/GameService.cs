using UnityEngine;
using System;
using System.Collections.Generic;
using MiniClip.Challenge.Gameplay;
using MiniClip.Challenge.States;

namespace MiniClip.Challenge.ProjectServices
{
	public class GameService : MonoBehaviour
	{
		public GameMode gameMode;
		public GameStatus gameStatus;
		public GameOverStatus gameOverStatus;
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
				gameplayManager.transform.position = new Vector3(300, 0, 0);

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
				if (Services.GameService.player1_Manager)
					Destroy(Services.GameService.player1_Manager.gameObject);
			}
			else if (Services.GameService.gameMode == GameMode.MultiPlayer)
			{
				if (Services.GameService.player1_Manager)
					Destroy(Services.GameService.player1_Manager.gameObject);
				if (Services.GameService.player2_Manager)
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
			if (gameMode == GameMode.SinglePlayer)
			{
				if (isWin)
				{
					Services.PlayerService.IncrementPlayerLevel(1);
					gameOverStatus = GameOverStatus.WON;
					SetState(typeof(GameOverState));
				}
				else
				{
					gameOverStatus = GameOverStatus.LOST;
					SetState(typeof(GameOverState));
				}
			}

			if (gameMode == GameMode.MultiPlayer)
			{
				if (owner == GameplayOwner.Player1 && isWin)
				{
					gameOverStatus = GameOverStatus.WON;
					SetState(typeof(GameOverState));
				}

				if (owner == GameplayOwner.Player1 && !isWin)
				{
					gameOverStatus = GameOverStatus.LOST;
					SetState(typeof(GameOverState));
				}

				if (owner == GameplayOwner.Player2 && isWin)
				{
					gameOverStatus = GameOverStatus.LOST;
					SetState(typeof(GameOverState));
				}

				if (owner == GameplayOwner.Player2 && !isWin)
				{
					gameOverStatus = GameOverStatus.WON;
					SetState(typeof(GameOverState));
				}
			}
		}

		public int GetGameFinisherHeight()
		{
			return Services.TrickyElements.winHeight + (Services.TrickyElements.incrementHeightFactor * Services.PlayerService._player.level);
		}

		#endregion

	}
}