using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinishController : MonoBehaviour
{
    public GameplayOwner owner;
    public float countDown = 5f;
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

                if(countDown == 0){
                    countDown = 0;

                    Services.GameService.OnGameFinish(owner, true);
                }
            }
            else
            {
                countDown = 5f;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Triggr Exit : " + other.gameObject.name);

        shapesReachedFinish.Remove(other.GetComponent<TrickyShape>());

        int placedShapes = GetCountofShapesReachedFinish();

        if (placedShapes == 0)
            countDown = 5;
    }

    int GetCountofShapesReachedFinish()
    {
        return shapesReachedFinish.FindAll(x => x.isPlaced).Count;
    }
}
