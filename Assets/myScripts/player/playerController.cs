using UnityEngine;
using UnityEngine.UI;
public class playerController : MonoBehaviour
{
    [SerializeField] Slider powerSlider;
    [SerializeField] GameObject aimObject;
    private Rigidbody rb;
    [SerializeField] float aimSpeed;
    [SerializeField] controlStates currentState;
    [SerializeField] GameObject[] uiObjects;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        switch (currentState)
        {
            case controlStates.aiming:
                {
                    
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        rb.AddForce(-aimObject.transform.forward * (powerSlider.value / 2), ForceMode.Impulse);
                        currentState = controlStates.inPlay;
                    }

                    if (Input.GetMouseButton(0))
                    {
                        transform.Rotate(0, Input.GetAxis("Mouse X") * aimSpeed * Time.deltaTime, 0);
                    }
                    break;
                }
            case controlStates.inPlay:
                {
                    foreach (GameObject uiPan in uiObjects)
                    {
                        uiPan.SetActive(false);
                    }
                    break;
                }
        }


    }

    public void shootBall()
    {
        rb.AddForce(-aimObject.transform.forward * (powerSlider.value / 2), ForceMode.Impulse);
        currentState = controlStates.inPlay;
    }

    public enum controlStates
    {
        aiming,
        inPlay
    }
}
