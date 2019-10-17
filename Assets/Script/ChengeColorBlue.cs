using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChengeColorBlue : MonoBehaviour {

     void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            GetComponent<Renderer>().material.color  = Color.blue;
        }
    }
}
