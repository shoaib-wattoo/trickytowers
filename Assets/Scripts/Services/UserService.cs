using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserService : MonoBehaviour
{
    public PlayerStats stats;

    public void SetUserName(string name)
    {
        stats.name = name;
    }

    public string GetUserName()
    {
        return stats.name;
    }
}
