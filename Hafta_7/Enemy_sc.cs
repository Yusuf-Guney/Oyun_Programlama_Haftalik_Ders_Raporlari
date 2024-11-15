using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_sc : MonoBehaviour
{
    [SerializeField]
    float speed = 3.0f;

    void Start()
    {
        
    }
    void Update()
    {
    CalculateEnemyMovement();
    }
    void  CalculateEnemyMovement(){
        transform.Translate(Vector3.down * speed * Time.deltaTime); 
         if(transform.position.y < -5.4){
            float randomX = Random.Range(-9.4f, 9.4f);
            transform.position = new Vector3(randomX, 7.5f, 0);
        }
    }

     void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            Player_sc player_sc = other.transform.GetComponent<Player_sc>();
            player_sc.Damage();
            Destroy(this.gameObject);
        }
        else if(other.tag =="Laser"){
          Destroy(other.gameObject);  
          Destroy(this.gameObject);
        }
        
     }
}


