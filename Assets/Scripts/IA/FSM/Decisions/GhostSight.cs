using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GhostSight : Decision
{
    public override bool Decide(BaseStateMachine m)
    {
        SightSensor sightSensor = m.GetComponent<SightSensor>();
        return sightSensor.ShootRay();
    }
}
