using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Destroy : MonoBehaviour {

    BoxCollider Bc;
    float h=0;
    const int tyousei = 1;

	// Use this for initialization
	void Start () {
        Bc = gameObject.GetComponent<BoxCollider>();
        h = Bc.size.y;
        h = Bc.size.y;
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        //衝突判定
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log(h);
            if (this.h <= collision.gameObject.transform.localScale.y)
            {
                //相手のタグがPlayerならば、自分を消す
                Destroy(this.gameObject);
            }
        }
    }
}
