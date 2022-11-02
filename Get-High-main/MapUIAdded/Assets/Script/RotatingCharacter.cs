using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCharacter : MonoBehaviour
{
    public GameObject player;
    private float turnto = 0;
    public float rotating_speed = 0.7f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(5.0f);

        if (turnto < 360 * 6)
        {
            transform.rotation = Quaternion.Euler(0f, turnto, 0f);
            turnto = turnto + rotating_speed;
        }
        yield return null;
    

        // yield return new WaitForSeconds(5.0f);
    

        // if (turnto > 0)
        // {
        //     transform.rotation = Quaternion.Euler(0f, turnto, 0f);
        //     turnto = turnto - 0.5f;
            
        // }

        // yield return null;
    }
}