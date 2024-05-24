using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    CharacterController controller;
    Animator animator;
    Transform transform;

    [SerializeField]
    float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move;
        animator.Play("Idle");
    
        if (Input.GetKey(KeyCode.W))
        {
            move = transform.forward;
            transform.Translate(speed * move * Time.deltaTime);
            animator.Play("RunForward");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            move = transform.forward * (-1);
            transform.Translate(move * Time.deltaTime * speed);
            animator.Play("RunBackward");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(new Vector3(0, 1, 0), -1);
            animator.Play("RunForward");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(new Vector3(0, 1, 0), 1);
            animator.Play("RunForward");
        }
    }
}
