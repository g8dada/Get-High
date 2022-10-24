using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public CharacterController movement;
    public GetHighGameManager getHighGameManager;
    
    //void OnCollisionEnter(Collision collisionInfo)
    void OnTriggerEnter(Collider collisionInfo)
    {


        // if (collisionInfo.GetComponent<Collider>().tag == "Coke")
        if (movement.tag == "Coke")
        {
            movement.enabled = false;
            // FindObjectOfType<GetHighGameManager>().LevelComplete();
            getHighGameManager.LevelComplete();
            Debug.Log("LC");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
