using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour
{
    public HidingSpots hidingSpots;

    public bool occupied = false;

    public void SetOccupied(bool _occupied) { occupied = _occupied; }

    // Start is called before the first frame update
    void Awake()
    {
        hidingSpots = GameObject.Find("HidingSpots").GetComponent<HidingSpots>();
        hidingSpots.spots.Add(this);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<BaseStateMachine>() != null && 
            other.GetComponent<BaseStateMachine>().StateToString() == "HideState" && !occupied)
        {
                occupied = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<BaseStateMachine>() != null &&
            other.GetComponent<BaseStateMachine>().StateToString() == "Follow" && !occupied)
        {
            occupied = false;
        }
    }
}
