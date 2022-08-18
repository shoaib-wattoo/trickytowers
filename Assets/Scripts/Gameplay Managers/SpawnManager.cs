using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    public void Spawn(Transform parent, GameplayOwner owner)
	{
        Services.EffectService.PlayEffect(Effects.SmokeExplosionWhite, Services.CameraService.GetCameraTopPosition(), ()=> {

            // Random Shape
            int i = Random.Range(0, Services.TrickyElements.shapeTypes.Count);

            // Spawn shape at current Position
            GameObject temp = Instantiate(Services.TrickyElements.shapeTypes[i]);
            temp.transform.position = Services.CameraService.GetCameraTopPosition();
            Services.GameService.currentShape = temp.GetComponent<TrickyShape>();
            temp.transform.parent = parent;
            temp.GetComponent<ShapeMovementController>().owner = owner;
            Services.InputService.isActive = true;

        });
    }
}
