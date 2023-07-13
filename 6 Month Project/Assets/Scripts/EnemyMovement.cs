using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private float attackRadius, attackDuration, stopTimer;
    [SerializeField]
    private GameObject player;
    private bool attacking = false;
    [SerializeField]
    private EnemyAttack eA;
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.stoppingDistance = attackRadius;
        agent.SetDestination(player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        bool withinAttackRadius = agent.remainingDistance < agent.stoppingDistance;
        if((!withinAttackRadius) && stopTimer <= 0 && !attacking)
        {
            agent.SetDestination(player.transform.position);
        }
        else if (stopTimer<=0 && !attacking){
            agent.ResetPath();
            stopTimer = attackDuration;
            StartCoroutine(eA.attack());
            attacking = true;
        }
        else if(stopTimer <= 0 && attacking){
            attacking = false;
            agent.SetDestination(player.transform.position);
        }
        else
        {
            stopTimer -= Time.deltaTime;
        }
    }

}
