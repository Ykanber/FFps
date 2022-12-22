using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteEnemyBullet : MonoBehaviour
{
    public int damage = 1;
    public float bulletSpeed = 10f;
    
    Rigidbody rb;

    float time;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward* bulletSpeed;
        StartCoroutine(DestroyRoutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyRoutine()
    {
        while(time < 10)
        {
            yield return null;
            time += Time.deltaTime;
        }
        Destroy(gameObject);
    }
}
