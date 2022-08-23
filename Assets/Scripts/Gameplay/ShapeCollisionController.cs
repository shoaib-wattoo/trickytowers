using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lofelt.NiceVibrations;

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
        SpawnNextShape(1f);
        rigidbody2D.gravityScale = 1f;
        PlayEffectOnFirstTimePlaced();
    }

    void OnCollisionWithGround(Collision2D col)
    {
        Services.CameraService.ShakeCamera(TrickyShape.owner);
        Services.AudioService.PlayExplosionSound();
        Services.EffectService.PlayEffect(Effects.SmokeExplosionWhite, col.contacts[0].point, TrickyShape.shapeColor);
        SpawnNextShape(1.5f);
        Services.GameService.RemoveShapePlacedFromList(TrickyShape.owner, TrickyShape);
        Services.GameService.GetPlayerManager(TrickyShape.owner).OnShapeDestroy();
        Services.vibrationService.VibratePhone(HapticPatterns.PresetType.MediumImpact);
        Destroy(gameObject);
    }

    void PlayEffectOnFirstTimePlaced()
    {
        if (!TrickyShape.isPlaced)
        {
            TrickyShape.isPlaced = true;
            Services.AudioService.PlayShapePlaceSound();
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
