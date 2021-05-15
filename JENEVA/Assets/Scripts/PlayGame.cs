using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayGame : MonoBehaviour
{
    public string sceneName;
    public Button PlayButton;
    void Start()
    {
        PlayButton.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}