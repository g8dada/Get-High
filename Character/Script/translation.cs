using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translation : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        // Translation
        if(Input.GetKey("w"))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);   
        else if(Input.GetKey("s"))
            transform.Translate(Vector3.forward * -moveSpeed * Time.deltaTime); 
        else if(Input.GetKey("a"))
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        else if(Input.GetKey("d"))
            transform.Translate(Vector3.left * -moveSpeed * Time.deltaTime);
    }
}
