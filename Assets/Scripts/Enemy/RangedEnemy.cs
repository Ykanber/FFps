using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class RangedEnemy : MonoBehaviour
{

    // attack and die
    public int damageAmount = 5;
    public int expAmount = 20;

    public NavMeshAgent agent;

    Transform Player;
    Player player;

    public LayerMask whatIsPlayer;

    // Attack
    [SerializeField] Transform shootingPoint;
    [SerializeField] GameObject bulletPrefab;

    public bool inArea;

    public float attackRange;
    public bool playerInAttackRange;


    Animator animator;

    bool death;
    void Awake()
    {
        Player = GameObject.Find("Player").transform;
        player = Player.GetComponent<Player>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!death)
        {
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            if (playerInAttackRange && inArea)
            {
                animator.SetBool("isShooting", true);
                agent.SetDestination(transform.position);
            }
            else
            {
                animator.SetBool("isShooting", false);
                agent.SetDestination(Player.position);
            }
        }
    }

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, transform.localRotation);
        bullet.GetComponent<WhiteEnemyBullet>().damage = damageAmount;
    }

    public void Die()
    {
        death = true;
        agent.isStopped = true;
        player.addExperience(expAmount);
        int random = UnityEngine.Random.Range(0, 10);
        if (random == 0)
        {
            player.IncreaseUpgradeMaterial();
        }
        Destroy(gameObject, 2.05f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RangedAttackArea"))
        {
            inArea = true;
        }
    }
}
