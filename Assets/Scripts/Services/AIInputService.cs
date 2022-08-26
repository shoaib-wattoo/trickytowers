using UnityEngine;
using System.Collections;
using MiniClip.Challenge.Gameplay;

namespace MiniClip.Challenge.ProjectServices
{
    public class AIInputService : MonoBehaviour
    {
        public bool isActive;
        public GameplayManager gameplayManager;

        private float nextActionTime = 5f;
        public float period = 2f;

        private void Update()
        {
            if (!isActive || !gameplayManager)
                return;

            if (Time.time > nextActionTime)
            {
                nextActionTime += period;

                RandomInput();
            }
        }

        #region Random Input
        void RandomInput()
        {
            int RandomInput = Random.Range(1, 9);

            switch (RandomInput)
            {
                case 1:
                    RotateClockWise(true);
                    break;
                case 2:
                    MoveHorizontal(Vector2.left);
                    break;
                case 3:
                    MoveHorizontal(Vector2.left);
                    break;
                case 4:
                    MoveHorizontal(Vector2.right);
                    break;
                case 5:
                    MoveHorizontal(Vector2.right);
                    break;
                case 6:
                    InstantFall();
                    break;
                case 7:
                    NormalFall();
                    break;
                case 8:
                    NormalFall();
                    break;
            }

        }
        #endregion


        #region Direction Callbacks

        private void MoveHorizontal(Vector2 vector2)
        {
            if (Services.GameService.gameStatus != GameStatus.ONGOING)
                return;

            if (gameplayManager.currentShape != null)
                gameplayManager.currentShape.MoveHorizontal(vector2);
        }

        private void InstantFall()
        {
            if (Services.GameService.gameStatus != GameStatus.ONGOING)
                return;

            if (gameplayManager.currentShape != null)
                gameplayManager.currentShape.InstantFall();
        }

        private void NormalFall()
        {
            if (Services.GameService.gameStatus != GameStatus.ONGOING)
                return;

            if (gameplayManager.currentShape != null)
                gameplayManager.currentShape.NormalFall();
        }

        private void RotateClockWise(bool rotateClockwise)
        {
            if (Services.GameService.gameStatus != GameStatus.ONGOING)
                return;

            if (gameplayManager.currentShape != null)
                gameplayManager.currentShape.RotateClockWise(rotateClockwise);
        }
        #endregion

    }
}