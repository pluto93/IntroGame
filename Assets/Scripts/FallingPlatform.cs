using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    bool isFalling = false;
    float downSpeed = 0;
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.name == "Player"){
            isFalling = true;
        }
    }

    void Update(){
        if (isFalling){
            downSpeed = Time.deltaTime;
            transform.position = new Vector3(transform.position.x,
                transform.position.y - downSpeed,
                transform.position.z);
        }
    }

}

