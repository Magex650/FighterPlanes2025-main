using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
public GameObject enemy01;
public GameObject enemy02;
public GameObject miniBoss;
public GameObject enemy04;
// Start is called before the first frame update
    void Start()
    {
     InvokeRepeating("Enemy01Spawn", 2.0f, 0.3f);
     InvokeRepeating("Enemy04Spawn", 2.0f, 0.3f);
     //InvokeRepeating("Enemy02Spawn", 2.0f, 0.3f);
     InvokeRepeating("miniBossSpawn", 15.0f, 15.0f);
    }

    void Enemy01Spawn()
    {
        var spawnpoint = new Vector3(Random.Range(-8.4f, 8.41f), 6.8f, 0f);
        Instantiate(enemy01, spawnpoint, Quaternion.identity);
    }

    void Enemy04Spawn ()
   {
        var spawnpoint = new Vector3(Random.Range(-8.4f, 8.41f), 6.8f, 0f);
        Instantiate(enemy04, spawnpoint, Quaternion.identity);
    }

    // Created Visual Clutter. Replaced with MiniBoss01
   // void Enemy02Spawn (){
   //     var spawnpoint = new Vector3(11, Random.Range(-4.4f, 6.5f), 0f);
   //     Instantiate(enemy02, spawnpoint, Quaternion.identity);
  //  }

    void miniBossSpawn (){
        var spawnpoint = new Vector3(0f, 6.0f, 0f);
        Instantiate (miniBoss, spawnpoint, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
    
    }
}
