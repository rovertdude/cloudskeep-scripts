using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyManager : MonoBehaviour
{

    // detection variables
    [Header("Radiuses, Distance")]
    public float distance;
    public float lookRadius = 7f;
    public float hitRadius = 2f;

    [Header("Booleans")]
    public bool enemySeen;
    public bool enemyIsChasing;

    // ai & player type stuff
    [Header("Objects and Transforms")]
    public GameObject player;
    public NavMeshAgent agent;
    public Transform target;
    public Transform spawn;

    // Start is called before the first frame update
    void Start()
    {
        if (!player)
            player = GameObject.Find("RigidBodyFPSController");

        agent = GetComponent<NavMeshAgent>();
        target = player.transform;
        spawn = transform;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(target.position, transform.position);

        if (distance <= hitRadius) // enemy hit radius, if the player is in here then damage
        {
            // damage
            print("player hit");
            PlayerHit();
        }
        else if (distance <= lookRadius) // enemy sight radius, if the player is in here then chase
        {
            print("enemy seen");
            target = player.transform;
            agent.SetDestination(target.position);
            StartCoroutine(nameof(CheckForPlayer));
            enemySeen = true;
            enemyIsChasing = true;
        }
    }

    void OnDrawGizmos()
    {
        // debug purposes, shows the enemies radius for hitting and seeing the player
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, hitRadius);
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    IEnumerator CheckForPlayer()
    {
        while (enemyIsChasing)
        {
            if (distance > lookRadius)
            {
                agent.SetDestination(spawn.position);
                enemyIsChasing = false;
            }

            yield return new WaitForSeconds(3f);
        }
    }

    void PlayerHit()
    {
        GameManager.forceRestart = true;
    }
}
