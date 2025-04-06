using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gamemanager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject cloudPrefab;
    public GameObject healthPrefab;
    public GameObject coinPrefab;


    public float horizontalScreenSize;
    public float verticalScreenSize;
    private int score;
    public player Player;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;
        CreateSky();
        InvokeRepeating("CreateEnemy", 1f, 3f);
        InvokeRepeating("CreateHealth", 1f, 3f);
        InvokeRepeating("CreateCoin", 1f, 3f);
        score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    public void AddScore(int earnedScore){
        score = score + earnedScore;
        scoreText.text = "Score: " + score;
    }
    
    public void ChangeLivesText (int currentLives){
        livesText.text = "Lives: " + currentLives;
    }
    void CreateHealth(){
        Instantiate(healthPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, Random.Range(-2, verticalScreenSize) * 0.9f, 0), Quaternion.identity);
    }
    void CreateCoin()
    {
        Instantiate(coinPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, Random.Range(-2, verticalScreenSize) * 0.9f, 0), Quaternion.identity);
    }
}
