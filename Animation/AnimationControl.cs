using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public Animator animator;
    void Update()
    {
        if(Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("Moving", true);
            animator.SetBool("isBackward", false);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            animator.SetBool("Moving", false);
            animator.SetBool("isBackward", true);
        }
        else
        {
            animator.SetBool("Moving", false);
            animator.SetBool("isBackward", false);
        }
    }
}
