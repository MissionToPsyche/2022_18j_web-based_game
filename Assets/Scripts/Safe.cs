using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Safe: MonoBehaviour
{
    private Color initialColor;
    public bool noEmissionAtStart = true;
    public Color highlightColor = Color.red;
    private bool mouseon = false;
    private Renderer myRenderer;

    public MonoBehaviour camera;
    public bool unlocked = false;

    [Header("Safe Settings")]
    public string password = "1234";
    public string input;
    public Text displayText;
    public GameObject objectToEnable;
    public GameObject Key;

    private bool keypadScreen;
    private int clickCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        if (noEmissionAtStart)
            initialColor = Color.black;
        else
            initialColor = myRenderer.material.GetColor("_EmissionColor");

        keypadScreen = false;
        clickCount = 0;
        camera = GameObject.Find("OfficeCamera").GetComponent<CameraMovement>();
        
    }

    void OnMouseEnter()
    {
        if(keypadScreen || unlocked)
        {
            return;
        }
        mouseon = true;
        myRenderer.material.SetColor("_EmissionColor", highlightColor);
    }

  void OnMouseExit()
    {
        if(keypadScreen || unlocked)
        {
            return;
        }
        mouseon = false;
        myRenderer.material.SetColor("_EmissionColor",initialColor);
    }

    // Update is called once per frame
    void Update()
    {
        // Trigger to display the keypad
        if (Input.GetMouseButtonDown(0) && !unlocked)
            {
                if (mouseon == true)
                {
                    myRenderer.material.SetColor("_EmissionColor",initialColor);
                    mouseon = false;
                    input = "";
                    clickCount = 0;
                    displayText.text = "";

                    keypadScreen = true;
                    GameObject.Find("GameCamera").GetComponent<CameraMovement>().Pause();
                    objectToEnable.SetActive(true);
                }
            }

        // Check password when length is appropriate
        if(clickCount == password.Length)
        {
            if (input == password)
            {
                input = "";
                displayText.text = "ACCEPTED";
                clickCount = 0;
                //StartCoroutine(Wait());
                objectToEnable.SetActive(false);
                keypadScreen = false;
                Key.SetActive(true);
                unlocked = true;
                GameObject.Find("GameCamera").GetComponent<CameraMovement>().Resume();
            }

            else
            {
                input = "";
                displayText.text = "ERROR";
                clickCount = 0;
                //StartCoroutine(Wait());
                displayText.text = "";
            }
        }
    }

    public void ValueEntered(string val)
    {
        clickCount++;
        input += val;
        displayText.text = input.ToString();
    }

    public void ExitPressed()
    {
        objectToEnable.SetActive(false);
        keypadScreen = false;
        GameObject.Find("GameCamera").GetComponent<CameraMovement>().Resume();
    }

    // IEnumerator Wait()
    // {
    //     yield return new WaitForSeconds(2);
    // }
}

