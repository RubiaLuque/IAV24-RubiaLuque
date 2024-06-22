using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;

    [SerializeField]
    float offset = 5.15f;

    private float zoom = 10f;
    private float zoomAmount = 40f;

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 pos = target.position;
            Vector3 smoothPos = Vector3.Lerp(transform.position, pos, smoothSpeed);

            //Desliza la posici�n de la c�mara hacia el target
            transform.position = new Vector3(smoothPos.x, transform.position.y, smoothPos.z - offset);

            //Alterna la distancia al target en funci�n del input de la rueda del rat�n
            HandleZoom();
        }
    }

    private void HandleZoom()
    {
        if (Input.mouseScrollDelta.y > 0)
            zoom -= zoomAmount * Time.deltaTime;
        if (Input.mouseScrollDelta.y < 0)
            zoom += zoomAmount * Time.deltaTime;

        zoom = Mathf.Clamp(zoom, 5f, 50f);
        Camera.main.fieldOfView = zoom;
    }
}