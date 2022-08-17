using UnityEngine;
using System.Collections;

public class MenuState : _StatesBase {
	
	#region implemented abstract members of GameState

	public override void OnActivate ()
	{		
		Debug.Log ("Menu State OnActive");	

		Services.UIService.ActivateUIScreen (Screens.HOME);
    }

	public override void OnDeactivate ()
	{
		Debug.Log ("Menu State OnDeactivate");
	}

	public override void OnUpdate ()
	{

	}

	#endregion
}
