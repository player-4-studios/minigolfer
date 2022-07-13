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
    [SerializeField] private Vector3 nextRot;
    [SerializeField] private Vector3 smoothVelo = Vector3.zero;

    [SerializeField] private float smoothTime;
    [SerializeField] public bool isSetting;

    private void Awake()
    {
      

    }
    private void Update()
    {
        if (isSetting)
        {
            resetRot();
        }
        else
        {
            setRot();
        }

    }

    public void setRot()
    {
        rotY += mouseXInput;
        rotX += mouseYHold;

        rotX = Mathf.Clamp(rotX, -25, 25);

        nextRot = new Vector3(rotX, rotY);
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
        nextRot.y = setTarget.rotation.y;
        transform.LookAt(target.position);
    }

}
