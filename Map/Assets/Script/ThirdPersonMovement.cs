using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public TurnCamera turnCamera;
    public Transform cam;

    public float speed = 6.0f;
    public float turnSmoothTime = 0.2f;
    private float turnSmoothVelocity;

    private Vector3 spinningRoomPosition = new Vector3 (10f, 0f, -50f);

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
            if ((transform.position - spinningRoomPosition).magnitude <= 0.01f)
            {
                isSpinning = true;
            }
        }
        
    }
}
