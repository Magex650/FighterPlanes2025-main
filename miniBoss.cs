using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniBoss : MonoBehaviour
{
    public GameObject explosionPrefab;
    private gamemanager gameManager;
    public float health = 1;
    public float miniBossSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
         gameManager = GameObject.Find("GameManager").GetComponent<gamemanager>();
    }

    // Update is called once per frame
    void Update()
    {
        dead();
        transform.Translate(new Vector3(miniBossSpeed, 0, 0) * Time.deltaTime);
        if(transform.position.x > 7 || transform.position.x < -7){
            miniBossSpeed = miniBossSpeed * -1;
        }
    }
    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if(whatDidIHit.tag == "Player")
        {
            whatDidIHit.GetComponent<player>().LoseLife();
        } else if(whatDidIHit.tag == "weapon")
        {
            health -= 1;
            Destroy(whatDidIHit.gameObject);
        }
    }
    void dead(){
        if(health <= 0){
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            gameManager.AddScore(20);
            Destroy(this.gameObject);
        }
    }
}
