using UnityEngine;
using System.Collections;
using MiniClip.Challenge.ProjectServices;

namespace MiniClip.Challenge.States
{
	public class MenuState : _StatesBase
	{

		#region implemented abstract members of GameState

		public override void OnActivate()
		{
			Debug.Log("Menu State OnActive");
			Services.BackLogService.DisableAndremoveAllScreens();
			Services.UIService.ActivateUIScreen(Screens.HOME);
			Services.GameService.gameStatus = GameStatus.TOSTART;
			Services.GameService.DestryoGameplayManager();
			Services.CameraService.ResetCameraSize();

		}

		public override void OnDeactivate()
		{
			Debug.Log("Menu State OnDeactivate");
		}

		public override void OnUpdate()
		{

		}

		#endregion
	}
}