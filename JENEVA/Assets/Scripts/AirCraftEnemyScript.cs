using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCraftEnemyScript : MonoBehaviour
{
    public float speed = -0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position += new Vector3(0, speed, 0);
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ship")
            StartCoroutine(waiter());
    }
    IEnumerator waiter()
    {
        gameObject.GetComponentInChildren<Animator>().SetBool("IsAlive", false);
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }
}
