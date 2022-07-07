using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class courseManager : MonoBehaviour
{
    [SerializeField] holeManager[] holesMan;
    [SerializeField] int holeIndex;
    [SerializeField] int coursePar;
    [SerializeField] int courseScore;
    [SerializeField] playerController pController;

    // Start is called before the first frame update
    void Start()
    {
        foreach (holeManager hMan in holesMan)
        {
            coursePar += hMan.holePar;
        }
        
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int holesShot)
    {
        courseScore = courseScore + holesShot;
    }
    public void nextHole()
    {
        
        holeIndex++;
        pController.nextHole(holesMan[holeIndex]);
    }
}
