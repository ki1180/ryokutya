using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ThirdPersonController

public class Camera : MonoBehaviour
{

    private GameObject player;   //プレイヤー情報格納用
    private Vector3 offset;      //相対距離取得用
    private Vector3 A_offset;
 
    private bool Cs;



    // Use this for initialization
    void Start()
    {
        //ThirdPersonControllerの情報を取得
        player = GameObject.Find("ThirdPersonController");
        ////MainCamera(自分自身)とplayerとの相対距離を求める
        offset = transform.position - player.transform.position;
        ////新しいトランスフォームの値を代入する
        ////offset = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
 
        //MainCamera(自分自身)とplayerとの相対距離を求める
        A_offset = transform.position - player.transform.position;
        //ThirdPersonControllerの情報を取得
        player = GameObject.Find("ThirdPersonController");
        if (A_offset.y>offset.y)
        {
            //this.transform.Translate(new Vector3(0f, 0.1f, -0.1f));
            //offset.y += 0.04f;
            //offset.z -= 0.05f;

            offset += new Vector3(0f, 0.04f, -0.05f);
        }
       
        transform.position = player.transform.position + offset;
        //transform.position = player.transform.position + A_offset;
    }
}
//    came.gameObject.transform.Translate(Vector3.up);
//    came.gameObject.transform.Translate(Vector3.back);

