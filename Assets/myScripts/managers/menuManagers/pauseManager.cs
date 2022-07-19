using UnityEngine;
using UnityEngine.SceneManagement;
public class pauseManager : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void pauseGame()
    {
        if (pausePanel.activeInHierarchy == false)
        {
            pausePanel.SetActive(true);
        }
        else
        {
            pausePanel.SetActive(false);
        }

    }



    public void quitToMain()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
