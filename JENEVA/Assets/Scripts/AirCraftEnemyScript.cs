using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCraftEnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(waiter());
    }
    IEnumerator waiter()
    {
        gameObject.GetComponentInChildren<Animator>().SetBool("IsAlive", false);
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }
}
