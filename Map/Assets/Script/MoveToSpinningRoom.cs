using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MoveToSpinningRoom : MonoBehaviour
{
    public CharacterController controller;
    public CinemachineFreeLook freelook;
    public ThirdPersonMovement thirdPersonMovement;
    public TurnCamera turnCamera;

    private Vector3 spinningRoomPosition = new Vector3 (30f, 0f, 10f);

    public float speed = 6.0f;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.enabled == false && turnCamera.flag == true)
        {
            // delay

            transform.position = Vector3.MoveTowards(transform.position, spinningRoomPosition, Time.deltaTime * speed);
            

            // float turnTime = 50f;
            // Quaternion target = Quaternion.Euler(mainCamera.eulerAngles.x, mainCamera.eulerAngles.y, 0f);
            // transform.rotation = Quaternion.RotateTowards(transform.rotation, target, turnTime * Time.deltaTime);
            
            

            // float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            // float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            // transform.rotation = Quaternion.Euler(0f, angle, 0f);
            // Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            // controller.Move(moveDir.normalized * speed * Time.deltaTime);



            if (freelook.m_Heading.m_Bias > transform.eulerAngles.y)
            {
                freelook.m_Heading.m_Bias -= 1.0f;
            }
            else
            {
                freelook.m_Heading.m_Bias += 1.0f;
            }


            if ((transform.position - spinningRoomPosition).magnitude <= 0.01f && Mathf.Abs(freelook.m_Heading.m_Bias - transform.eulerAngles.y) <= 1.0f)
            {
                freelook.m_Heading.m_Bias = transform.eulerAngles.y;
                thirdPersonMovement.isSpinning = true;
            }




            // if ((transform.position - spinningRoomPosition).magnitude <= 0.01f)
            // {
            //     freelook.m_Heading.m_Bias = transform.eulerAngles.y;
            //     isSpinning = true;
            // }
        }
    }
}
