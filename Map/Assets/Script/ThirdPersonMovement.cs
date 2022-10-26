using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public TurnCamera turnCamera;
    public CinemachineFreeLook freelook;
    public Transform cam;

    public Rigidbody rb;
    private bool lc = false;



    public float speed = 6.0f;
    public float turnSmoothTime = 0.2f;
    private float turnSmoothVelocity;

    private Vector3 spinningRoomPosition = new Vector3 (30f, 0f, 10f);

    public bool isSpinning = false;

    void Start()
    {
        // controller.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        // controller.enabled = true;
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (rb.position.x <= 32 && rb.position.x >=28 && rb.position.z <= 52 && rb.position.z >= 48 && lc == false)
        {
            FindObjectOfType<GameManager>().LevelComplete();
            lc = true;
        }

        if (direction.magnitude >= 0.1f && controller.enabled)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        if (!controller.enabled)
        {
            // delay
            
            transform.position = Vector3.MoveTowards(transform.position, spinningRoomPosition, Time.deltaTime * speed);
            
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
                isSpinning = true;
            }
        }
        
    }
}
