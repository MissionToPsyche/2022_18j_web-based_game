using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeCode : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("typed_code").GetComponent<TextMeshProUGUI>().text = "____";
        //GameObject.Find("btn_1").GetComponent<Text>().text = "ghie";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setText(string text)
    {
        GameObject.Find("typed_code").GetComponent<TextMeshProUGUI>().text = text;
    }
}
