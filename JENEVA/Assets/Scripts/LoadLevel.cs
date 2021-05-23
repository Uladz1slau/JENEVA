using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Load()
    {
        GameObject hero = GameObject.Find("HERO!!!");
        Storage.heropos = new Vector3(hero.transform.position.x, hero.transform.position.y, hero.transform.position.z);
        SceneManager.LoadScene(sceneName);
    }
}
