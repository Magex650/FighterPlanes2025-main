using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpFade : MonoBehaviour
{
    private float healthTimer = 2.5f;
    private gamemanager gameManager;
    // Start is called before the first frame update
    void Start()
    {
       gameManager = GameObject.Find("GameManager").GetComponent<gamemanager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        healthTimer -= Time.deltaTime * gameManager.cloudSpeed;
        if(healthTimer <= 1.25f){
            transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.75f);
        }
        if(healthTimer <= 0.75f){
            transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        }
        if(healthTimer <= 0f){
            Destroy(this.gameObject);
        }
    }
}
