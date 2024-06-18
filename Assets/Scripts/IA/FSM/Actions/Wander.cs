using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName ="FSM/Actions/Wander")]
public class Wander : Action
{
    float tmpWander;
    float tmpRot;
    float tmpMaxRot = 1.0f;
    float tmpMaxWander = 5.0f;
    bool tReached = true;
    Rigidbody rb;

    public override void Execute(BaseStateMachine m)
    {
        rb = m.GetGameObject().GetComponent<Rigidbody>();
        NavMeshAgent agent = m.GetGameObject().GetComponent<NavMeshAgent>();
        
        agent.SetDestination(RandomNavPoint(10, -1));
    }

    

    private Vector3 RandomNavPoint(float distance, int layerMask)
    {
        Vector3 randomDir = Random.insideUnitSphere * distance;

        NavMeshHit hit;
        NavMesh.SamplePosition(randomDir, out hit, distance, layerMask);

        return hit.position;
    }
}
