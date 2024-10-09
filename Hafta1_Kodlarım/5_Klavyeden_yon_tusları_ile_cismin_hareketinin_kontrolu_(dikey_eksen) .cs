using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script: MonoBehaviour
{
    // Cismin hareket hızını speed ile belirleme
    public float speed = 5f;

    void Update()
    {
        // Yukarı ve aşağı ok tuşları ile cismin hareketini kontrol et.
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Yukarı ok tuşuna basıldığında cisim yukarı hareket eder.
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            // Aşağı ok tuşuna basıldığında cisim aşağı hareket eder.
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }
}