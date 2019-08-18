using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityObjects : MonoBehaviour
{
    
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(0, Physics.gravity.magnitude * -10f, 0);
    }
}
