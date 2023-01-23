using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChairPuzzleEntry : MonoBehaviour
{
    private Color initialColor;
    public bool noEmissionAtStart = true;
    public Color highlightColor = Color.red;
    private bool mouseon = false;
    private Renderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        if (noEmissionAtStart)
            initialColor = Color.black;
        else
            initialColor = myRenderer.material.GetColor("_EmissionColor");
    }

    void OnMouseEnter()
    {
        mouseon = true;
        myRenderer.material.SetColor("_EmissionColor", highlightColor);

    }

    void OnMouseExit()
    {
        mouseon = false;
        myRenderer.material.SetColor("_EmissionColor", initialColor);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (mouseon == true)
            {
                SceneManager.LoadScene("ChairPuzzle");
            }
        }

    }
}

