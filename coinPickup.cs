using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinPickup : MonoBehaviour
{
        private gamemanager gameManager;
    private float healthTimer = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<gamemanager>();
    }

    // Update is called once per frame
    void Update()
    {
        healthTimer -= Time.deltaTime * gameManager.cloudSpeed;
        if(healthTimer <= 3f){
            transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.75f);
        }
        if(healthTimer <= 1f){
            transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        }
        if(healthTimer <= 0f){
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if(whatDidIHit.tag == "Player")
        {
            gameManager.AddScore(1);
            Destroy(this.gameObject);
        }
    }
}
