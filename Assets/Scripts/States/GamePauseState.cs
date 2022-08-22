using UnityEngine;
using System.Collections;

public class GamePauseState : _StatesBase
{

	#region implemented abstract members of GameState

	public override void OnActivate()
	{
		Debug.Log("Game Pause State OnActive");

		Services.UIService.ActivateUIScreen (Screens.PAUSE);
		Services.GameService.gameStatus = GameStatus.PAUSED;

		//Services.CameraService.ZoomOut();
	}

	public override void OnDeactivate()
	{
		Debug.Log("Game Pause State OnDeactivate");
		Services.GameService.gameStatus = GameStatus.ONGOING;
	}

	public override void OnUpdate()
	{
	}

	#endregion
}