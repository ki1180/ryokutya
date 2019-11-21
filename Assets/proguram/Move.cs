using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{

    /*public Transform goal;*/          //目的地となるオブジェクトのトランスフォーム格納用
    private NavMeshAgent agent;     //エージェントとなるオブジェクトのNavMeshAgent格納用 
    public GameObject player;
    private Vector3 PlayerPs;
    private bool MoveSwitch;
    private BoxCollider Bo;

    // Use this for initialization
    void Start()
    {
        //エージェントのNaveMeshAgentを取得する
        agent = GetComponent<NavMeshAgent>();
        Bo = GetComponent<BoxCollider>();
        ////目的地となる座標を設定する
        //agent.destination = goal.position;
    }
    private void Update()
    {
        PlayerPs = player.transform.position;
        
        if (MoveSwitch == true)
        {
            agent.destination = player.transform.position;
            var aim = PlayerPs - this.transform.position;
            var look = Quaternion.LookRotation(aim);
            this.transform.localRotation = look;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            MoveSwitch = true;
            Debug.Log("ahann");
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MoveSwitch = true;
            Debug.Log("oppai");
            Bo.isTrigger = true;
        }
    }
}