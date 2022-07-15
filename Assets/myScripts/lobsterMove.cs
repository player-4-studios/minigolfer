using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lobsterMove : MonoBehaviour
{
    [SerializeField] Transform[] points;
    [SerializeField] int pointsIndex;
    [SerializeField] float navDistance;
    [SerializeField] float speed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, points[pointsIndex].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, points[pointsIndex].position) <= navDistance)
        {
            nextPoint();
        }


    }



    public void nextPoint()
    {
        if (pointsIndex >= points.Length - 1)
        {
            pointsIndex = 0;
        }
        else
        {
            pointsIndex++;
        }
    }
}
