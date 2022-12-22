using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class WhiteRobotEnemy : MonoBehaviour
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

    public float fireRate;
    bool shoot;
    Coroutine shootRoutine;
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
            ChasePlayer();
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            if (playerInAttackRange && inArea)
            {
                shoot = true;
                animator.SetBool("isShooting", true);
                Fire();
            }
            else
            {
                shoot = false;
                animator.SetBool("isShooting", false);
            }
        }
    }
    void ChasePlayer()
    {
        agent.SetDestination(Player.position);
    }

    void Fire()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(Player);
        if (shootRoutine == null)
        {
            shootRoutine = StartCoroutine(ShootRoutine());
        }
    }
    
    IEnumerator ShootRoutine()
    {
        while (shoot)
        {
           GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, transform.localRotation);
            bullet.GetComponent<WhiteEnemyBullet>().damage = damageAmount;
            yield return new WaitForSecondsRealtime(1 / fireRate);
        }
        shootRoutine = null;
    }

    public void Die()
    {
        death = true;
        shoot = false;
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
