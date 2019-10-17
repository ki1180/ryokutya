using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour {

    private GameObject player;
    public AudioSource audioSE;
    public AudioClip sound01;
    private bool killSEflag = true;

	// Use this for initialization
	void Start () {
        audioSE = gameObject.AddComponent<AudioSource>();
	}
	
	// Update is called once per frameZS
	void Update () {
        player = GameObject.FindWithTag("Player");
        if(player == null && killSEflag == true)
        {
            //Debug.Log("aa");
            audioSE.PlayOneShot(sound01);
            killSEflag = false;
        }
	}
}
