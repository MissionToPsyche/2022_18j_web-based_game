using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Eflatun.SceneReference;

public class ClickChangeScene : MonoBehaviour
{
    [SerializeField] public SceneReference scene;
    [SerializeField] private AudioSource myAudioSource;

    // [HideInInspector]
    // public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        // sceneName = scene.Name;
        myAudioSource.Play();
        Debug.Log("Path is: " + scene.Path);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
       LoadScene();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(scene.Name);
    }
}
