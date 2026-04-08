using UnityEditor.Build;
using UnityEngine;
using UnityEngine.AI;

public class SteenmarterBehaviour : MonoBehaviour
{
    public float chaseTime;

    private float chaseTimer;
    private bool timerActive;

    public NavMeshAgent steenmarter;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float jumpHeight;
    private Vector3 jump;

    public float walkPointRange;
    private Vector3 walkPoint;
    private bool walkPointSet;

    public float sightRange, attackRange;
    private bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        steenmarter = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInSightRange && timerActive)
        {
            Chase();
        }
        
        if (playerInAttackRange && timerActive)
        {
            Attack();
        }
        else
        {
            Patroling();
        }

        if ( Input.GetKey( KeyCode.E ) )
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
            chaseTimer = 0;
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

        if (Physics.Raycast(walkPoint, -transform.up, 6, whatIsGround))
        {
            walkPointSet = true;
        }
    }
    private void Chase()
    {
        steenmarter.SetDestination(player.position);
    }

    private void Attack()
    {
     jump = new Vector3(transform.position.x, transform.position.y + jumpHeight, transform.position.z);  
    }
}
