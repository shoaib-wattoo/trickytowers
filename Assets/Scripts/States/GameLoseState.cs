using UnityEngine;
using System.Collections;

public class GameLoseState : _StatesBase
{

	#region implemented abstract members of _StatesBase
	public override void OnActivate()
	{
		Debug.Log("Game Lose State OnActive");

		Services.GameService.isGameActive = false;
		Services.PlayerService.SetHighScore(Services.ScoreService.currentScore);
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
