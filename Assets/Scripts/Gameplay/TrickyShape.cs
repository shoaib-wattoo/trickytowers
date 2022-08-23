using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using MiniClip.Challenge.ProjectServices;

namespace MiniClip.Challenge.Gameplay
{
    public class TrickyShape : MonoBehaviour
    {
        public GameplayOwner owner;
        public Color shapeColor;
        public Transform rotationPivot;
        public bool isPlaced = false;
        [HideInInspector] public SpriteRenderer spriteRenderer;

        //Shape speed varialbles
        public float fallingSpeed = 2f;

        void Awake()
        {
            fallingSpeed = Services.TrickyElements.normalFallingSpeed;
            spriteRenderer = GetComponent<SpriteRenderer>();
            AssignRandomColor();
        }

        //Shape Color Assigner
        void AssignRandomColor()
        {
            shapeColor = Services.GameService.colorService.TurnRandomColorFromTheme();
            GetComponent<SpriteRenderer>().color = shapeColor;
        }


        #region Shape Movement Funtions

        public void ShapeUpdate()
        {
            FreeFall();
        }

        public void RotateClockWise(bool isCw)
        {
            float rotationDegree = (isCw) ? 90.0f : -90.0f;

            transform.RotateAround(rotationPivot.position, Vector3.forward, rotationDegree);

            Services.GameService.SetShadowScale(owner, this);
        }

        public void MoveHorizontal(Vector2 direction)
        {
            float deltaMovement = (direction.Equals(Vector2.right)) ? 1.0f : -1.0f;

            if (Services.CameraService.IsInCamView(owner, new Vector3(transform.position.x + deltaMovement, 0, 0)))
            {
                transform.position += new Vector3(deltaMovement, 0, 0);
                Services.GameService.SetShadowPosition(owner, transform.position);
            }
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
            fallingSpeed = Services.TrickyElements.fastFallingSpeed;
        }

        public void NormalFall()
        {
            fallingSpeed = Services.TrickyElements.normalFallingSpeed;
        }

        #endregion

    }
}