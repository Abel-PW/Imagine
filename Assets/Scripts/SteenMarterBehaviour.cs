using UnityEditor.Build;
using UnityEngine;
using UnityEngine.AI;

public class SteenmarterBehaviour : MonoBehaviour
{
    public float chaseTime;
    float chaseTimer;
    bool timerActive;

    public NavMeshAgent steenmarter;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float walkPointRange;
    public Vector3 walkPoint;
    bool walkPointSet;

    public float sightRange;
    public bool playerInSightRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        steenmarter = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (playerInSightRange && timerActive)
        {
            Chase();
        }
        else
        {
            Patroling();
        }

        if ( Input.GetKey( KeyCode.E))
        {
            timerActive = true;
        }

        if (timerActive)
        {
            Timer();
        }

    }

    private void Timer()
    {
        chaseTimer += Time.deltaTime;
        if (chaseTimer >= chaseTime)
        {
            timerActive = false;
        }
    }
    private void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        else
        {
            steenmarter.SetDestination(walkPoint);

            Vector3 distanceToWalkPoint = transform.position - walkPoint;

            if(distanceToWalkPoint.magnitude < 1f)
            {
                walkPointSet = false;
            }
        }
    }
   
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        Debug.DrawRay(transform.position, -transform.up, Color.green);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }
    private void Chase()
    {
        steenmarter.SetDestination(player.position);
    }
}
