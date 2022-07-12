using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCamera : MonoBehaviour
{
    [SerializeField]
    private float sensitivity;

    private float rotX;
    private float rotY;

    [SerializeField] private Transform target;
    [SerializeField] private Transform setTarget;
    [SerializeField] private float followDist;
    [SerializeField] private float mouseYHold;
    [SerializeField] private float mouseXInput;

    [SerializeField] private Vector3 currentRot;
    [SerializeField] private Vector3 smoothVelo = Vector3.zero;

    [SerializeField] private float smoothTime;

    private void Update()
    {
        rotY += mouseXInput;
        rotX += mouseYHold;

        rotX = Mathf.Clamp(rotX, -25, 25);

        Vector3 nextRot = new Vector3(rotX, rotY);
        currentRot = Vector3.SmoothDamp(currentRot, nextRot, ref smoothVelo, smoothTime);
        transform.eulerAngles = currentRot;

        transform.position = target.position - transform.forward * followDist;
    }

    public void rot(float aimInput)
    {
        mouseXInput = aimInput;
    }

    public void resetRot()
    {
        transform.position = setTarget.position;
        transform.rotation = setTarget.rotation;
    }

}
