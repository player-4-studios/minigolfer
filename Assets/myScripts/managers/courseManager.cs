using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class courseManager : MonoBehaviour
{
    [SerializeField] holeManager[] holesMan;
    [SerializeField] int holeIndex;
    [SerializeField] int coursePar;
    [SerializeField] int courseScore;
    [SerializeField] int holeNumber;
    [SerializeField] playerController pController;

    [SerializeField] GameObject holeCompletePanel;
    [SerializeField] GameObject courseCompletePanel;
    [SerializeField] TextMeshProUGUI holeStrokes;
    [SerializeField] TextMeshProUGUI holeParText;
    [SerializeField] TextMeshProUGUI courseStrokes;
    [SerializeField] TextMeshProUGUI courseParText;
    [SerializeField] TextMeshProUGUI holeIdent;
    [SerializeField] TextMeshProUGUI finaLCourseScore;
    // Start is called before the first frame update
    void Start()
    {
        foreach (holeManager hMan in holesMan)
        {
            coursePar += hMan.holePar;
        }
        
    }

    public void Update()
    {
        Debug.Log(courseScore.ToString());
    }

    public void completeHole(int holeShot, int holePar)
    {
        Debug.Log(holeShot.ToString());
        courseScore = courseScore + holeShot;
        holeCompletePanel.SetActive(true);
        holeStrokes.text = "Strokes: " + holeShot.ToString();
        holeParText.text = "Par: " + holePar.ToString();
        courseStrokes.text = "Total Strokes: " + courseScore.ToString();
        courseParText.text = "Course Par: " + coursePar.ToString();
        holeIdent.text = holeNumber.ToString();
        holeIdent.text = "Hole #" + (holeNumber + 1).ToString();

    }
    public void nextHole()
    {
        
        holeIndex++;
        holeNumber++;
        holeCompletePanel.SetActive(false);
        pController.nextHole(holesMan[holeIndex]);
    }

    public void mainmenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void endCourse()
    {
        courseCompletePanel.SetActive(true);
        var totalStrokeScore = courseScore - coursePar;
        if(totalStrokeScore < 0)
        {
            finaLCourseScore.text = courseScore.ToString() + " / " + coursePar.ToString() + "  -" + totalStrokeScore.ToString();
        }
        else
        {
            finaLCourseScore.text = courseScore.ToString() + " / " + coursePar.ToString() + "  +" + totalStrokeScore.ToString();
        }
        
    }
}
