using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lofelt.NiceVibrations;
using MiniClip.Challenge.ProjectServices;

namespace MiniClip.Challenge.Gameplay
{
    public class ShapeCollisionController : MonoBehaviour
    {
        Rigidbody2D rigidbody2D;
        bool isSpawnedNextBlock = false;

        private TrickyShape _trickyShape;
        public TrickyShape TrickyShape
        {
            get
            {
                if (_trickyShape == null)
                {
                    _trickyShape = GetComponent<TrickyShape>();
                }
                return _trickyShape;
            }
        }


        void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            isSpawnedNextBlock = false;
        }

        #region Shape Collision Functions

        void OnCollisionEnter2D(Collision2D col)
        {
            Services.GameService.DisableShadowShape(TrickyShape.owner, TrickyShape);

            if (col.gameObject.tag.Equals("Ground"))
            {
                OnCollisionWithGround(col);
                return;
            }

            OnCollisionWithOtherShapes();

            Services.CameraService.UpdateCameraFollowTarget(TrickyShape.owner);
        }

        void OnCollisionWithOtherShapes()
        {
            if (TrickyShape.isFinalShape)
            {
                Services.GameService.RemoveCurrentShape(TrickyShape.owner);
                rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
                if(TrickyShape.owner == GameplayOwner.Player1) Services.AudioService.PlayShapePlaceSound();
                Services.CameraService.ShakeCamera(TrickyShape.owner);
                Services.ScoreService.OnScore(TrickyShape.owner, 1);
                Services.GameService.GetPlayerManager(TrickyShape.owner).StopShaking();

                Services.GameService.OnGameFinish(TrickyShape.owner, true);
                return;
            }

            SpawnNextShape(Services.TrickyElements.shapeSpawnDelay);
            rigidbody2D.gravityScale = 1f;
            PlayEffectOnFirstTimePlaced();
        }

        void OnCollisionWithGround(Collision2D col)
        {
            Services.CameraService.ShakeCamera(TrickyShape.owner);
            if (TrickyShape.owner == GameplayOwner.Player1) Services.AudioService.PlayExplosionSound();
            Services.EffectService.PlayEffect(Effects.SmokeExplosionWhite, col.contacts[0].point, TrickyShape.shapeColor);
            Services.GameService.RemoveShapePlacedFromList(TrickyShape.owner, TrickyShape);
            Services.vibrationService.VibratePhone(HapticPatterns.PresetType.MediumImpact);
            Services.CameraService.UpdateCameraFollowTarget(TrickyShape.owner);

            Services.GameService.GetPlayerManager(TrickyShape.owner).OnShapeDestroy( isGameFinished => {
                if(!isGameFinished)
                    SpawnNextShape(Services.TrickyElements.shapeSpawnDelay + 0.5f);
            });

            Services.GameService.AddObjectsInPool(TrickyShape);
        }

        void PlayEffectOnFirstTimePlaced()
        {
            if (!TrickyShape.isPlaced)
            {
                TrickyShape.isPlaced = true;
                if (TrickyShape.owner == GameplayOwner.Player1) Services.AudioService.PlayShapePlaceSound();
                Services.CameraService.ShakeCamera(TrickyShape.owner);
                Services.GameService.AddShapePlacedInList(TrickyShape.owner, TrickyShape);
                Services.ScoreService.OnScore(TrickyShape.owner, 1);
            }
        }

        void SpawnNextShape(float delay = 0)
        {
            if (isSpawnedNextBlock)
                return;

            isSpawnedNextBlock = true;
            Services.GameService.RemoveCurrentShape(TrickyShape.owner);
            Services.GameService.SpawnShape(TrickyShape.owner, delay);
        }

        #endregion
    }
}