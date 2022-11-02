using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log(animator);
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool backwardPressed = Input.GetKey("s");
        bool runPressed = Input.GetKey("left shift");
        bool turnPressed = Input.GetKey("a");
        bool isWalking = animator.GetBool("isWalking");
        bool isRunning = animator.GetBool("isRunning");
        bool isBackward = animator.GetBool("isBackward");
        bool isTurning = animator.GetBool("isTurning");

        if(!isWalking && forwardPressed)
        {
            animator.SetBool("isWalking", true);
        }
        if(isWalking && !forwardPressed)
        {
            animator.SetBool("isWalking", false);
        }
        if(forwardPressed && runPressed)
        {
            animator.SetBool("isRunning", true);
        }
        if(!forwardPressed || !runPressed)
        {
            animator.SetBool("isRunning", false);
        }
        if(!isBackward && backwardPressed)
        {
            animator.SetBool("isBackward", true);
        }
        if(isBackward && !backwardPressed)
        {
            animator.SetBool("isBackward", false);
        }
        if(!isTurning && turnPressed)
        {
            animator.SetBool("isTurning", true);
        }
        if(isTurning && !turnPressed)
        {
            animator.SetBool("isTurning", false);
        }
    }
}
