using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SSGameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private List<int> playerTaskList = new List<int>();
    private List<int> playerSequenceList = new List<int>();

    public List<AudioClip> buttonSoundsList = new List<AudioClip>();

    public List<List<Color32>> buttonColors = new List<List<Color32>>();

    public List<Button> clickableButtons;

    public AudioClip loseSound;

    public AudioSource audioSource;

    public CanvasGroup buttons;

    public GameObject startButton;


    void Start()
    {
      
    }

    public void Awake()
    {
        buttonColors.Add(new List<Color32> { new Color32(255, 100, 100, 255), new Color32(255, 0, 0, 255) });
        buttonColors.Add(new List<Color32> { new Color32(255, 187, 109, 255), new Color32(255, 136, 0, 255) });
        buttonColors.Add(new List<Color32> { new Color32(162, 255, 124, 255), new Color32(72, 248, 0, 255) });
        buttonColors.Add(new List<Color32> { new Color32(57, 111, 255, 255), new Color32(0, 70, 255, 255) });

        for (int i=0;i<4;i++)
        {
            clickableButtons[i].GetComponent<Image>().color = buttonColors[i][0];
        }

    }

    public void AddToPlayerSequenceList(int buttonId)
    {
        playerSequenceList.Add(buttonId);
        StartCoroutine(HighlightButton(buttonId));
        for (int i=0;i<playerSequenceList.Count;i++)
        {
            if(playerTaskList[i] == playerSequenceList[i])
            {
                continue;
            }
            else
            {
                Debug.Log("Lost");
                return;
            }
        }
        if(playerSequenceList.Count == playerTaskList.Count)
        {
            Debug.Log("StartNextRound");
        }
    }

    public void StartGame()
    {
        StartCoroutine(StartNextRound());
        startButton.SetActive(false);
    }


    public IEnumerator HighlightButton(int buttonId)
    {
        clickableButtons[buttonId].GetComponent<Image>().color = buttonColors[buttonId][1];
        audioSource.PlayOneShot(buttonSoundsList[buttonId]);
        yield return new WaitForSeconds(0.5f);
    }

    public IEnumerator PlayerLost()
    {
        audioSource.PlayOneShot(loseSound);
        playerSequenceList.Clear();
        yield return new WaitForSeconds(2f);
        startButton.SetActive(true);
    }

    public IEnumerator StartNextRound()
    {
        playerSequenceList.Clear();
        buttons.interactable = false;
        yield return new WaitForSeconds(1f);
        playerTaskList.Add(Random.Range(0, 4));
        foreach(int index in playerTaskList)
        {
            yield return StartCoroutine(HighlightButton(index));
        }
        buttons.interactable = true;
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
