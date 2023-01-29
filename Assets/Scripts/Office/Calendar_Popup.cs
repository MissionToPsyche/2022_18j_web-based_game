using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar_Popup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        //When clicked, show popup information
        //StartCoroutine(CalendarPopup());
    }

    IEnumerator CalendarPopup()
    {
        GameObject.Find("Calendar Event").transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0f);
        GameObject.Find("Calendar Event").transform.GetChild(0).gameObject.SetActive(false);

    }
}
