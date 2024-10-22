using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.up * ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) ? 0.06f : 0.01f));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {  
            transform.Translate(Vector3.up * -(Input.GetKey(KeyCode.LeftControl) ? 0.06f : 0.01f));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward, -2);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.forward, 2);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * 0.01f);
        }
    }
}
