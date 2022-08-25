using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using MiniClip.Challenge.ProjectServices;

namespace MiniClip.Challenge.Gameplay
{
    public class TrickyShape : MonoBehaviour
    {
        public bool isPlaced = false;
        public GameplayOwner owner;
        public Color shapeColor;
        public Transform rotationPivot;
        public SpriteRenderer spriteRenderer;
        public bool isFinalShape;

        //Shape speed varialbles
        public float fallingSpeed = 2f;

        void OnEnable()
        {
            fallingSpeed = Services.TrickyElements.normalFallingSpeed;
            GetComponent<Rigidbody2D>().gravityScale = 0f;
            isPlaced = false;
        }

        //Shape Color Assigner
        public void AssignShapeColor(Color color)
        {
            shapeColor = color;
            GetComponent<SpriteRenderer>().color = shapeColor;
        }


        #region Shape Movement Funtions

        public void ShapeUpdate()
        {
            FreeFall();
        }

        public void RotateClockWise(bool isCw)
        {
            //To stop rotation of shape in pause mode
            if (Services.GameService.gameStatus != GameStatus.ONGOING || isFinalShape)
                return;

            float rotationDegree = (isCw) ? 90.0f : -90.0f;

            transform.RotateAround(rotationPivot.position, Vector3.forward, rotationDegree);

            Services.GameService.SetShadowScale(owner, this);
        }

        public void MoveHorizontal(Vector2 direction)
        {
            if (isFinalShape)
                return;

            float deltaMovement = (direction.Equals(Vector2.right)) ? 0.5f : -0.5f;

            if (Services.CameraService.IsInCamView(owner, new Vector3(transform.position.x + deltaMovement, 0, 0)))
            {
                transform.position += new Vector3(deltaMovement, 0, 0);
                Services.GameService.SetShadowPosition(owner, transform.position);
                Services.GameService.SetShadowScale(owner, this);
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