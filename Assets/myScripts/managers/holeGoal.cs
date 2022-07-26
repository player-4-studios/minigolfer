using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holeGoal : MonoBehaviour
{
    [SerializeField] private holeManager hMan;
    private Collider collid;

    private void Start()
    {
        collid = GetComponent<Collider>();
        hMan = GetComponentInParent<holeManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(other.gameObject.name);
                collid.enabled = false;
                hMan.madeHole();
            
        }
    }
}
