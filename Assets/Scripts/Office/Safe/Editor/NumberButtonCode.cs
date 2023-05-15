using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberButtonCode : MonoBehaviour
{
    private GameObject typecode;
    private string str_btn_txt;
    [SerializeField] private AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        //Set a listener for the buttons to call when clicked
        //Will call the function setText, to send the value to the TypeCode
        GetComponent<Button>().onClick.AddListener(delegate {
            myAudioSource.Play();
            str_btn_txt = GetComponentInChildren<TextMeshProUGUI>().text.ToString();
            FindObjectOfType<TypeCode>().setText(str_btn_txt[0]);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
