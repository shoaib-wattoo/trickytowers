using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniClip.Challenge.ProjectServices;

namespace MiniClip.Challenge.Gameplay
{
    public class GameFinishController : MonoBehaviour
    {
        public GameplayOwner owner;
        public int countDown = 5;
        public List<TrickyShape> shapesReachedFinish;

        private float nextActionTime = 1f;
        public float period = 1f;

        void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Triggr Enter : " + other.gameObject.name);

            TrickyShape shape = other.GetComponent<TrickyShape>();

            if (shape != null)
            {
                shapesReachedFinish.Add(shape);
            }
        }

        private void Update()
        {
            if (Time.time > nextActionTime)
            {
                nextActionTime += period;

                if (GetCountofShapesReachedFinish() > 0)
                {
                    countDown--;
                    Services.UIService.GamePlayScreen.SetCountdownText(owner, countDown);

                    if (countDown == 0)
                    {
                        Services.GameService.GetPlayerManager(owner).MakeAllPlacedShapesStatic();
                        Services.GameService.GetPlayerManager(owner).DestroyCurrentShape();
                        Services.GameService.GetPlayerManager(owner).SpawnFinalShape();
                    }
                }
                else
                {
                    countDown = 5;
                    Services.UIService.GamePlayScreen.EnableCountdownText(owner, false);
                }
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log("Triggr Exit : " + other.gameObject.name);

            shapesReachedFinish.Remove(other.GetComponent<TrickyShape>());

            int placedShapes = GetCountofShapesReachedFinish();

            if (placedShapes == 0)
            {
                countDown = 5;
                Services.UIService.GamePlayScreen.EnableCountdownText(owner, false);
            }
        }

        int GetCountofShapesReachedFinish()
        {
            return shapesReachedFinish.FindAll(x => x.isPlaced).Count;
        }
    }
}
