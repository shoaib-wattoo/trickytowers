using UnityEngine;
using System.Collections;

public class GamePlayState : _StatesBase {

    private float gamePlayDuration;

	#region implemented abstract members of _StatesBase
	public override void OnActivate ()
	{
		Debug.Log("Game Play State OnActive");
		Services.GameService.isGameActive = true;

		Services.UIService.ActivateUIScreen(Screens.PLAY);
		gamePlayDuration = Time.time;

		if (Services.GameService.GetPlayerManager(GameplayOwner.Player1) != null)
		{
			Services.CameraService.ZoomIn(Services.GameService.player1_Manager, () =>
			{
				Services.GameService.player1_Manager.SpawnShape(1f);

			});
		}

		if (Services.GameService.GetPlayerManager(GameplayOwner.Player2) != null)
		{
			Services.CameraService.ZoomIn(Services.GameService.player2_Manager, () =>
			{
				Services.GameService.player2_Manager.SpawnShape(1f);

			});
		}
	}
	public override void OnDeactivate ()
	{
        Services.PlayerService.SetTimeSpent(Time.time - gamePlayDuration);
		Debug.Log ("Game Play State OnDeactivate");
	}

	public override void OnUpdate ()
	{
		if (Services.GameService.player1_Manager != null
			&& Services.GameService.player1_Manager.currentShape != null)
			Services.GameService.player1_Manager.currentShape.ShapeUpdate();


		if (Services.GameService.player2_Manager != null
			&& Services.GameService.player2_Manager.currentShape != null)
			Services.GameService.player2_Manager.currentShape.ShapeUpdate();
	}
	#endregion

}
