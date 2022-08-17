using UnityEngine;
using System.Collections;

public class GameOverState : _StatesBase {

	#region implemented abstract members of _StatesBase
	public override void OnActivate ()
	{
		Debug.Log("Game Over State OnActive");

		Services.GameService.isGameActive = false;
        Services.PlayerService.SetHighScore(Services.ScoreService.currentScore);
        Services.PlayerService.SetNumberOfGames(1);
        Services.UIService.ActivateUIScreen(Screens.OVER);
        Services.AudioService.PlayLoseSound();       
	}

	public override void OnDeactivate ()
    {
        Debug.Log ("Game Over State OnDeactivate");
	}

	public override void OnUpdate ()
	{
	}
	#endregion

}
