using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCode : MonoBehaviour
{
    private GameObject typecode;
    private string str_btn_txt;

    // Start is called before the first frame update
    void Start()
    {
        //Set a listener for the buttons to call when clicked
        //Will call the function setText, to send the value to the TypeCode
        GetComponent<Button>().onClick.AddListener(delegate { setText(); });
        str_btn_txt = GetComponentInChildren<TextMeshProUGUI>().text.ToString();
        typecode = GameObject.Find("typed_code");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setText()
    {
        Debug.Log(str_btn_txt + " button pressed");
        typecode.GetComponent<TypeCode>().setText(str_btn_txt);
    }
}
