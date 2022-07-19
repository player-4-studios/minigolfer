using UnityEngine;

public class mainCamera : MonoBehaviour
{
    [SerializeField] Transform[] cameraLocs;
    [SerializeField] int cameraLocIndex;
    [SerializeField] float moveSpeed;
    [SerializeField] public bool isActive;

    private void Update()
    {
        if (isActive)
        {
            transform.position = Vector3.Lerp(transform.position, cameraLocs[cameraLocIndex].position, moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, cameraLocs[cameraLocIndex].rotation, moveSpeed * Time.deltaTime);
        }

    }

    public void moveCam()
    {
        cameraLocIndex++;
    }

}
