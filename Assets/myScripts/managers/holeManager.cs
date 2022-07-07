using UnityEngine;

public class holeManager : MonoBehaviour
{
    [SerializeField] public int holePar;
    [SerializeField] public int holeShots;
    [SerializeField] public int finalScore;
    [SerializeField] public Transform holeStart;
    [SerializeField] public Transform holeEnd;

    [Header("Other Managers")]
    [SerializeField] courseManager cMan;
    [SerializeField] scoreManager sMan;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void madeHole()
    {

        cMan.addScore(holeShots);
        cMan.nextHole();
        Debug.Log("Total shots: " + holeShots.ToString() + " " + "Par: " + holePar.ToString());
    }
}
