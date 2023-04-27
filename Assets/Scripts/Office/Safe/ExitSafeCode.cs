using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Eflatun.SceneReference;

public class ExitSafeCode : MonoBehaviour
{
    [SerializeField] private AudioSource myAudioSource;
    [SerializeField] private SceneReference myScene;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate {
            myAudioSource.Play();
            Debug.Log("Loading Conference Room");
            SceneManager.LoadScene(myScene.Name);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
