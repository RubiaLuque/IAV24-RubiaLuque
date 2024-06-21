using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class MachineManager : MonoBehaviour
{
    public FSMDef definition;

    private void Awake()
    {
        
    }

    public static Action CreateAction(string name)
    {
        switch (name)
        {
            case "WanderAction":
                return new Wander();
               
            case "FollowAction":
                return new Follow();

            case "HideAction":
                return new Hide();

            default:
                Debug.Log("Action "+ name + " not existent.\n");
                return null;
        }
    }

    public static Decision CreateDecision(string name)
    {
        switch (name)
        {
            case "PlayerInSIght":
                return new GhostSight();

            case "TouchedByPlayer":
                return new GhostTouch();

            default:
                Debug.Log("Decision " + name + " not existent.\n");
                return null;
        }
    }
}


