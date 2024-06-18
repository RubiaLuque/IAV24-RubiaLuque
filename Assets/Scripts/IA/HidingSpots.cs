using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpots : MonoBehaviour
{
    public List<Spot> spots = new List<Spot>();

    public Spot NextFreeSpot()
    {
        int i = 0;
        while (i<spots.Count)
        {
            int aux = Random.Range(0, spots.Count);
            
            if (!spots[aux].occupied) return spots[aux];
            ++i;
        }
        return null;
    }
}
