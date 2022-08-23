using UnityEngine;
using System.Collections;
using MiniClip.Challenge.ProjectServices;

namespace MiniClip.Challenge.States
{
	public class GamePlayState : _StatesBase
	{

		private float gamePlayDuration;

		#region implemented abstract members of _StatesBase
		public override void OnActivate()
		{
			Debug.Log("Game Play State OnActive");
			Services.GameService.isGameActive = true;
			Services.BackLogService.DisableAndremoveAllScreens();
			Services.UIService.ActivateUIScreen(Screens.PLAY);
			gamePlayDuration = Time.time;

			if (Services.GameService.gameStatus == GameStatus.ONGOING)
				return;

			Services.GameService.gameStatus = GameStatus.ONGOING;

			if (Services.GameService.gameMode == GameMode.SinglePlayer)
			{
				Services.GameService.player1_Manager = Services.GameService.SpawnGamePlay(GameplayOwner.Player1);
			}
			else if (Services.GameService.gameMode == GameMode.MultiPlayer)
			{
				Services.GameService.player1_Manager = Services.GameService.SpawnGamePlay(GameplayOwner.Player1);
				Services.GameService.player2_Manager = Services.GameService.SpawnGamePlay(GameplayOwner.Player2);
			}

			if (Services.GameService.GetPlayerManager(GameplayOwner.Player1) != null)
			{
				Services.CameraService.ZoomIn(Services.GameService.player1_Manager, () =>
				{
					Services.GameService.player1_Manager.SpawnShape(1f);

				});
			}

			if (Services.GameService.GetPlayerManager(GameplayOwner.Player2) != null)
			{
				Services.CameraService.ZoomIn(Services.GameService.player2_Manager, () =>
				{
					Services.GameService.player2_Manager.SpawnShape(1f);

				});
			}
		}

		public override void OnDeactivate()
		{
			Debug.Log("Game Play State OnDeactivate");

			Services.PlayerService.SetTimeSpent(Time.time - gamePlayDuration);
		}

		public override void OnUpdate()
		{
			if (Services.GameService.player1_Manager != null
				&& Services.GameService.player1_Manager.currentShape != null)
				Services.GameService.player1_Manager.currentShape.ShapeUpdate();


			if (Services.GameService.player2_Manager != null
				&& Services.GameService.player2_Manager.currentShape != null)
				Services.GameService.player2_Manager.currentShape.ShapeUpdate();
		}
		#endregion

	}
}