using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class mainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject coursePanel;
    [SerializeField] GameObject creditsPanel;
    [SerializeField] GameObject optionsPanel;

    // Start is called before the first frame update
    void Start()
    {
        mainPanel.SetActive(true);
    }
    public void backToMain()
    {
        mainPanel.SetActive(true);
        coursePanel.SetActive(false);
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }
    public void courseSelection()
    {
        mainPanel.SetActive(false);
        coursePanel.SetActive(true);
    }

    public void toOptions()
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void creditsPan()
    {
        mainPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void loadCourse(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
