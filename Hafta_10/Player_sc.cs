using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor;
using UnityEngine;

public class Player_sc : MonoBehaviour
{
    [SerializeField] float speed = 12;
    public GameObject laserPrefab;
    public GameObject tripleShotPrefab;
    public GameObject shieldVisualizer;
    public GameObject rightEngine, leftEngine;
    float fireRate = 0.5f;
    float nextFire = 0f;
    float speedMultiplier = 2;
    SpawnManager_sc spawnManager_Sc;
    UIManager_sc uiManager_sc;

    [SerializeField]int score = 0;

    [SerializeField] public int lives = 3;

    public bool isTripleShotActive = false;
    public bool isSpeedBonusActive = false;
    public bool isShieldBonusActive = false;
    AudioSource audioSource;

    [SerializeField]
    AudioClip laserSoundClip;
    void Start()
    {
        spawnManager_Sc = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager_sc>();
        uiManager_sc = GameObject.Find("Canvas").GetComponent<UIManager_sc>();
        audioSource = GetComponent<AudioSource>();
        if(spawnManager_Sc == null){
            Debug.Log("Spawn_Manager oyun nesnesi bulunamadı.");
        }
        if(uiManager_sc == null){
            Debug.Log("UIManager nesnesi bulunamadı.");
        }
        if (audioSource == null){
            Debug.LogError("Ses Dosyası Bulunamadı");
        }
        else{
            audioSource.clip = laserSoundClip;
        }
    }

    void Update()
    {
        CalculateMovement();
        FireLaser();   

    }
    void CalculateMovement(){
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical, 0);
        transform.Translate(direction * Time.deltaTime * speed );

        float locx = transform.position.x;
        float locy = transform.position.y;

        
        if (locy >= 0){
            transform.position = new Vector3(transform.position.x,0,0);
        }
        else if (locy <= -3.9f ){
            transform.position = new Vector3(transform.position.x,-3.9f,0);
        }

        if (locx >= 11.23f){
            transform.position = new Vector3(-11.23f,transform.position.y,0);
        }
        else if (locx <= -11.23f){
            transform.position = new Vector3(11.23f,transform.position.y,0);
        }
    }

    void FireLaser(){
        if ((Input.GetKeyDown(KeyCode.Space)) && (Time.time > nextFire)){
            if(!isTripleShotActive)
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
            }
            else if(isTripleShotActive)
            {
                Instantiate(tripleShotPrefab, transform.position + new Vector3(-1.53f, 0.5f, 0), Quaternion.identity);
            }
            audioSource.Play();
            nextFire = Time.time + fireRate;
        }
    }
    public void Damage(){  
        if (isShieldBonusActive){
            isShieldBonusActive = false;
            shieldVisualizer.SetActive(false);
            return;
        }
        else {
            lives--;

            if(lives == 2){
                leftEngine.SetActive(true);
            }
            else if(lives == 1){
                rightEngine.SetActive(transform);
            }

            if(uiManager_sc != null){
                uiManager_sc.UpdateLivesImg(lives);
            }
        }

        if(lives < 1){
            if(spawnManager_Sc != null){
                spawnManager_Sc.OnPlayerDeath();
            }
            Destroy(this.gameObject);
        }
    }

    public void ActivateTripleShot(){
        isTripleShotActive = true;
        StartCoroutine(TripleShotBonusDisableRoutine());
    }

    public void ActivateSpeedBonus(){
        isSpeedBonusActive = true;
        speed *= speedMultiplier;
        StartCoroutine(SpeedBonusDisableRoutine());
    }

    public void ActivateShieldBonus(){
        isShieldBonusActive = true;
        shieldVisualizer.SetActive(true);
        StartCoroutine(ShieldBonusDisableRoutine());
    }

    IEnumerator TripleShotBonusDisableRoutine(){
        yield return new WaitForSeconds(5.0f);
        isTripleShotActive = false;
    }
    IEnumerator SpeedBonusDisableRoutine(){
        yield return new WaitForSeconds(5.0f);
        speed /= speedMultiplier;
        isSpeedBonusActive = false;
    }
    IEnumerator ShieldBonusDisableRoutine(){
        yield return new WaitForSeconds(5.0f);
        shieldVisualizer.SetActive(false);
        isShieldBonusActive = false;
    }

    public void UpdateScore(int points){
        score += points;
        if(uiManager_sc != null){
            uiManager_sc.UpdateScoreTMP(score);
        }
    }
}

