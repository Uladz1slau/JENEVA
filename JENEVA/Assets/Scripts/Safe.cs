using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Safe : MonoBehaviour
{
    public double TargetingDist = 5;

    void Start()
    {
        
    }

    void Update()
    {
        GameObject unit = GameObject.FindWithTag("Unit");
        Vector3 dist = unit.transform.position - gameObject.transform.position;
        if (dist.magnitude < TargetingDist && Input.GetKey(KeyCode.K))
        {
            Storage.heropos = new Vector3(unit.transform.position.x, unit.transform.position.y, unit.transform.position.z);
            SceneManager.LoadScene("SafeBox");
        }
    }
}
