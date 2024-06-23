using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hide : Action
{
    bool done = false;
    Spot spot;
    Vector3 pos;
    float velocity = 5f;
    public override void Execute(BaseStateMachine m)
    {
        NavMeshAgent agent = m.GetComponent<NavMeshAgent>();
        if(!done) DoOnce(agent);
        agent.SetDestination(pos);
    }

    //Este codigo solo se puede ejecutar 1 vez 
    void DoOnce(NavMeshAgent agent)
    {
        HidingSpots spotH = GameObject.Find("HidingSpots").GetComponent<HidingSpots>();
        spot = spotH.NextFreeSpot();
        spot.SetOccupied(true); //Se asigna como ocupado justo al asignar dicho spot a un fantasma
        pos = spot.transform.position;
        agent.velocity *= velocity;
        done = true;
    }
}
