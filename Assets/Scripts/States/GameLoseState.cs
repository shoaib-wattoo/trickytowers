using UnityEngine;
using System.Collections;
using MiniClip.Challenge.Service;

namespace MiniClip.Challenge.States
{
	public class GameLoseState : _StatesBase
	{
		#region implemented abstract members of _StatesBase
		public override void OnActivate()
		{
			Debug.Log("Game Lose State OnActive");

			Services.GameService.isGameActive = false;
			Services.GameService.DestryoGameplayManager();
			Services.PlayerService.SetHighScore(Services.ScoreService.currentScore);
			Services.GameService.gameStatus = GameStatus.LOST;
			Services.PlayerService.SetNumberOfGames(1);
			Services.UIService.ActivateUIScreen(Screens.LOSE);
			Services.AudioService.PlayLoseSound();
		}

		public override void OnDeactivate()
		{
			Debug.Log("Game Lose State OnDeactivate");
		}

		public override void OnUpdate()
		{
		}
		#endregion

	}
}