using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CongratsScreen : MonoBehaviour
{
    public float FadeRate;
    private Image image;
    private float targetAlpha;
    
    // Start is called before the first frame update
    void Start()
    {   
        FadeRate = 3.0f;
        image = GetComponent<Image>();
        targetAlpha = image.color.a;
        StartCoroutine(FadeOut());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeOut() 
    {
        yield return new WaitForSeconds(3);
        targetAlpha = 0.0f;
        Color curColor = image.color;
        while(Mathf.Abs(curColor.a - targetAlpha) > 0.001f) 
        {
            Debug.Log(curColor.a);
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, FadeRate * Time.deltaTime);
            image.color = curColor;
            yield return null;
        }
        curColor.a = 0.0f;
        image.color = curColor;
    }
}
