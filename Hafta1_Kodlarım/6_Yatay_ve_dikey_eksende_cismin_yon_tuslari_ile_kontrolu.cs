using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    // Cismin Hareket hızını speed ile belirleme
    private float speed = 5f;

    void Update()
    {
        // Yukarı ve aşağı ok tuşları ile cismin hareketinin kontrol et.
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
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // Sağ ok tuşuna basıldığında cisim sağa hareket eder.
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Sol ok tuşuna basıldığında cisim sola hareket eder.
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
}