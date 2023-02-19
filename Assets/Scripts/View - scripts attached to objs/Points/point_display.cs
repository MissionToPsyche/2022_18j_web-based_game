using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class point_display : MonoBehaviour
{
    // Start is called before the first frame update
    private point_controller pointC = point_controller.getInstance();
    private void Awake()
    {
        TextMeshProUGUI mainmission = gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI sidemission = gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI totalmission = gameObject.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>();

        string initial_main = mainmission.text;
        string initial_side = sidemission.text;
        string initial_total = totalmission.text;

        pointC.initializeTextMesh(new TextMeshProUGUI[] {mainmission, sidemission, totalmission}, new string[] {initial_main, initial_side, initial_total});
    }
    
}
