using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] GameObject image;
    [SerializeField] Text text;
    [SerializeField] GameObject backButton;
    void Start()
    {
        BackButton();
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Author()
    {
        backButton.SetActive(true);
        image.SetActive(true);
        text.enabled = true;
    }
    public void BackButton()
    {
        text.enabled = false;
        backButton.SetActive(false);
        image.SetActive(false);
    }


}
