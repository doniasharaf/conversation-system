using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Walk : MonoBehaviour
{
    public Animator animator;
    NavMeshAgent agent;
    bool isWalking = false;

  

    void Update()
    {
        if (isWalking && agent.remainingDistance >= 0 && agent.remainingDistance <= agent.stoppingDistance)
        {
            StopWalking();
        }
    }
    public void StartWalking(NavMeshAgent agent)
    {
        Debug.Log("Start walking.");
        this.agent = agent;
        isWalking = true;
        animator.SetBool("isIdle", false);
    }
    public void StartWalking()
    {
        Debug.Log("Start walking.");

        animator.SetBool("isIdle", false);
    }
    public void StopWalking()
    {
        Debug.Log("Stop walking.");

        isWalking = false;
        animator.SetBool("isIdle", true);
    }
}
