using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class chase : MonoBehaviour {

    public Transform target;//追いかける対象-オブジェクトをインスペクタから登録できるように
    public GameObject PushText;
    public float speed = 0.005f;//移動スピード
    private Vector3 vec;
    private int mode_num = 1;
    private int count = 0;
    private float round_count = 0.0f;

    void Start () {

    }

    void Update () {
        if(target.GetComponent<PlayerController>().poitf){
            mode_num = 10;
            transform.position = Vector3.MoveTowards(transform.position,vec +new Vector3(0,20,0),speed*10);
            PushText.SetActive(true);
        }
        if(mode_num == 1){ //索敵
            round_count += 1.0f;
            speed = 0.03f + 0.005f * round_count;
            Debug.Log("round:" + round_count +"speed"+speed);
            vec = target.position;
            vec += new Vector3(-4,8,-4); //ぽいの中心がずれているため調節
            mode_num = 2;
        }
        else if(mode_num == 2){ //移動
            if(transform.position == vec){
                mode_num = 3;
            }
            //targetに向かって進む
            transform.position = Vector3.MoveTowards(transform.position,vec,speed); //データを取得したときにいた座標に向けて進む
        }
        else if(mode_num == 3){ //待機
            count +=1;
            if(count > 120){
                count = 0;
                mode_num = 4;
            }
        }
        else if(mode_num == 4){ //垂直に上昇
            if(transform.position == vec +new Vector3(0,20,0)){
                mode_num = 5;
            }
            transform.position = Vector3.MoveTowards(transform.position,vec +new Vector3(0,20,0),speed);
        }
        else if(mode_num == 5){ //待機
            count +=1;
            if(count > 120){
                count = 0;
                mode_num = 1;
            }
        }
    }
}