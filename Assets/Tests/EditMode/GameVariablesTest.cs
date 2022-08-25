using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameVariablesTest
{
    /*
    TrickyElements elements = ScriptableObject.CreateInstance<TrickyElements>();

    [Test]
    public void Total_Lifes_Test()
    {
        Assert.AreEqual(elements.totalLifes, 5);
    }

    [Test]
    public void Shapes_Spawn_Delay_Test()
    {
        Assert.AreEqual(elements.shapeSpawnDelay, 1);
    }

    [Test]
    public void Tower_Height_To_Win_Game_Test()
    {
        Assert.AreEqual(elements.winHeight, 15);
    }

    [Test]
    public void Increment_Tower_By_Level()
    {
        Assert.AreEqual(elements.incrementHeightFactor, 2);
    }

    [Test]
    public void Shape_Normal_Failling_Speed()
    {
        Assert.AreEqual(elements.normalFallingSpeed, 5);
    }

    [Test]
    public void Shape_Fast_Failling_Speed()
    {
        Assert.AreEqual(elements.fastFallingSpeed, 15);
    }

    /*
    [Header("Game Variables")]
    [HideInInspector] public float shapeSpawnDelay = 1;
    [HideInInspector] public int winHeight = 15;
    [HideInInspector] public int incrementHeightFactor = 2;
    [HideInInspector] public int totalLifes = 100;
    [HideInInspector] public float normalFallingSpeed = 5f;
    [HideInInspector] public float fastFallingSpeed = 15f;
    */
}
