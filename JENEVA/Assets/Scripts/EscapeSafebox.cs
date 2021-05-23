using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EscapeSafebox : MonoBehaviour
{
    public string sceneName;
    public Button EscButton;
    void Start()
    {
        EscButton.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}
