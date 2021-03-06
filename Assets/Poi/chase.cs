using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class chase : MonoBehaviour {

    public Transform target;//追いかける対象-オブジェクトをインスペクタから登録
    public GameObject PushText;
    public GameObject BrokenText;
    public GameObject BrokenPoi;
    public GameObject Poi;
    public GameObject space_c;
    public GameObject bar_time;
    public Slider bar_time_sl;
    public GameObject End;
    public GameObject text_poi;
    public GameObject text_broken_poi;
    public float speed = 0.02f;//移動スピード
    private Vector3 vec;
    private int mode_num = 1;
    private int count = 0;
    private float round_count = 0.0f;

    public int catch_count_limit = 250;
    public int space_count_limit = 20;
    private int space_count = 0;
    private int catch_count = 0;
    int catch_all_count = 0;
    public int poi_max = 5;
    public int poi_broken_count = 5;
    Vector3 before_angle;

    void Start () {
        Application.targetFrameRate = 60;
        before_angle =  this.transform.eulerAngles;
    }

    void Update () {
        if(target.GetComponent<PlayerController>().poitf && mode_num < 10){
            mode_num = 10;
            this.transform.eulerAngles = before_angle;
        }
        if (mode_num == 10){
            transform.position = Vector3.MoveTowards(transform.position,vec +new Vector3(0,20,0),speed*10);
            PushText.SetActive(true);
            space_c.SetActive(true);
            bar_time.SetActive(true);

            if(Input.GetKeyDown(KeyCode.Space)){
                space_count += 1;
            }
            catch_count +=1 ;
            bar_time_sl.value = catch_count/(float)catch_count_limit;
            Text space_text = space_c.GetComponent<Text> ();
            space_text.text =space_count + "/"+space_count_limit;


            if(space_count >= space_count_limit){
                catch_all_count += 1;
                space_count_limit = 20 + catch_all_count * 10;
                space_count = 0;
                catch_count = 0;
                PushText.SetActive(false);
                BrokenText.SetActive(true);
                BrokenPoi.SetActive(true);
                Poi.SetActive(false);
                mode_num = 11;
                poi_broken_count -= 1;
                text_poi.GetComponent<Text> ().text = poi_broken_count.ToString();
                text_broken_poi.GetComponent<Text> ().text = (poi_max - poi_broken_count).ToString();
                if(poi_broken_count == 0){
                    //=======
                    //ゲーム勝利
                    //=======
                }
            }else if(catch_count >= catch_count_limit){
                PushText.SetActive(false);
                space_c.SetActive(false);
                bar_time.SetActive(false);
                End.SetActive(true);
                mode_num = 20;
                Debug.Log("game over");
            }
        }
        if(mode_num == 1){ //索敵
            this.transform.eulerAngles += new Vector3(0,new System.Random().Next(-90,90),0);
            round_count += 1.0f;
            speed = 0.12f + 0.02f * round_count;
            Debug.Log("round:" + round_count +"speed"+speed);
            vec = target.position;
            vec += new Vector3(-1,7,-1); //ぽいの中心がずれているため調節
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
            if(count > 30){
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
            if(count > 30){
                count = 0;
                mode_num = 1;
            }
        }
        else if(mode_num == 11){
            count +=1;
            if(count > 30){
                Debug.Log("here12");
                count = 0;
                space_c.SetActive(false);
                bar_time.SetActive(false);
                BrokenText.SetActive(false);
                target.GetComponent<PlayerController>().poitf = false;
                mode_num = 12;
            }
        }
        else if(mode_num == 12){
            count +=1;
            if(count > 105){
                count = 0;
                mode_num = 13;
            }
        }
        else if(mode_num == 13){
            count +=1;
            if(count > 30){
                count = 0;
                mode_num = 1;
                BrokenPoi.SetActive(false);
                Poi.SetActive(true);
            }
        }
    }
}