using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSpit : MonoBehaviour
{
    public GameObject missile;
    public float bulletInterval = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("missileLaunch", bulletInterval, bulletInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void missileLaunch (){
         Instantiate(missile, new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z), Quaternion.Euler(180, 0, 0));
        }
}
