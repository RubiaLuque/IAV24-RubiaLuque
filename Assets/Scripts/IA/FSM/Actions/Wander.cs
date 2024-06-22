using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class Wander : Action
{
    float wanderRadius;
    float wanderTimer;

    private NavMeshAgent agent;
    private float timer;
    private bool done = false;

    //Solo se hace una vez al inicio, como no es Monobehaviour, hay que hacerlo a mano
    void SetVariables(BaseStateMachine m)
    {
        wanderTimer = (float)Random.Range(2, 9);
        wanderRadius = (float)Random.Range(2, 5);
        agent = m.GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    public override void Execute(BaseStateMachine m)
    {
        if (!done) { SetVariables(m); done = true; }

        timer += Time.deltaTime;

        if(timer >= wanderTimer) {
            Vector3 newTarget = RandomNavSphere(agent.transform.position, wanderRadius, -1);
            agent.SetDestination(newTarget);
            timer = 0;
        }
    }

    //Devuelve un punto en la malla de navegación que corresponda con un punto dado de manera aleatoria del interior de una esfera

    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDir = Random.insideUnitSphere * distance;
        randomDir += origin;
        NavMeshHit navHit; 

        NavMesh.SamplePosition(randomDir, out navHit, distance, layermask);

        return navHit.position;
    }
}

