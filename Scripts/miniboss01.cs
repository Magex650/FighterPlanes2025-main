using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniboss01 : MonoBehaviour
{
    private float miniBossSpeed = 0.9f;
    public GameObject missile;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("missileLaunch", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
      // Movement
        transform.Translate(new Vector3(miniBossSpeed, 0, 0) * Time.deltaTime);
        if(transform.position.x > 7 || transform.position.x < -7){
            miniBossSpeed = miniBossSpeed * -1;
        }
    }
    // Spawn MissileProjectile
    void missileLaunch (){
         Instantiate(missile, transform.position, Quaternion.identity);
        }
}
