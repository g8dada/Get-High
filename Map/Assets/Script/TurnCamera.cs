using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TurnCamera : MonoBehaviour
{
    public CharacterController controller;
    public CinemachineFreeLook freelook;
    public ThirdPersonMovement thirdPersonMovement;
    public PressKeyOpenDoor pressKeyOpenDoor;
    private float rotating_speed = 0.5f;

    private float spinningAngle = 0;
    private float spinAmount = 0.5f;
    private float spinningAnglePre = 0;
    public bool flag = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (thirdPersonMovement.isSpinning)
        {
            if (flag)
            {
                spinningAngle = transform.rotation.eulerAngles.y;
                spinningAnglePre = spinningAngle;
                flag = false;
                Debug.Log("fuck");
            }
            

            
            freelook.m_Heading.m_Bias = spinningAngle;
            transform.rotation = Quaternion.Euler(0f, spinningAngle, 0f);

            spinningAngle += rotating_speed;






            // Debug.Log(spinningAngle);
            Debug.Log(spinningAngle - spinningAnglePre);
            



            if (spinningAngle - spinningAnglePre >= 360 * spinAmount)
            {
                controller.enabled = true;
                // Debug.Log(spinningAngle);
                // spinningAngle = 0;
                // Debug.Log(spinningAngle);

                thirdPersonMovement.isSpinning = false;
                
                flag = true;
            }
        }
        
        
        
    }

}