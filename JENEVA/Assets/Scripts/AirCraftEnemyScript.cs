using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCraftEnemyScript : MonoBehaviour
{
    public float speed = -0.1f;
    public GameObject prefab;
    public float StartTime;
    public float RepTime;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", StartTime, RepTime);
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
    void Shoot()
    {
        RaycastHit hit;
        Ray ray = new Ray(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 20, 50), new Vector3(0, -1, 0));
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag != "DestroyObj")
            {
                GameObject clone = Instantiate(prefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 20, 50), Quaternion.identity);
                clone.GetComponent<Rigidbody>().AddForce(500 * new Vector3(0, -1, 0));
            }
        }
    }
}
