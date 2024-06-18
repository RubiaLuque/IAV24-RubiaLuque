using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public BoxCollider box;
    public UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<SightSensor>() != null)
        {
            uiManager.DeadGhost();
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
