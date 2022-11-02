using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TurnCamera : MonoBehaviour
{
    public GameObject player;
    public CharacterController controller;
    public Camera camera;
    // public CinemachineFreeLook freelook;
    public ThirdPersonMovement thirdPersonMovement;
    public PressKeyOpenDoor pressKeyOpenDoor;
    private float rotating_speed = 0.5f;

    private float spinningAngle = 0;
    private float spinningAngleInRange;
    private float spinAmount = 1.5f;
    private float spinningAnglePre = 0;
    public bool flag = true;

    private float speedMod = 10.0f; //a speed modifier
    private Vector3 point; //the coord to the point where the camera looks at
    private float angleEnd = 0f;
    public bool startSpinning = false;

    private float angleInitial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (thirdPersonMovement.isSpinning)
        { 
            camera.GetComponent<CinemachineBrain>().enabled = false;
            
            if (angleEnd < 180) //angleEnd < 360
            {
                if (flag)
                {
                    angleInitial = transform.rotation.eulerAngles.y;
                    point = player.transform.position; //get target's coords
                    transform.LookAt(point); //makes the camera look to it
                    flag = false;
                }
                controller.transform.rotation = Quaternion.Euler(0f, angleInitial + angleEnd, 0f);
                transform.RotateAround(point, new Vector3(0.0f, 1.0f, 0.0f), 20 * Time.deltaTime * speedMod);   // relatively
                angleEnd += 20 * Time.deltaTime * speedMod;
            }
            else
            {
                camera.GetComponent<CinemachineBrain>().enabled = true;
                flag = true;
                controller.enabled = true;
            }



            
            
            
            
            
            // Debug.Log("hihihihihi");

            // if (flag)
            // {
            //     // spinningAngle = transform.rotation.eulerAngles.y;
            //     // spinningAnglePre = spinningAngle;
            //     flag = false;
            //     // Debug.Log("fuck");
            // }


//--------------------------------------------------------------------------------------------------------------------------


        //     spinningAngleInRange = spinningAngle;
            
        //     if (spinningAngleInRange >= 180)
        //     {
        //         spinningAngleInRange = spinningAngleInRange % 360 - 180;
        //     }
    
        //     freelook.m_Heading.m_Bias = spinningAngleInRange;
        //     transform.rotation = Quaternion.Euler(0f, spinningAngleInRange, 0f);
        //     spinningAngle += rotating_speed;

        //     // Debug.Log(spinningAngle);
        //     Debug.Log(spinningAngle - spinningAnglePre);
            
        //     if (spinningAngle - spinningAnglePre >= 360 * spinAmount)
        //     {
                
        //         controller.enabled = true;
        //         freelook.m_Heading.m_Bias = spinningAngle % 360 - 180;
        //         thirdPersonMovement.isSpinning = false;
        //         flag = true;
        //     }
//-------------------------------------------------------------------------------------------------------------------------- 
        }
        
    }

}