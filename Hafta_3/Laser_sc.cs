using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_sc : MonoBehaviour
{
    [SerializeField]
    float speed = 8.0f;

    // Update is called once per frame
    void Update()
    {
    CalculateLazerMovement();
    }
     void CalculateLazerMovement(){
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if(transform.position.y > 7.0f) {
            Destroy(this.gameObject);
        } 
    }

}
