using UnityEngine;

public class opening : MonoBehaviour
{
    [SerializeField] Transform[] camLocs;
    [SerializeField] int camLocIndex;
    [SerializeField] float navDist;
    [SerializeField] float camSpeed;
    [SerializeField] private mainCamera mCam;
    [SerializeField] private bool isIntro;
    [SerializeField] GameObject playerHud;
    // Start is called before the first frame update
    void Start()
    {
        mCam = GetComponent<mainCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isIntro)
        {
            playerHud.SetActive(false);
            transform.position = Vector3.MoveTowards(transform.position, camLocs[camLocIndex].position, camSpeed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, camLocs[camLocIndex].rotation, camSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, camLocs[camLocIndex].position) <= navDist)
            {
                nextPos();
            }
        }
        
    }

    public void nextPos()
    {
        if (camLocIndex >= camLocs.Length - 1)
        {
            playerHud.SetActive(true);
            isIntro = false;
            mCam.isActive = true;
        }
        else
        {
            camLocIndex++;
        }
    }
}
