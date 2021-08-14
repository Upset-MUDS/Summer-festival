using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Slider slider;
    public float movementSpeed = 2f;
    public float shiftSpeed = 4f;
    public int staminamax = 100;
    public int stamina = 100;
    public float test = 0.0f;

    float speed = 2f;
    float horizontalInput = 0.0f;
    float verticalInput = 0.0f;

    bool shift = false;
    bool shiftonnn = false;

    void Start()
    {
        slider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        shift = Input.GetKey("left shift");
    }
    
    void FixedUpdate() {
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
        slider.value = stamina/(float)staminamax;
        transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime,0, verticalInput * speed * Time.deltaTime);
        // Debug.Log(transform.position);
    }
}
