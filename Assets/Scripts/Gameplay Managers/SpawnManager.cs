using UnityEngine;
using System.Collections;
using MiniClip.Challenge.ProjectServices;

namespace MiniClip.Challenge.Gameplay
{
    public class SpawnManager : MonoBehaviour
    {
        private GameplayOwner owner;
        public TrickyShape nextShape;
        public Color shapeToSpawnColor;
        public Color nextShapeColorOnUI;

        public void Spawn(GameplayOwner owner, Transform parent, TrickyShape shapeToSpawn = null)
        {
            this.owner = owner;
            if (owner == GameplayOwner.Player1) Services.AudioService.PlayBlockSpawnSound();
            Vector3 spawnPos = Services.CameraService.GetCameraTopPosition(owner);
            spawnPos = new Vector3(transform.position.x, spawnPos.y - 5f, 0);

            Services.EffectService.PlayEffect(Effects.SmokeExplosionWhite, spawnPos, () =>
            {
                if (Services.GameService.gameStatus == GameStatus.ONGOING || Services.GameService.gameStatus == GameStatus.PAUSED)
                {
                    // Spawn shape at current Position
                    TrickyShape shape;

                    if (shapeToSpawn == null)
                        shape = InstantiateShape(GetShapeToSpawn());
                    else
                        shape = Instantiate(shapeToSpawn); ;

                    shape.AssignShapeColor(shapeToSpawnColor);
                    shape.owner = owner;
                    shape.transform.position = new Vector3(transform.position.x, spawnPos.y, 0);
                    shape.gameObject.SetActive(true);
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
                }
            });
        }

        public TrickyShape GetShapeToSpawn()
        {
            TrickyShape shapeToSpawn;

            if (nextShape == null)
            {
                shapeToSpawn = GetRandomShape();
                shapeToSpawnColor = Services.GameService.colorService.TurnRandomColorFromTheme();
            }
            else
            {
                shapeToSpawn = nextShape;
                shapeToSpawnColor = nextShapeColorOnUI;
            }

            nextShape = GetRandomShape();
            nextShapeColorOnUI = Services.GameService.colorService.TurnRandomColorFromTheme();

            Services.UIService.GamePlayScreen.ShowNextShape(owner, nextShape.spriteRenderer.sprite, nextShapeColorOnUI);

            return shapeToSpawn;
        }

        public void AssignShapeToSpawnNext(GameplayOwner _owner)
        {
            if (nextShape == null)
            {
                nextShape = GetRandomShape();
                nextShapeColorOnUI = shapeToSpawnColor = Services.GameService.colorService.TurnRandomColorFromTheme();
                Services.UIService.GamePlayScreen.ShowNextShape(_owner, nextShape.spriteRenderer.sprite, nextShapeColorOnUI);

            }
        }

        public void SpawnFinalShape(GameplayOwner _owner)
        {
            nextShape = Services.TrickyElements.finalShape;
            shapeToSpawnColor = nextShapeColorOnUI = Color.white;
            Services.UIService.GamePlayScreen.ShowNextShape(_owner, nextShape.spriteRenderer.sprite, nextShapeColorOnUI);

            Spawn(owner, Services.GameService.GetPlayerManager(owner).blockHolder, nextShape);
        }

        TrickyShape GetRandomShape()
        {
            int random = Random.Range(0, Services.TrickyElements.shapeTypes.Count);
            return Services.TrickyElements.shapeTypes[random];
        }

        TrickyShape InstantiateShape(TrickyShape _shape)
        {
            TrickyShape shape;

            if (Services.GameService.CheckIfObjectExistInPool(_shape.name))
            {
                print("Shape Existed : " + _shape.name);
                shape = Services.GameService.GetObjectFromPool(_shape.name);
            }
            else
            {
                shape = Instantiate(_shape);
            }

            return shape;
        }
    }
}
