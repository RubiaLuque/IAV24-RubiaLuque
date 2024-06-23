using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightSensor : MonoBehaviour
{
    public Transform playerTransform { get; private set; }
    public LayerMask layerToIgnore;
    public float maxDistance = 100;
    public float maxAngle = 60;
    private Ray raycast;

    // Start is called before the first frame update
    void Awake()
    {
        playerTransform = GameObject.Find("PLAYER").GetComponent<Transform>();     
    }

    public bool ShootRay()
    {
        if(playerTransform == null) return false;

        //Se crea un rayo desde la posicion del fantasma hasta el player y se obtiene la direccion y el angulo con
        // su forward
        raycast = new Ray(this.transform.position, playerTransform.position - this.transform.position);
        Vector3 direction = new Vector3(raycast.direction.x, 0,  raycast.direction.z);

        float rotation = Vector3.Angle(direction, this.transform.forward);

        //Si el angulo es mayor que maxAngle no cuenta como que ha visto al jugador
        if (rotation > maxAngle) return false;

        if (!Physics.Raycast(raycast, out RaycastHit hit, maxDistance, -1)) return false;

        if (hit.collider.GetComponent<CharacterMove>()) return true;

        return false;
    }

    //Se usa para visualizar el angulo entre el raycast y el forward del fantasma
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(raycast.origin, raycast.origin + raycast.direction*maxDistance);
        Gizmos.color = Color.white;
        Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.forward*maxDistance);

    }
}
