using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public Transform blockHolder;
    public GameObject cloud;
    SpawnManager spawnManager;
    public GameplayOwner owner;

    void Start()
    {
        if (owner == GameplayOwner.Player)
            Services.GameService.myGameplayManager = this;
        else
            Services.GameService.opponentGameplayManager = this;

        if (cloud != null)
        {
            cloud.GetComponent<Rigidbody2D>().velocity = new Vector2(0.1f, 0.0f);
        }

        spawnManager = GetComponent<SpawnManager>();
    }

    public void SpawnShape()
    {
        spawnManager.Spawn(blockHolder, owner);
    }
}
