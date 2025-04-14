using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject miniBossOnePrefab;
    public GameObject cloudPrefab;
    public GameObject healthPrefab;
    public GameObject coinPrefab;
    public GameObject powerUpPrefab;
    public GameObject gameOverText;
    public GameObject restartText;
    public GameObject audioPlayer;
    public GameObject shieldText;

    public float horizontalScreenSize;
    public float verticalScreenSize;
    private int score;
    public player Player;
    public float cloudSpeed = 1;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI powerUpText;

    private bool gameOver = false;

    public AudioClip powerUpSound;
    public AudioClip powerDownSound;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;
        CreateSky();
        InvokeRepeating("CreateEnemy", 1f, 3f);
        InvokeRepeating("CreateMiniBoss", 15f, 25f);
        InvokeRepeating("CreateHealth", 7f, 7f);
        InvokeRepeating("CreateCoin", 5f, 6f);
        score = 0;
        gameOverText.SetActive(false);
        restartText.SetActive(false);
        gameOver = false;
        StartCoroutine(SpawnPowerUp());
        powerUpText.text = "No Power Up Yet!";
        shieldText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver == true && Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void CreateSky(){
        for (int i = 0; i < 30; i++){
             Instantiate(cloudPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize), Random.Range(-verticalScreenSize, verticalScreenSize), 0), Quaternion.identity);
        }
    }
    void CreateEnemy()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, verticalScreenSize, 0), Quaternion.Euler(180, 0, 0));
    }
     void CreateMiniBoss()
    {
        Instantiate(miniBossOnePrefab, new Vector3(0, verticalScreenSize, 0), Quaternion.Euler(180, 0, 0));
    }
    public void AddScore(int earnedScore){
        score = score + earnedScore;
        scoreText.text = "Score: " + score;
    }
    
    public void ChangeLivesText (int currentLives){
        livesText.text = "Lives: " + currentLives;
    }
    void CreateHealth(){
        Instantiate(healthPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, Random.Range(-2, 0), 0), Quaternion.identity);
    }
    void CreateCoin(){
        Instantiate(coinPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, Random.Range(-2, 0), 0), Quaternion.identity);
    }
    void CreatePowerUp(){
        Instantiate(powerUpPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, Random.Range(-2, 0), 0), Quaternion.identity);
    }
    public void GameOver(){
        gameOverText.SetActive(true);
        restartText.SetActive(true);
        gameOver = true;
        CancelInvoke("CreateEnemy");
        CancelInvoke("CreateCoin");
        CancelInvoke("CreateHealth");
        cloudSpeed = 0f;
    }
    IEnumerator SpawnPowerUp(){
        float spawnTime = Random.Range(6, 8);
        yield return new WaitForSeconds(spawnTime);
       if(gameOver != true){
            CreatePowerUp();
            StartCoroutine(SpawnPowerUp());
       }
    }
    public void ManagePowerupText(int powerUpType){
        switch(powerUpType){
            case 0:
                powerUpText.text = "No Power Up Yet!";
                break;
            case 1:
                powerUpText.text = "Speed!";
                break;
            case 2:
                powerUpText.text = "Double Shot!";
                break;
            case 3:
                powerUpText.text = "Triple Shot!";
                break;
            case 4:
                shieldText.SetActive(true);
                break;
        }
    }
    public void PlaySound(int sound){
        switch(sound){
            case 1:
                audioPlayer.GetComponent<AudioSource>().PlayOneShot(powerUpSound);
                break;
            case 2:
                audioPlayer.GetComponent<AudioSource>().PlayOneShot(powerDownSound);
                break;
        }
    }
}
