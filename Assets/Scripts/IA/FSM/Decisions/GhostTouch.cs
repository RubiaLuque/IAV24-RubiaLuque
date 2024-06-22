using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GhostTouch : Decision
{
    public override bool Decide(BaseStateMachine m)
    {
        TouchSensor touchSensor = m.GetComponent<TouchSensor>();
        return touchSensor.IsPlayer();
    }
}
