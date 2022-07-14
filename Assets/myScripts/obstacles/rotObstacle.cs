using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotObstacle : MonoBehaviour
{
    [SerializeField] Quaternion rotPoint;
    [SerializeField] float rotSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotPoint.eulerAngles, rotSpeed * Time.deltaTime);
    }

}
