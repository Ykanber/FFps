using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    GameObject Player;


    float time;
    [SerializeField] float duration;

    private void Awake()
    {
        Player = FindObjectOfType<Player>().gameObject;
    }


    private void Update()
    {
        transform.position += new Vector3(0, 20, 0) * Time.deltaTime; 
        time += Time.deltaTime;
        transform.LookAt(Player.transform);
        transform.localEulerAngles = new Vector3(0, 180f, 0);
        if(time >= duration)
        {
            Destroy(gameObject);
        }
    }
}
