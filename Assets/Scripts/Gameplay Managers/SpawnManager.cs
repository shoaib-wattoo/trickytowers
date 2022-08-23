using UnityEngine;
using System.Collections;
using MiniClip.Challenge.ProjectServices;

namespace MiniClip.Challenge.Gameplay
{
    public class SpawnManager : MonoBehaviour
    {

        public void Spawn(GameplayOwner owner, Transform parent)
        {
            Services.AudioService.PlayBlockSpawnSound();
            Vector3 spawnPos = Services.CameraService.GetCameraTopPosition(owner);
            spawnPos = new Vector3(transform.position.x, spawnPos.y - 5f, 0);

            Services.EffectService.PlayEffect(Effects.SmokeExplosionWhite, spawnPos, () =>
            {

                // Random Shape
                int i = Random.Range(0, Services.TrickyElements.shapeTypes.Count);

                // Spawn shape at current Position
                TrickyShape shape = Instantiate(Services.TrickyElements.shapeTypes[i]);
                shape.owner = owner;
                shape.transform.position = new Vector3(transform.position.x, spawnPos.y, 0);
                Services.GameService.SetCurrentCurrentShape(owner, shape);
                shape.transform.parent = parent;
                Services.GameService.SetShadowScale(owner, shape);
                Services.GameService.SetShadowPosition(owner, shape.transform.position);

                if (owner == GameplayOwner.Player1)
                {
                    Services.InputService.gameplayManager = Services.GameService.GetPlayerManager(owner);
                    Services.InputService.isActive = true;
                }

                if (owner == GameplayOwner.Player2)
                {
                    //TODO/Need to assign AI controller
                }
            });
        }
    }
}
