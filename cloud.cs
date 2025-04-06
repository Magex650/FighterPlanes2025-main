using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour
{
    private float speed;
    private gamemanager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<gamemanager>();
        transform.localScale = transform.localScale * Random.Range(0.1f, 0.7f);
        transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Random.Range(0.1f, 0.7f));
        speed = Random.Range(3f, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -gameManager.verticalScreenSize)
        {
            transform.position = new Vector3(Random.Range(-gameManager.horizontalScreenSize, gameManager.horizontalScreenSize), gameManager.verticalScreenSize * 1.2f, 0);
        }
        
    }
}
