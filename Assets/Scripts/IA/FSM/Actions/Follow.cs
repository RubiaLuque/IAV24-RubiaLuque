using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : Action
{
    public override void Execute(BaseStateMachine m)
    {
        NavMeshAgent agent = m.GetComponent<NavMeshAgent>();
        SightSensor sight = m.GetComponent<SightSensor>();

        agent.SetDestination(sight.playerTransform.position - new Vector3(0,0, 2));
    }
}
