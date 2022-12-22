using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAreaCheck : MonoBehaviour
{
    public WhiteRobotEnemy WhiteRobotEnemy;
    public RangedEnemy rangedEnemy;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("123");
        if (other.CompareTag("RangedAttackArea"))
        {
            if (WhiteRobotEnemy != null)
            {
                WhiteRobotEnemy.inArea = true;
            }
            else if (rangedEnemy != null)
            {
                rangedEnemy.inArea = true;
            }
       }
    }
}
