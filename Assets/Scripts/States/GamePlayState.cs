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
			gamePlayDuration = Time.time;
			Services.UIService.ActivateUIScreen(Screens.PLAY);

			Services.GameService.gameStatus = GameStatus.ONGOING;

			Services.GameService.StartGame();
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