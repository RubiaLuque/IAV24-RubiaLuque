using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName ="FSM/Actions/Wander")]
public class Wander : Action
{

    float tmpWander = 0f;
    float tmpRot = 0f;
    float tmpMaxRot = 1.0f;
    float tmpMaxWander = 5.0f;
    bool tReached = true;
    float minDistance = 5.0f;
    Vector3 targetPos = Vector3.zero;
    float targetDistance;
    Vector3 wanderDir = Vector3.zero;
    float wanderRadius = 2.0f;
    Rigidbody rb;
    Transform transform;

    Direction dir;

    public override void Execute(BaseStateMachine m)
    {
        dir = new Direction();
        rb = m.GetGameObject().GetComponent<Rigidbody>();
        transform = m.GetGameObject().GetComponent<Transform>();

        NavMeshAgent agent = m.GetGameObject().GetComponent<NavMeshAgent>();

        dir.angular = 0f;
        Vector3 auxDir = Vector3.zero;

        if(tmpWander > tmpMaxWander || targetDistance < minDistance)
        {
            tReached = true;
            float x = Random.Range(0.0f, 2.0f);
            float z = Random.Range(0.0f, 2.0f);

            wanderDir.x += x * RandSign();
            wanderDir.z += z * RandSign();

            wanderDir.Normalize();

            Idle();

            tmpWander = 0;
        }

        if (tReached)
        {
            tmpRot += Time.deltaTime;
            if(tmpRot > tmpMaxRot)
            {
                targetPos = transform.position + wanderDir * wanderRadius;
                tmpRot = 0;
            }

            ContinueMov();
        }
        else
        {
            wanderDir = (targetPos - transform.position).normalized;
            tmpWander += Time.deltaTime;
        }

        targetDistance = (targetPos.magnitude - wanderDir.magnitude);

        dir.linear = wanderDir;
        
        agent.SetDestination(dir.linear);
    }

    int RandSign()
    {
        int signo = Random.Range(0, 2);
        if (signo == 0) signo = -1;
        return signo;
    }

    void Idle()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    void ContinueMov()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints.None;
    }
}
