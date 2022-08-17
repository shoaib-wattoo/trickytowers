using UnityEngine;
using System.Collections;

public class GamePlayState : _StatesBase {

    private float gamePlayDuration;

	#region implemented abstract members of _StatesBase
	public override void OnActivate ()
	{
		Debug.Log("Game Play State OnActive");

		Services.UIService.ActivateUIScreen(Screens.PLAY);
		gamePlayDuration = Time.time;

        Services.CameraService.ZoomIn(()=> {
			Services.GameService.myGameplayManager.SpawnShape();
		});
	}
	public override void OnDeactivate ()
	{
        Services.PlayerService.SetTimeSpent(Time.time - gamePlayDuration);
		Debug.Log ("Game Play State OnDeactivate");
	}

	public override void OnUpdate ()
	{
        if(Services.GameService.currentShape!=null)
			Services.GameService.currentShape.movementController.ShapeUpdate();
	}
	#endregion

}
