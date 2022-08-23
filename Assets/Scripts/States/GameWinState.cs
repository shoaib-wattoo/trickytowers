using UnityEngine;
using System.Collections;
using MiniClip.Challenge.Service;

namespace MiniClip.Challenge.States
{
	public class GameWinState : _StatesBase
	{

		#region implemented abstract members of _StatesBase
		public override void OnActivate()
		{
			Debug.Log("Game Win State OnActive");

			Services.GameService.isGameActive = false;
			Services.GameService.DestryoGameplayManager();
			Services.PlayerService.SetHighScore(Services.ScoreService.currentScore);
			Services.GameService.gameStatus = GameStatus.WON;
			Services.PlayerService.SetNumberOfGames(1);
			Services.UIService.ActivateUIScreen(Screens.WIN);
			Services.AudioService.PlayWinSound();
		}

		public override void OnDeactivate()
		{
			Debug.Log("Game Win State OnDeactivate");
		}

		public override void OnUpdate()
		{
		}
		#endregion

	}
}