using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int lives = 3;
    public float speed = 5.0f;

    private gamemanager gameManager;

    private float horizontalInput;
    private float verticalInput;

    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public GameObject thrusterPrefab;
    public GameObject shieldPrefab;

    public int weaponType;
    public bool hasShield = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<gamemanager>();
        gameManager.ChangeLivesText(lives);
        weaponType = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }
    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);

        float horizontalScreenSize = gameManager.horizontalScreenSize;
        float verticalScreenSize = gameManager.verticalScreenSize;

        if (transform.position.x <= -horizontalScreenSize || transform.position.x > horizontalScreenSize)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
        if (transform.position.y <= -4.8f)
        {
            transform.position = new Vector3(transform.position.x, -4.8f, 0);
        }
        else if(transform.position.y >= 0f){
            transform.position = new Vector3(transform.position.x, 0f, 0);
        }
    }
    void Shooting(){
        if(Input.GetKeyDown(KeyCode.Space)){
           switch(weaponType){
               case 1:
                Instantiate(bulletPrefab, transform.position + new Vector3(0f, 0.5f, 0f), Quaternion.identity);
                break;
               case 2:
                Instantiate(bulletPrefab, transform.position + new Vector3(-0.5f, 0.5f, 0f), Quaternion.identity);
                Instantiate(bulletPrefab, transform.position + new Vector3(0.5f, 0.5f, 0f), Quaternion.identity);
                break;
               case 3:
                Instantiate(bulletPrefab, transform.position + new Vector3(-0.5f, 0.5f, 0f), Quaternion.Euler(0, 0, 45));
                Instantiate(bulletPrefab, transform.position + new Vector3(0f, 0.5f, 0f), Quaternion.identity);
                Instantiate(bulletPrefab, transform.position + new Vector3(0.5f, 0.5f, 0f), Quaternion.Euler(0, 0, -45));
                break;
           }
        }    
    }
    public void LoseLife (){
        if(hasShield == true){
            shieldPrefab.SetActive(false);
            hasShield = false;
            gameManager.PlaySound(2);
            gameManager.shieldText.SetActive(false);
        }
        else if(hasShield == false){
            lives -= 1;
            gameManager.ChangeLivesText(lives);
        }
        if (lives <= 0){
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            gameManager.GameOver();
            Destroy(this.gameObject);
        }
    }
    public void GainLife (){
        if(lives <= 2){
             lives += 1;
             gameManager.ChangeLivesText(lives);
        }
    } 
    IEnumerator SpeedPowerDown(){
        yield return new WaitForSeconds(3f);
        speed = 5f;
        thrusterPrefab.SetActive(false);
        gameManager.ManagePowerupText(0);
        gameManager.PlaySound(2);
    }
    IEnumerator WeaponPowerDown(){
        yield return new WaitForSeconds(3f);
        weaponType = 1;
        gameManager.ManagePowerupText(0);
        gameManager.PlaySound(2);
    }
    
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "powerUp"){
            Destroy(collision.gameObject);
            int whichPowerup = Random.Range (1, 5);
            switch (whichPowerup){
                case 1:
                //speed
                speed = 10f;
                thrusterPrefab.SetActive(true);
                StartCoroutine(SpeedPowerDown());
                gameManager.ManagePowerupText(1);
                gameManager.PlaySound(1);
                    break;
                case 2:
                //double weapon
                weaponType = 2;
                StartCoroutine(WeaponPowerDown());
                gameManager.ManagePowerupText(2);
                gameManager.PlaySound(1);
                    break;
                case 3:
                //triple weapon
                weaponType = 3;
                gameManager.ManagePowerupText(3);
                gameManager.PlaySound(1);
                StartCoroutine(WeaponPowerDown());
                break;
                case 4:
                //shield
                if(hasShield == false){
                  shieldPrefab.SetActive(true);
                  hasShield = true;
                }
                else{
                }
                gameManager.PlaySound(1);
                gameManager.ManagePowerupText(4);
                    break;
            }
        }
    }
}
