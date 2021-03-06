using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameCheck : MonoBehaviour
{
    public GameObject winprefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Unit").Length == 0 )
        {
            SceneManager.LoadScene("Menu");
        }
        if (Storage.CodeCheck)
        {
            StartCoroutine(waiter());
            Storage.PazzleWin = false;
        }
    }
    IEnumerator waiter()
    {
        Instantiate(winprefab);
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("Menu");
    }
}
