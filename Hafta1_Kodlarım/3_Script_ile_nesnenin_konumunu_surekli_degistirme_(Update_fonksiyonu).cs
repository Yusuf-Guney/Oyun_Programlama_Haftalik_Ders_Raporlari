using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script: MonoBehaviour
{
    //Nesnenin hareket hızı
    public float speed = 3f;

    void Start()
    {
	
    }

    void Update(){

    // Nesnenin sağa doğru sürekli hareket etmesini sağlar
    transform.position += Vector3.right speed* Time.deltaTime;

    }
}
