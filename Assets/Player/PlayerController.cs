using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    // float axisH = 0.0f;
    // bool jump = false;
    public float movementSpeed = 2f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // axisH = Input.GetAxisRaw("Horizontal");
        // jump = Input.GetButtonDown("Jump");
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime,0, verticalInput * movementSpeed * Time.deltaTime);
        Debug.Log(transform.position);
        // if (axisH != 0.0f){
        //     Debug.Log(axisH);
        //     Debug.Log(jump);
        // }
    }
}
