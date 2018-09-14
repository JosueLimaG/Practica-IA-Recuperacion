using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public Transform[] puntos;
    private int destino = 0;
    private NavMeshAgent agent;
    Transform player;
    RaycastHit hit;
    Ray ray;
    public float maxRange = 50;
    bool seguirJugador = false;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        SiguientePunto();
	}

    void SiguientePunto()
    {
        agent.destination = puntos[destino].position;
        destino = (destino + 1) % puntos.Length;
    }
	
	void Update ()
    {
        if(!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            SiguientePunto();
        }
        if (Vector3.Distance(transform.position, player.position) < maxRange)
        {
            if (Physics.Raycast(transform.position, (player.position - transform.position), out hit, maxRange))
            {
                if (hit.transform == player)
                {
                    seguirJugador = true;
                }
            }
        }

        if (seguirJugador)
        {
            GetComponent<NavMeshAgent>().destination = player.position;
        }
    }
}
