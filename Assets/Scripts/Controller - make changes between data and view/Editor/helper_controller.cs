using Codice.Client.BaseCommands;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class helper_controller
{
    GameObject glossaryContent;
    private static helper_controller helpC = new helper_controller();
    private scene_controller sceneC = scene_controller.getInstance();
    private point_controller pointC = point_controller.getInstance();

    private helper_controller() { }
    public static helper_controller getInstance() { return helpC; }

    public void setGlossaryContent(GameObject glossaryContent)
    {
        this.glossaryContent = glossaryContent;
    }

    public void createContent()
    {
        string filepath = Application.dataPath + "/Scripts/Model/GlossaryTerms.txt";
        StreamReader inpStm = new StreamReader(filepath);
        int counter = 1;
        int content_Height = 0;
        while (!inpStm.EndOfStream)
        {
            //add more to the height of the content for every term and defintion entered
            glossaryContent.GetComponent<RectTransform>().sizeDelta = new Vector2(720, content_Height += 170);

            //read in text line by line
            string line = inpStm.ReadLine();
            string[] termDef = line.Split('-');

            //create children gameobjects
            //create term child
            GameObject contentTerm = new GameObject("Term " + counter.ToString());
            contentTerm.AddComponent<TextMeshProUGUI>().text = termDef[0];
            contentTerm.transform.SetParent(glossaryContent.transform, false);

            //create defintion child
            GameObject contentDef = new GameObject("Defintion " + counter.ToString());
            contentDef.AddComponent<TextMeshProUGUI>().text = termDef[1];
            contentDef.GetComponent<TextMeshProUGUI>().fontSize= 18;
            contentDef.transform.SetParent(glossaryContent.transform, false);
            counter++;
        }
        inpStm.Close();
    }
    
    public void OnclickBtns()
    {
        //Glossary Button
        GameObject.Find("Glossary").GetComponent<Button>().onClick.AddListener(
            delegate
            {
                sceneC.loadSideScene("Glossary");
            });
        //Exit Game Button
        GameObject.Find("Exit Game").GetComponent<Button>().onClick.AddListener(
            delegate
            {
                //ask if they really want to leave, when they leave the website their data will not save.
                sceneC.loadSideScene("MainMenu");
            });
        //Tutorial Button

        //Help/Hints Button
        GameObject.Find("Help / Hints").GetComponent<Button>().onClick.AddListener(
            delegate
            {
                TextMeshProUGUI helpertxt = GameObject.Find("HelperText").GetComponent<TextMeshProUGUI>();
                Image coverimg = GameObject.Find("Hint Display").GetComponent<Image>();
                coverimg.enabled = true;
                helpertxt.enabled= true;
                helpertxt.text = pointC.hintTxt();

            });
    }


}
