using UnityEngine;
using System.Collections;
using MiniClip.Challenge.ProjectServices;

namespace MiniClip.Challenge.States
{
	public class GamePauseState : _StatesBase
	{

		#region implemented abstract members of GameState

		public override void OnActivate()
		{
			Debug.Log("Game Pause State OnActive");

			Services.UIService.ActivateUIPopups(Popups.PAUSE);
			Services.GameService.gameStatus = GameStatus.PAUSED;

			//Services.CameraService.ZoomOut();
		}

		public override void OnDeactivate()
		{
			Debug.Log("Game Pause State OnDeactivate");
		}

		public override void OnUpdate()
		{
		}

		#endregion
	}
}