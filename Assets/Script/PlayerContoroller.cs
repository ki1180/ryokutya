using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerContoroller : MonoBehaviour
{

    public float speed = 12.0f;
    public float brake = 0.5f;      //減速の大きさ
    private Rigidbody rB;
    private Vector3 rbVelo;         //今の速度を入れる変数

    public Text goalText;
    public bool goalOn;
    public ParticleSystem explosion;
    public Text fallText;
    private Vector3 height;
    public float bounce = 10.0f;
    public float jumpForce = 20.0f;
    public float turboForce = 2.0f;

    // Use this for initialization
    void Start()
    {
        rB = GetComponent<Rigidbody>();
        goalText.enabled = false;
        goalOn = false;
        fallText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (goalOn == false)
        {
            rbVelo = Vector3.zero;
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            rbVelo = rB.velocity;                   //今の速度をrbVeroに入れる
            rB.AddForce(x * speed - rbVelo.x * brake, 0, z * speed - rbVelo.z * brake, ForceMode.Impulse);
        }
        height = this.GetComponent<Transform>().position;
        if (height.y <= -3.0f)
        {
            explosion.transform.position = this.transform.position;
            explosion.Play();
            fallText.enabled = true;
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            //Debug.Log(speed);
            //Debug.Log(other.name);
            other.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
            rB.AddForce(-rbVelo.x * 0.8f, 0, -rbVelo.z * 0.8f, ForceMode.Impulse);
            goalText.enabled = true;
            goalOn = true;
        }

        if(other.gameObject.tag == "Jump")
        {
            Debug.Log(speed);
            Debug.Log(other.name);
            rB.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }

        if(other.gameObject.tag == "Turbo")
        {
            Vector3 vel = rB.velocity;
            rB.AddForce(vel.x * turboForce, 0, vel.z * turboForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Kill")
        {
            explosion.transform.position = other.transform.position;
            this.gameObject.SetActive(false);
            fallText.enabled = true;
            explosion.Play();
        }

        if (other.gameObject.tag == "Bounce")
        {
            StartCoroutine("WaitKeyInput");
        }
    }

    IEnumerator WaitKeyInput()
    {
        //Debug.Log("ok!");
        this.gameObject.GetComponent<PlayerContoroller>().enabled = false;
        {
            yield return new WaitForSeconds(1.0f);
        }
        this.gameObject.GetComponent<PlayerContoroller>().enabled = true;
    }
}
