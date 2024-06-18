using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/Actions/Follow")]
public class Follow : Action
{
    public override void Execute(BaseStateMachine m)
    {
        NavMeshAgent agent = m.GetGameObject().GetComponent<NavMeshAgent>();
        SightSensor sight = m.GetGameObject().GetComponent<SightSensor>();

        agent.SetDestination(sight.playerTransform.position);
    }
}
