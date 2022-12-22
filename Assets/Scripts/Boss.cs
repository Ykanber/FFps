using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{


    public static void Death()
    {

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.BossIsDead();
    }
}
