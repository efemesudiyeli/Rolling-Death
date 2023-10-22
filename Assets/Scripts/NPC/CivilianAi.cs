using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CivilianAi : MonoBehaviour
{

    [SerializeField] Transform player;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] LayerMask whatIsGround, whatIsPlayer;

    private PlayerScore playerScore;
    private Vector3 oppositeDirection;

    private AudioSource audioSource;
    [SerializeField] AudioClip dieSound;

    // States
    public float sightRange, attackReceiveRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        audioSource = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
        audioSource.clip = dieSound;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerScore = GameObject.FindGameObjectWithTag("Canvas").GetComponent<PlayerScore>();

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for sight and attack range;
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackReceiveRange, whatIsPlayer);

        if (playerInSightRange) RunFromPlayer();
        if (playerInAttackRange) Die();

    }

    void RunFromPlayer()
    {
        Debug.Log("Running");
        // Run from players opposite direction
        oppositeDirection = -player.transform.forward;

        // Select random location
        float randomZ = oppositeDirection.z * Random.Range(1, 1000);
        float randomX = oppositeDirection.x * Random.Range(1, 1000);

        // Go to selected location
        agent.SetDestination(new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ));

    }

    void Die()
    {
        // Play die sound with random pitch.
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.Play();

        // Die
        Destroy(gameObject);
        playerScore.AddScore(1);

    }

}
