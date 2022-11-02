using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PressKeyOpenDoor : MonoBehaviour {

    //public GameObject Instruction;
    public GameObject AnimeObject;
    public CharacterController controller;
    public ThirdPersonMovement thirdPersonMovement;
    // private TurnCamera turnCamera;

    public bool Action = false;
    public bool oddTimeOpenDoor = false;
    
    void Start()
    {

    }
    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            Action = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        Action = false;
    }

    // Update is called once per frame
    void Update() 
    {
        if (Input.GetKeyDown("space") && Action == true)
        {
            Action = false;

            if (oddTimeOpenDoor == false && AnimeObject.tag == "Spinning Tag")
            {
                controller.enabled = false;
            }

            oddTimeOpenDoor = !oddTimeOpenDoor;

            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        // Debug.Log(door.name)
        AnimeObject.GetComponent<Animator>().Play("DoorOpen");
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1.0f);
        yield return new WaitForSeconds(2.0f);
        yield return new WaitForSeconds(1.0f);
        AnimeObject.GetComponent<Animator>().Play("New State");
    }
}
    