using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumoer : MonoBehaviour {

    public float bounce = 10f;
    public int scorePoint = 10; 

    private void OnCollisionEnter(Collision other){

        if (other.gameObject.tag == "Ball")
        {
            other.rigidbody.AddForce(0f, bounce / 6, bounce, ForceMode.Impulse);
            GameObject gm = GameObject.Find("GameManager");
            gm.GetComponent<GameManager>().AddScore(scorePoint);
        }
    }
}