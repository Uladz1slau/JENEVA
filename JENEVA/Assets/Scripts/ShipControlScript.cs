using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControlScript : MonoBehaviour
{
    public float Speed = 0.1f;
    public float UpBorder = 10f;
    public float DownBorder = 10f;
    public float LeftBorder = 10f;
    public float RightBorder = 10f;
    public GameObject prefab;
    public float force = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyUp(KeyCode.Space))
        {
            Shoot();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.rotation = Quaternion.Euler(-90, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            if (gameObject.transform.position.y + Speed < UpBorder)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + Speed, gameObject.transform.position.z);
                gameObject.transform.rotation = Quaternion.Euler(-70, 0, 0);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (gameObject.transform.position.y - Speed > DownBorder)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - Speed, gameObject.transform.position.z);
                gameObject.transform.rotation = Quaternion.Euler(-110, 0, 0);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (gameObject.transform.position.x - Speed > LeftBorder)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - Speed, gameObject.transform.position.y, gameObject.transform.position.z);
                gameObject.transform.rotation = Quaternion.Euler(-90, 20, 0);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (gameObject.transform.position.x + Speed < RightBorder)
            { 
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + Speed, gameObject.transform.position.y, gameObject.transform.position.z);
                gameObject.transform.rotation = Quaternion.Euler(-90, -20, 0);
            }
        }
    }
    void Shoot()
    {
        GameObject clone = Instantiate(prefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5, 50), Quaternion.identity);
        clone.GetComponent<Rigidbody>().AddForce(force * new Vector3(0, 1, 0));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DestroyObj")
            StartCoroutine(waiter());
    }
    IEnumerator waiter()
    {
        gameObject.GetComponentInChildren<Animator>().SetBool("IsAlive", false);
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }
}
