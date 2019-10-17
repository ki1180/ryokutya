using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour {


    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player"){
            this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
        }
    }

     void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Player"){
            this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1);
        }
    }
}
