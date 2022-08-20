using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    public void Spawn(GameplayOwner owner, Transform parent)
	{
        Services.AudioService.PlayBlockSpawnSound();
        Vector3 spawnPos = Services.CameraService.GetCameraTopPosition(owner);
        spawnPos.y -= 5f; //Just adding offset to spawn position

        Services.EffectService.PlayEffect(Effects.SmokeExplosionWhite, spawnPos, ()=> {

            // Random Shape
            int i = Random.Range(0, Services.TrickyElements.shapeTypes.Count);

            // Spawn shape at current Position
            GameObject temp = Instantiate(Services.TrickyElements.shapeTypes[i]);
            temp.transform.position = spawnPos;
            Services.GameService.SetCurrentCurrentShape(owner, temp.GetComponent<TrickyShape>());
            temp.transform.parent = parent;
            Services.InputService.gameplayManager = Services.GameService.GetPlayerManager(owner);
            Services.InputService.isActive = true;
            Services.GameService.SetShadowScale(owner, temp.GetComponent<TrickyShape>());
            Services.GameService.SetShadowPosition(owner, temp.transform.position);

        });
    }
}
