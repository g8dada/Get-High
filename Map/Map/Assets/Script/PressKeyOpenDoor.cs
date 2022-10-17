using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKeyOpenDoor : MonoBehaviour {

    //public GameObject Instruction;
    public GameObject AnimeObject;
    public bool Action = false;

    void Start()
    {
       //Instruction.SetActive(false); 
    }
    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            //Instruction.SetActive(true);
            Action = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        //Instruction.SetActive(false);
        Action = false;
    }

    // Update is called once per frame
    void Update() 
    {
        if (Input.GetKeyDown("space"))
        {
            if(Action == true)
            {
                //Instruction.SetActive(false);
                //AnimeObject.GetComponent<Animator>().Play("DoorOpen");
                StartCoroutine(OpenDoor());
                Action = false;
            }
        }
    }

    IEnumerator OpenDoor()
    {
        //Debug.Log(door.name)
        AnimeObject.GetComponent<Animator>().Play("DoorOpen");
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(5.0f);
        AnimeObject.GetComponent<Animator>().Play("New State");
    }
}
    