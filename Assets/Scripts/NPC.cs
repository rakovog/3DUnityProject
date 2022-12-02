using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [SerializeField] GameObject dialogue;
    [SerializeField] Text firstText;
    [SerializeField] Text secondText;
    [SerializeField] Text thirdText;
    [SerializeField] GameObject lorButton;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject exitButton;
    [SerializeField] GameObject nextButton;
    [SerializeField] AudioSource playerAudio;

    void Start()
    {
        Refresh();
    }

    public void Answer()
    {
        firstText.enabled = false;
        secondText.enabled = true;
        thirdText.enabled = false;
        lorButton.SetActive(false);
        nextButton.SetActive(false);
        backButton.SetActive(true);
    }
    public void Lor()
    {
        firstText.enabled = false;
        secondText.enabled = false;
        thirdText.enabled = true;
        lorButton.SetActive(false);
        nextButton.SetActive(false);
        backButton.SetActive(true);
    }

    public void ExitDialogue()
    {
        dialogue.SetActive(false);
        FindObjectOfType<PlayerLook>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        Refresh();
    }

    public void Refresh()
    {
        firstText.enabled = true;
        secondText.enabled = false;
        thirdText.enabled = false;
        exitButton.SetActive(true);
        nextButton.SetActive(true);
        lorButton.SetActive(true);
        backButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        dialogue.SetActive(true);
        FindObjectOfType<PlayerLook>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        playerAudio.Stop();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ExitDialogue();
        }
    }
}