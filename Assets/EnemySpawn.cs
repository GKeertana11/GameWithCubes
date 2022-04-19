using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
   public float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        float x = Random.Range(48.0f,-48.0f);
        float z = Random.Range(48.0f,-48.0f);
        
       
        if(time>3f)
        {
            Instantiate(enemy, new Vector3(x, 0.5f, z), Quaternion.identity);
            time = 0f;
        }

        
    }
}
