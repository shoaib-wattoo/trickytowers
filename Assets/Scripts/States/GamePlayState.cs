using UnityEngine;
using System.Collections;

public class GamePlayState : _StatesBase {

    private float gamePlayDuration;

	#region implemented abstract members of _StatesBase
	public override void OnActivate ()
	{
		//Services.UIService.ActivateUIScreen(Screen.INGAME);
		Debug.Log("Gameplay State OnActive");

		gamePlayDuration = Time.time;
        Services.CameraService.ZoomIn(()=> {
			Services.GameService.myGameplayManager.SpawnShape();
		});
	}
	public override void OnDeactivate ()
	{
        Services.PlayerService.SetTimeSpent(Time.time - gamePlayDuration);
		Debug.Log ("Gameplay State OnDeactivate");
	}

	public override void OnUpdate ()
	{
        if(Services.GameService.currentShape!=null)
			Services.GameService.currentShape.movementController.ShapeUpdate();
	}
	#endregion

}
