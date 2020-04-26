using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    
    Rigidbody rgb;
    

    public bool atacar;
    public bool isAtacar;
    // Start is called before the first frame update
    void Start()
    {   
        rgb = gameObject.GetComponent<Rigidbody>();
        
        
        rgb.AddForce(Vector3.left);
    }

    // Update is called once per frame
    void Update()
    {   
        //atacar=Input.GetKeyDown(KeyCode.A);        
        atacar = Input.GetButtonDown("atacar");
        Debug.Log(atacar);
    }
}
