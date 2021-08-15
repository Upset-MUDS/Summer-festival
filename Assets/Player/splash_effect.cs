using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splash_effect : MonoBehaviour
{
    public GameObject particles1;
    public GameObject particles2; 

    // 水しぶきの設定
    void OnTriggerEnter(Collider t)
    {
        if(t.gameObject.tag == "Water"){
            Debug.Log("sp");
            Vector3 position = t.ClosestPointOnBounds(transform.position);
            Instantiate(particles1, new Vector3(position.x, position.y + 2, position.z), Quaternion.Euler(90f, 0, 0));
            Instantiate(particles2, new Vector3(position.x, position.y - 2, position.z), Quaternion.Euler(-90f, 0, 0));
        }
    }
}
