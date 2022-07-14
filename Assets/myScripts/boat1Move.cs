using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boat1Move : MonoBehaviour
{   //Janel's attempt starts here

    [SerializeField] Transform startTransform;
    [SerializeField] Transform endTransform;

    public int interpolationFramesCount = 5000; // Number of frames to completely interpolate between the 2 positions
    int elapsedFrames = 0;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;
        transform.position = Vector3.Lerp(startTransform.position, endTransform.position, interpolationRatio);
        elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);  // reset elapsedFrames to zero after it reached (interpolationFramesCount + 1)
    }
}
