using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_sc : MonoBehaviour
{
    [SerializeField]
    float speed = 5;

    [SerializeField]
    GameObject laserPrefab;

    [SerializeField]
    float fireRate = 0.5f;

    [SerializeField]
    float nextFire = 0f;

    [SerializeField]
    int lives = 3;

    [SerializeField]
    bool isTripleShotActive = false;

    [SerializeField]
    GameObject tripleShotPrefab;

    SpawnManager_sc spawnManager_sc;

    void Start()
    {
       spawnManager_sc= GameObject.Find("Spawn_Manager").GetComponent<SpawnManager_sc>();

       if(spawnManager_sc == null){
            Debug.Log("Uyarı");
       }
    }
   
    void Update()
    {
     CalculateMovement();
     shoting();
    }
    void shoting(){
    if(Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire){
        if(!isTripleShotActive)
        {
            Instantiate(laserPrefab, transform.position + new Vector3(0,1.05f,0),Quaternion.identity);
        }
        else
        {
            Instantiate(tripleShotPrefab, transform.position + new Vector3(-0.9f,1.05f,0),Quaternion.identity);
        }

        nextFire = Time.time + fireRate;
        
        }
    }

    void CalculateMovement(){

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical,0);
        transform.Translate(direction*Time.deltaTime*speed);

        if(transform.position.y >= 0){// y nin maximum değeri
            transform.position = new Vector3(transform.position.x,0,0);
        }
        else if(transform.position.y <=-3.9f){// y nin minimum değeri
            transform.position = new Vector3(transform.position.x,-3.9f,0);
        }
        if(transform.position.x >=15.2f){// x in maximum değeri
            transform.position = new Vector3(-15.2f,transform.position.y,0);
        }
        else if(transform.position.x <=-15.2f){// x nin minimum değeri
            transform.position = new Vector3(15.2f,transform.position.y,0);
        }
    }

    public void Damage(){

        lives--;

        if(lives < 1){
            if(spawnManager_sc != null)
                spawnManager_sc.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }
}
