using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/Ghost Sight")]
public class GhostSight : Decision
{
    public override bool Decide(BaseStateMachine m)
    {
        SightSensor sightSensor = m.GetComponent<SightSensor>();
        return sightSensor.ShootRay();
    }
}
