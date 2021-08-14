using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    float axisH = 0.0f;
    bool jump = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        axisH = Input.GetAxisRaw("Horizontal");
        jump = Input.GetButtonDown("Jump");
        if (axisH != 0.0f){
            Debug.Log(axisH);
            Debug.Log(jump);
        }
    }
}
