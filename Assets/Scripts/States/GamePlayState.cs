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
			if(Services.GameService.myGameplayManager) Services.GameService.myGameplayManager.SpawnShape(1f);
			if (Services.GameService.opponentGameplayManager) Services.GameService.opponentGameplayManager.SpawnShape(1f);

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
			Services.GameService.currentShape.ShapeUpdate();
	}
	#endregion

}
