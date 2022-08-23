using UnityEngine;
using System.Collections;
using MiniClip.Challenge.ProjectServices;

namespace MiniClip.Challenge.States
{
	public class GameOverState : _StatesBase
	{

		#region implemented abstract members of _StatesBase
		public override void OnActivate()
		{
			Debug.Log("Game Over State OnActive");

			Services.GameService.isGameActive = false;

			Services.BackLogService.RemoveLastScreens(1);

			if (Services.GameService.gameStatus == GameStatus.WON)
			{
				Services.UIService.ActivateUIPopups(Popups.WIN);
			}
			else if (Services.GameService.gameStatus == GameStatus.LOST)
			{
				if (Services.GameService.gameMode == GameMode.SinglePlayer)
				{
					Services.UIService.ActivateUIPopups(Popups.FAIL);
				}
				else
				{
					Services.UIService.ActivateUIPopups(Popups.LOSE);
				}
			}

			Services.PlayerService.SetHighScore(Services.ScoreService.currentScore);
			Services.PlayerService.SetNumberOfGames(1);
			Services.AudioService.PlayWinSound();
		}

		public override void OnDeactivate()
		{
			Debug.Log("Game Over State OnDeactivate");
			Services.GameService.gameStatus = GameStatus.TOSTART;
			Services.GameService.DestryoGameplayManager();
		}

		public override void OnUpdate()
		{
		}
		#endregion

	}
}