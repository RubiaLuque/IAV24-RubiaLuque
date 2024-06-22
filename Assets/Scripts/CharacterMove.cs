using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    CharacterController controller;
    public Animator animator;

    [SerializeField]
    float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.forward = Vector3.forward;

            controller.Move(speed * transform.forward * Time.deltaTime);
            animator.SetBool("runForward", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.forward = Vector3.back;
            controller.Move(speed * transform.forward * Time.deltaTime);
            animator.SetBool("runForward", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.forward = Vector3.left;
            controller.Move(speed * transform.forward * Time.deltaTime);
            animator.SetBool("runForward", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.forward = Vector3.right;

            controller.Move(speed * transform.forward * Time.deltaTime);
            animator.SetBool("runForward", true);
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("attacking");
            animator.SetBool("idling", true);
            animator.SetBool("runForward", false);
            animator.SetBool("runBackward", false);
        }
        else
        {
            animator.SetBool("idling", true);
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
