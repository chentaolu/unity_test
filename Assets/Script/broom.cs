using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class broom : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody rigi;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello");
        rigi = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        rigi.AddForce(new Vector3(0, -80, 0), ForceMode.Force);
        

        if ( Input.GetKey("up")) {  
            transform.Translate (speed, 0, 0);;
            rigi.AddForce(new Vector3(0, 0, 50), ForceMode.Force);  
            //transform.Translate(speed, 0, 0);
        }

        if ( Input.GetKey("down")) {  rigi.AddForce(new Vector3(0, 0, -50), ForceMode.Force);  }

        if ( Input.GetKey("left")) {  transform.Rotate(0, -0.5f, 0);  }

        if ( Input.GetKey("right")) {  transform.Rotate(0, 0.5f, 0);  }        

        if ( Input.GetKey("z")) {  this.gameObject.transform.position += new Vector3(0, 3, 0);  }

        if ( Input.GetKey("x")) {  this.gameObject.transform.position -= new Vector3(0, 3, 0);  }
        
    }
}
