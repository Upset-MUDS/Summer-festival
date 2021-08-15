using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Slider slider;

    //カメラ
    public GameObject cam;
    public GameObject poi;
    public float Xsensityvity = 3f, Ysensityvity = 3f;
    float X_Rotation,Y_Rotation;

    public float movementSpeed = 2f;
    public float shiftSpeed = 4f;
    public int staminamax = 100;
    int stamina = 100;
    public float test = 0.0f;
    float before_y = 2.0f;

    float speed = 2f;
    float horizontalInput = 0.0f;
    float verticalInput = 0.0f;

    bool shift = false;
    bool shiftonnn = false;

    bool cursorLock = true;
    Vector3 angle;

    //ポイ用
    string mode = "None";
    public bool poitf = false;


    public GameObject End;


    void Start()
    {
        slider.value = 1;
        before_y = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        shift = Input.GetKey("left shift");

        UpdateCursorLock();
        angle = new Vector3(Input.GetAxis("Mouse X") * Xsensityvity,Input.GetAxis("Mouse Y") * Ysensityvity, 0);
    }

    void FixedUpdate(){
        //メインカメラを回転
        cam.transform.Rotate(-angle.y,0,0);
        this.transform.Rotate(transform.up,angle.x);

        if(this.transform.position == new Vector3(0,0.5f,0)){ //ポイキャッチ後下についた場合スタータスを元に戻す
            mode = "None";
        }
        if(mode == "catch" && !poitf){ //逃れられた場合0,0.5f,0,に移動
            this.transform.position = Vector3.MoveTowards(this.transform.position,new Vector3(0,0.5f,0),0.5f);
            return;
        }
        if(mode == "catch"){ //捕まった場合ポイの位置に移動
            this.transform.position = new Vector3(poi.transform.position.x+4,poi.transform.position.y-6.5f,poi.transform.position.z-3);
            return;
        }

        //移動の設定(speed)
        if(shift){
            if(!shiftonnn){
                if(stamina > 0){
                    speed = shiftSpeed;
                    stamina -= 2;
                }else{
                    shiftonnn = true;
                }
            }else{
                if(stamina < staminamax){
                    stamina += 1;
                }
                speed = movementSpeed;
            }
        }else{
            if(stamina < staminamax){
                stamina += 1;
            }
            shiftonnn = false;
            speed = movementSpeed;
        };
        slider.value = stamina/(float)staminamax;//スタミナのグラフ

        //移動処理
        this.transform.position += cam.transform.forward *verticalInput * speed * Time.deltaTime + cam.transform.right *  horizontalInput* speed * Time.deltaTime;//正面を向く
        this.transform.position = new Vector3(this.transform.position.x,before_y,this.transform.position.z);//Yの値を修正
    }

    //マウスロック用
    public void UpdateCursorLock()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLock = false;
            End.SetActive(false);
            SceneManager.LoadScene("Title");
        }

        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if(!cursorLock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    //poiとのキャッチ判定
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "poi"){
            if(mode == "catch"){
                return;
            }
            Debug.Log("hit");
            poitf = true;
            Vector3 vec = this.transform.position;
            mode = "catch";
        }
    }
}
