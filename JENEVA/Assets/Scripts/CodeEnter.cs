using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CodeEnter : MonoBehaviour
{
    void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        //var se = new InputField.SubmitEvent();
        //se.AddListener(SubmitName);
        //input.onEndEdit = se;
        input.onEndEdit.AddListener(SubmitName);
        //or simply use the line below, 
        //input.onEndEdit.AddListener(SubmitName);  // This also works
    }

    private void SubmitName(string arg0)
    {
        if(arg0 == "95762")
        {
            Storage.CodeCheck = true;
            SceneManager.LoadScene("JENEVA1.0");
        }
    }
}
