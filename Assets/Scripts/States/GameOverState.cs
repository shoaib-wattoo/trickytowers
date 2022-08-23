using UnityEngine;
using System.Collections;
using MiniClip.Challenge.Service;

namespace MiniClip.Challenge.States
{
	public class GameOverState : _StatesBase
	{

		#region implemented abstract members of _StatesBase
		public override void OnActivate()
		{
			Debug.Log("Game Over State OnActive");

			Services.GameService.isGameActive = false;

			Services.BackLogService.DisableAndremoveAllScreens();

			if (Services.GameService.gameOverStatus == GameOverStatus.WON)
				Services.UIService.ActivateUIScreen(Screens.WIN);
			else if (Services.GameService.gameOverStatus == GameOverStatus.LOST)
				Services.UIService.ActivateUIScreen(Screens.LOSE);

			Services.GameService.DestryoGameplayManager();
			Services.PlayerService.SetHighScore(Services.ScoreService.currentScore);
			Services.GameService.gameStatus = GameStatus.WON;
			Services.PlayerService.SetNumberOfGames(1);
			Services.AudioService.PlayWinSound();
		}

		public override void OnDeactivate()
		{
			Debug.Log("Game Over State OnDeactivate");
			Services.GameService.gameOverStatus = GameOverStatus.NONE;
		}

		public override void OnUpdate()
		{
		}
		#endregion

	}
}