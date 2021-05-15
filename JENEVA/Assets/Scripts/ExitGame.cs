using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    public Button ExitButton;
    void Start()
    {
        ExitButton.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        Application.Quit();
    }
}