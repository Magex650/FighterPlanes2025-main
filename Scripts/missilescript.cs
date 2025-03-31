using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missilescript : MonoBehaviour
{
    private float missileDirection = 1.0f;
    private float spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
       spawnPoint = transform.position.x; 
    }

    // Update is called once per frame
    void Update()
    {
          transform.Translate(new Vector3(missileDirection, -1, 0) * Time.deltaTime * 3f);
          if (transform.position.x > (spawnPoint + 0.5f) || transform.position.x < (spawnPoint - 0.5f)){
              missileDirection = missileDirection * -1;
          }
        if (transform.position.y < -5.0f){
            Destroy(this.gameObject);
        }
    }
}
