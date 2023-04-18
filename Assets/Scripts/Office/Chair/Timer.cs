using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;
    public Image tier1;
    public Image tier2;
    public Image tier3;

    public int T1Seconds;
    public int T2Seconds;

    [Header("Timer Settings")]
    public double currentTime;
    public bool countDown;

    [Header("Format Settings")]
    public bool hasFormat;

    public string format;

    // Start is called before the first frame update
    void Start()
    {
        format = "mm':'ss':'ff";
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        SetTimerText();
    }

    private void SetTimerText()
    {
        System.TimeSpan span = System.TimeSpan.FromSeconds(currentTime);
        timerText.text = hasFormat ? span.ToString(format) : currentTime.ToString();

        if (span.TotalSeconds > T2Seconds){
            tier1.enabled = false;
            tier2.enabled = false;
            tier3.enabled = true;
        }
        else if (span.TotalSeconds > T1Seconds){
            tier1.enabled = false;
            tier2.enabled = true;
            tier3.enabled = false;
        }
        else{
            tier1.enabled = true;
            tier2.enabled = false;
            tier3.enabled = false;
        }
    }
}
