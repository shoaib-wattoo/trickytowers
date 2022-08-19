using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    public void Spawn(Transform parent, GameplayOwner owner, GameplayManager gameplayManager)
	{
        Services.AudioService.PlayBlockSpawnSound();
        Vector3 spawnPos = Services.CameraService.GetCameraTopPosition(gameplayManager.gameplayCamera);
        spawnPos.y -= 5f;

        Services.EffectService.PlayEffect(Effects.SmokeExplosionWhite, spawnPos, ()=> {

            // Random Shape
            int i = Random.Range(0, Services.TrickyElements.shapeTypes.Count);

            // Spawn shape at current Position
            GameObject temp = Instantiate(Services.TrickyElements.shapeTypes[i]);
            temp.transform.position = spawnPos;
            gameplayManager.currentShape = temp.GetComponent<TrickyShape>();
            temp.transform.parent = parent;
            temp.GetComponent<TrickyShape>().gameplayManager = gameplayManager;
            Services.InputService.gameplayManager = gameplayManager;
            Services.InputService.isActive = true;
            gameplayManager.SetShadowScale(temp.GetComponent<TrickyShape>());
            gameplayManager.SetShadowPosition(temp.transform.position);

        });
    }
}
