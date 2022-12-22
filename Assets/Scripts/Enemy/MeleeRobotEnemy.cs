using UnityEngine;
using UnityEngine.AI;
using System;

public class MeleeRobotEnemy : MonoBehaviour
{
    public int damageAmount = 2;
    public int expAmount = 10;

    public NavMeshAgent agent;

    Transform Player;
    Player player;

    public LayerMask whatIsPlayer;

    public Vector3 characterCenter;

    public float attackRange;
    public bool playerInAttackRange;

    Animator animator;


    void Awake()
    {
        Player = GameObject.Find("Player").transform;
        player = Player.GetComponent<Player>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position + characterCenter, attackRange, whatIsPlayer);
        transform.LookAt(Player);
        if (playerInAttackRange)
        {
            animator.SetBool("isAttacking",true);
            Attack();
        }
        else
        {
            animator.SetBool("isAttacking",false);
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        agent.SetDestination(Player.position);
    }

    void Attack()
    {
        agent.SetDestination(transform.position);
    }

    public void DamagePlayer()
    {
        if (Physics.CheckSphere(transform.position + characterCenter, attackRange, whatIsPlayer) && Player != null)
        {
            Player.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
        }
    }

    public void Die()
    {
        agent.isStopped = true;
        player.addExperience(expAmount);
        int random = UnityEngine.Random.Range(0, 10);
        if(random == 0)
        {
            player.IncreaseUpgradeMaterial();
        }
        Destroy(gameObject,2.05f);
    }
}
