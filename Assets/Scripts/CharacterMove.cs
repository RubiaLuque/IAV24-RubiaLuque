using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    CharacterController controller;
    public Animator animator;

    [SerializeField]
    float speed = 5f;

    [SerializeField]
    float rotationSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move;
    
        if (Input.GetKey(KeyCode.W))
        {
            move = transform.forward;
            controller.Move(speed * move.normalized * Time.deltaTime);
            //transform.position = this.transform.position + speed * move.normalized * Time.deltaTime;
            animator.SetBool("runForward", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            move = transform.forward * (-1);
            controller.Move(speed * move.normalized * Time.deltaTime);
            animator.SetBool("runBackward", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 1, 0), -1 * Time.deltaTime * rotationSpeed);
            animator.SetBool("runForward", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 1, 0), Time.deltaTime* rotationSpeed);
            animator.SetBool("runForward", true);
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("attacking");
            animator.SetBool("runForward", false);
            animator.SetBool("runBackward", false);
        }
        else
        {
            animator.SetBool("runForward", false);
            animator.SetBool("runBackward", false);
            animator.SetBool("dead", false); //Quitar esta linea despues
        }
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 4);
    }
}
