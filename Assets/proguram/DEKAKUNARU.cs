using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEKAKUNARU : MonoBehaviour {

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            Debug.Log(this.transform.localScale);
            this.transform.localScale += new Vector3(0.4f,0.4f,0.4f);
     
        }
    }
}
