﻿using UnityEngine;
using System.Collections;
using System;
using System.Linq;

public class TrickyShape : MonoBehaviour
{
    public GameplayManager gameplayManager;
    public ShapeType type;

    public Transform rotationPivot;
    public float fallingSpeed = 2f;
    public float fastFallingSpeed = 5f;
    Rigidbody2D rigidbody2D;
    public bool isSpawnedNextBlock, isPlaced = false;
    public GameplayOwner owner;
    public Color shapeColor;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        AssignRandomColor();
    }

    void AssignRandomColor()
    {
        shapeColor = Services.GameService.colorService.TurnRandomColorFromTheme();
        GetComponent<SpriteRenderer>().color = shapeColor;
    }

    public void ShapeUpdate()
    {
        FreeFall();
    }

    public void RotateClockWise(bool isCw)
    {
        float rotationDegree = (isCw) ? 90.0f : -90.0f;

        transform.RotateAround(rotationPivot.position, Vector3.forward, rotationDegree);
    }

    public void MoveHorizontal(Vector2 direction)
    {
        float deltaMovement = (direction.Equals(Vector2.right)) ? 1.0f : -1.0f;

        // Modify position
        transform.position += new Vector3(deltaMovement, 0, 0);
    }

    public void FreeFall()
    {
        transform.position = new Vector3(
        transform.position.x,
        transform.position.y - (fallingSpeed * Time.deltaTime),
        transform.position.z);
    }

    public void InstantFall()
    {
        fallingSpeed = fastFallingSpeed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Ground"))
        {
            OnCollisionWithGround(col);
            return;
        }

        OnCollisionWithOtherShapes();

        gameplayManager.UpdateCameraFollowTarget();
    }

    void OnCollisionWithOtherShapes()
    {
        rigidbody2D.gravityScale = 0.5f;
        SpawnNextShape(1f);
        PlayEffectOnFirstTimePlaced();
    }

    void OnCollisionWithGround(Collision2D col)
    {
        Services.CameraService.ShakeCamera();
        Services.AudioService.PlayExplosionSound();
        Services.EffectService.PlayEffect(Effects.SmokeExplosionWhite, col.contacts[0].point, shapeColor);
        SpawnNextShape(1.5f);
        gameplayManager.RemoveShapeFromList(this);
        Destroy(gameObject);
    }

    void PlayEffectOnFirstTimePlaced()
    {
        if (!isPlaced)
        {
            isPlaced = true;
            Services.AudioService.PlayShapePlaceSound();
            Services.CameraService.ShakeCamera();
            gameplayManager.AddShapeInList(this);
        }
    }

    void SpawnNextShape(float delay = 0)
    {
        if (isSpawnedNextBlock)
            return;

        isSpawnedNextBlock = true;
        Services.GameService.currentShape = null;

        if (owner == GameplayOwner.Player)
            gameplayManager.SpawnShape(delay);
        else
            gameplayManager.SpawnShape(delay);
    }
}
