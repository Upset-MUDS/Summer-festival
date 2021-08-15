using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour {

    private Vector3 target;
    private Vector3 latestPos;
    private Vector3 diff;

    private float targetX = 0f;
    private float targetY = 1f;
    private float targetZ = 0f;

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
            diff = transform.position - latestPos;
            latestPos = transform.position;
            transform.rotation = Quaternion.LookRotation(diff);
//            transform.LookAt(target);
            transform.position = Vector3.MoveTowards(transform.position, target, speed);

        }
    }
}
