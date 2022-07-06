using UnityEngine;
using UnityEngine.UI;
public class playerController : MonoBehaviour
{
    //Physics
    private Rigidbody rb;

    //Power and Aiming
    [Header("Power and Aiming")]
    [SerializeField] Slider powerSlider;
    [SerializeField] float powerValMultiplier;
    [SerializeField] GameObject aimObject;
    [SerializeField] float aimSpeed;
    [SerializeField] bool startedSwing;
    [SerializeField] float ballStopSpeed;

    //State
    [SerializeField] controlStates currentState;

    //UI
    [Header("UI")]
    [SerializeField] GameObject[] uiObjects;
    [SerializeField] VariableJoystick aimStick;
    [SerializeField] VariableJoystick powerStick;

    //Managers
    [Header("Other Managers")]
    [SerializeField] holeManager hMan;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 1000f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.velocity.magnitude);
        switch (currentState)
        {
            case controlStates.aiming:
                {
                    //Hit ball
                    
                    if (powerStick.Vertical <= -.5)
                    {
                        startedSwing = true;
                        powerSlider.value = powerSlider.value + powerValMultiplier * Time.deltaTime;
                        if (powerSlider.value >= powerSlider.maxValue)
                        {
                            shootBall();
                        }
                    }
                    else
                    {
                        if (startedSwing == true && powerStick.Vertical == 0)
                        {
                            shootBall();
                        }
                    }

                    //Aim
                    if (Input.GetMouseButton(0))
                    {
                        //Get UI joystick horizontal axis
                        transform.Rotate(0, aimStick.Horizontal * aimSpeed * Time.deltaTime, 0);
                    }

                    break;
                }
            case controlStates.inPlay:
                {
                    startedSwing = false;
                    foreach (GameObject uiPan in uiObjects)
                    {
                        uiPan.SetActive(false);
                    }

                    if (rb.velocity.magnitude <= ballStopSpeed)
                    {
                        setAim();
                    }
                    break;
                }
        }


    }

    public void shootBall()
    {
        rb.AddForce(-aimObject.transform.forward * (powerSlider.value / 2), ForceMode.Impulse);
        hMan.holeShots = hMan.holeShots + 1;
        currentState = controlStates.inPlay;
    }

    public void setAim()
    {
        powerSlider.value = 0;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        foreach (GameObject uiPan in uiObjects)
        {
            uiPan.SetActive(true);
        }
        currentState = controlStates.aiming;
    }
    public enum controlStates
    {
        aiming,
        inPlay
    }
}
