using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;
using UnityEngine.SceneManagement;
using Eflatun.SceneReference;

public class Terminal : MonoBehaviour
{
    private GameObject type_code;

    //example to see if working
    [SerializeField] private string correct_code;
    [SerializeField] private string enter_code;
    [SerializeField] private SceneReference myScene;
    [SerializeField] private AudioSource correct;
    [SerializeField] private AudioSource wrong;
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
        if (Input.GetKeyDown(KeyCode.A))
        {
            setText('A');
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            setText('B');
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            setText('C');
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            setText('D');
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            setText('E');
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            setText('F');
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            setText('G');
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            setText('H');
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            setText('I');
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            setText('J');
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            setText('K');
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            setText('L');
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            setText('M');
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            setText('N');
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            setText('O');
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            setText('P');
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            setText('Q');
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            setText('R');
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            setText('S');
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            setText('T');
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            setText('U');
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            setText('V');
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            setText('W');
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            setText('X');
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            setText('Y');
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            setText('Z');
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            setText(' ');
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            enterCode();
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            deleteText();
        }
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
                entered_code = sb.ToString();
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
                entered_code = sb.ToString();
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
        if (entered_code == correct_code)
        {
            StartCoroutine(CorrectCodeEntered());
        }
        else
        {
            StartCoroutine(WrongCodeEntered());
        }


    }

    IEnumerator CorrectCodeEntered()
    {
        GameObject.Find("typed_code").GetComponent<TextMeshProUGUI>().color = Color.green;
        correct.Play();
        Safe_Locked.IsLocked = false;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(myScene.Name);

    }

    IEnumerator WrongCodeEntered()
    {
        GameObject.Find("typed_code").GetComponent<TextMeshProUGUI>().color = Color.red;
        wrong.Play();
        yield return new WaitForSeconds(2);
    }
}
