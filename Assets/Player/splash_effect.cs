using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splash_effect : MonoBehaviour
{
    public GameObject particles; 

    // 水しぶきの設定
    void OnTriggerEnter(Collider t)
    {
        Vector3 position = t.ClosestPointOnBounds(transform.position);
        Instantiate(particles, new Vector3(position.x, position.y, position.z), Quaternion.identity);
    }
}
