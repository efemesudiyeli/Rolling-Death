using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{

    [SerializeField] Transform player;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] LayerMask whatIsGround, whatIsPlayer;

    [SerializeField] float attackCooldown = 10;
    [SerializeField] bool canAttack = true;

    [SerializeField] Animator animator;

    private PlayerHP playerHP;
    // States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHP>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Check for sight and attack range;
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();

    }

    void ChasePlayer()
    {
        agent.SetDestination(player.position);
        Debug.Log("Chasing...");
        animator.SetBool("isReachedToPlayer", false);
    }

    void AttackPlayer()
    {
        // Stop moving.
        agent.SetDestination(transform.position);
        animator.SetBool("isReachedToPlayer", true);
        transform.LookAt(new Vector3(player.transform.position.x, agent.transform.position.y, player.transform.position.z));
        Debug.Log("Attacking!");

        if (canAttack)
        {
            Debug.Log("Attacked");
            animator.SetBool("isAttacked", true);
            playerHP.DamagePlayer(25);
            StartCoroutine(AttackCooldownCoroutine(attackCooldown));
        }
    }

    IEnumerator AttackCooldownCoroutine(float attackCooldown)
    {

        Debug.Log("Cooldown initiated.");
        canAttack = false;
        yield return new WaitForSeconds(1);
        animator.SetBool("isAttacked", false);

        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }



}
