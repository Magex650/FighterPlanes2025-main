using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy02 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * 8f);
        if (transform.position.x < -8.4f){
            Destroy(this.gameObject);
        }
    }
}
