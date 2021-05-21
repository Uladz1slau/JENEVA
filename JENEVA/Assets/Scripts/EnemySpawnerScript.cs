using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{

    public GameObject prefab;
    public float StartTime;
    public float RepTime;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", StartTime, RepTime);
    }

    // Update is called once per frame
    void Update()
    {      
        
    }
    void Spawn()
    {
        Instantiate(prefab, gameObject.transform.position, gameObject.transform.rotation);
    }
}
