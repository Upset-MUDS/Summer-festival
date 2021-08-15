using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour {

    private Vector3 target;

    private float targetX = 0f;
    private float targetY = 1f;
    private float targetZ = 0f;

    private float moveX = 0f;
    private float moveZ = 0f;

    [SerializeField] float speed=0.08f;

    void Start(){
        targetX = Random.Range(-15f, 15f);
        targetY = Random.Range(0.5f, 2.5f);
        targetZ = Random.Range(-15f, 15f);
        target = new Vector3(targetX, targetY, targetZ);
    }

    void FixedUpdate(){
        if ((target - transform.position).sqrMagnitude < 3f){
            targetX = Random.Range(-15f, 15f);
            targetY = Random.Range(0.5f, 2.5f);
            targetZ = Random.Range(-15f, 15f);
            target = new Vector3(targetX, targetY, targetZ);
        }else{
            transform.LookAt(target);
            transform.position = Vector3.MoveTowards(transform.position, target, speed);
        }
    }
}
