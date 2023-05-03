using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DELButtonCode : MonoBehaviour
{
    [SerializeField] private AudioSource myAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        // Set a listener for the buttons to call when clicked
        // Will call the function deleteText, to delete the last value typed in the code
        GetComponent<Button>().onClick.AddListener(delegate {
            myAudioSource.Play();
            FindObjectOfType<TypeCode>().deleteText();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
