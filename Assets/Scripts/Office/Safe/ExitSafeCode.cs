using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitSafeCode : MonoBehaviour
{
    [SerializeField] private AudioSource myAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate {
            myAudioSource.Play();
            SceneManager.LoadScene("Office");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
