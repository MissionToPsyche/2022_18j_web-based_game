using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SSGameManagerScript : MonoBehaviour
{
    private List<int> playerTaskList = new List<int>();
    private List<int> playerSequenceList = new List<int>();

    public List<AudioClip> buttonSoundsList = new List<AudioClip>();
    public List<List<Color32>> buttonColors = new List<List<Color32>>();
    public List<Button> clickableButtons = new List<Button>();

    public AudioClip loseSound;
    public AudioSource audioSource;
    public CanvasGroup buttons;
    public GameObject startButton;

    private bool playerLost = false;
    private int taskIndex = 0;

    void Start()
    {
        buttonColors.Add(new List<Color32> { new Color32(255, 100, 100, 255), new Color32(255, 0, 0, 255) });
        buttonColors.Add(new List<Color32> { new Color32(255, 187, 109, 255), new Color32(255, 136, 0, 255) });
        buttonColors.Add(new List<Color32> { new Color32(162, 255, 124, 255), new Color32(72, 248, 0, 255) });
        buttonColors.Add(new List<Color32> { new Color32(57, 111, 255, 255), new Color32(0, 70, 255, 255) });

        for (int i = 0; i < 4; i++)
        {
            clickableButtons[i].GetComponent<Image>().color = buttonColors[i][0];
        }
    }

    void Update()
    {
        if (playerLost)
        {
            StartCoroutine(PlayerLost());
            playerLost = false;
        }
    }

    public void AddToPlayerSequenceList(int buttonId)
    {
        if (!playerLost)
        {
            playerSequenceList.Add(buttonId);
            StartCoroutine(HighlightButton(buttonId));
            if (playerSequenceList.Count == playerTaskList.Count)
            {
                CompareLists();
            }
        }
    }

    public void StartGame()
    {
        StartCoroutine(StartNextRound());
        startButton.SetActive(false);
    }

    IEnumerator HighlightButton(int buttonId)
    {
        clickableButtons[buttonId].GetComponent<Image>().color = buttonColors[buttonId][1];
        audioSource.PlayOneShot(buttonSoundsList[buttonId]);
        yield return new WaitForSeconds(0.5f);
        clickableButtons[buttonId].GetComponent<Image>().color = buttonColors[buttonId][0];
    }

    IEnumerator StartNextRound()
    {
        playerSequenceList.Clear();
        buttons.interactable = false;
        yield return new WaitForSeconds(1f);
        playerTaskList.Add(Random.Range(0, 4));
        taskIndex = 0;
        foreach (int index in playerTaskList)
        {
            yield return StartCoroutine(HighlightButton(index));
        }
        buttons.interactable = true;
        yield return null;
    }

    void CompareLists()
    {
        for (int i = 0; i < playerSequenceList.Count; i++)
        {
            if (playerTaskList[i] != playerSequenceList[i])
            {
                playerLost = true;
                break;
            }
            else if (i == playerSequenceList.Count - 1)
            {
                StartCoroutine(StartNextRound());
            }
        }
    }

    IEnumerator PlayerLost()
    {
        audioSource.PlayOneShot(loseSound);
        playerSequenceList.Clear();
        yield return null;
    }
}