using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TouchSensor : MonoBehaviour
{
    bool isPlayer = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponentInChildren<CharacterMove>())
        {
            isPlayer = true;
        }

        else isPlayer = false;
    }

    public bool IsPlayer() {  return isPlayer; }
}