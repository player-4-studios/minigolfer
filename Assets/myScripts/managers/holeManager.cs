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
    public void madeHole()
    {
        cMan.completeHole(holeShots, holePar);
        Debug.Log("Total shots: " + holeShots.ToString() + " " + "Par: " + holePar.ToString());
    }
}
