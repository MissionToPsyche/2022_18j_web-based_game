using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;
using UnityEngine.SceneManagement;
using Eflatun.SceneReference;

public class TypeCode : MonoBehaviour
{
    private GameObject type_code;

    //example to see if working
    [SerializeField] private string correct_code;
    [SerializeField] private string enter_code;
    [SerializeField] private SceneReference myScene;
    public string entered_code
    {
        get { return enter_code; }
        set { enter_code = value; }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //set mouse lock state
        //the user has access to their mouse within the game window to enter in the code
        Cursor.lockState = CursorLockMode.Confined;

        type_code = GameObject.Find("typed_code").gameObject;
        type_code.GetComponent<TextMeshProUGUI>().text = enter_code;
        //entered_code = "____";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setText(char text)
    {
        GameObject.Find("typed_code").GetComponent<TextMeshProUGUI>().color = Color.white;
        // go through the entered code given
        StringBuilder sb = new StringBuilder(entered_code);
        for (int i = 0; i < entered_code.Length; i++)
        {
            if (entered_code[i] == '_')
            {
                sb[i] = text;
                entered_code= sb.ToString();
                GameObject.Find("typed_code").GetComponent<TextMeshProUGUI>().text = entered_code;
                Debug.Log(entered_code);
                break;
            }

        }

    }
    
    public void deleteText()
    {
        GameObject.Find("typed_code").GetComponent<TextMeshProUGUI>().color = Color.white;
        // go through the entered_code variable
        StringBuilder sb = new StringBuilder(entered_code);
        for (int i = entered_code.Length - 1; i >= 0; i--)
        {
            if (entered_code[i] != '_')
            {
                sb[i] = '_';
                entered_code= sb.ToString();
                GameObject.Find("typed_code").GetComponent<TextMeshProUGUI>().text = entered_code;
                break;
            }
        }
    }

    public void enterCode()
    {
        // Display a red flash & clear code -- code entered is incorrect
        // Display a green flash -- code entered is correct
        // Take the user back to the main screen with safe door opened
        if(entered_code == correct_code)
        {
            GameObject.Find("typed_code").GetComponent<TextMeshProUGUI>().color = Color.green;
            Safe_Locked.IsLocked = false;
            SceneManager.LoadScene(myScene.Name);
        }
        else
        {
            GameObject.Find("typed_code").GetComponent<TextMeshProUGUI>().color = Color.red;
        }


    }
}
