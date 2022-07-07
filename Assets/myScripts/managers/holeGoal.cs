using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holeGoal : MonoBehaviour
{
    [SerializeField] private holeManager hMan;

    private void Start()
    {
        hMan = GetComponentInParent<holeManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hMan.madeHole();
        }
    }
}
