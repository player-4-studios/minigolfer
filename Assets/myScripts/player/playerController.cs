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
    [SerializeField] float deadBallWaitMax;
    [SerializeField] float deadBallWait;

    //UI
    [Header("UI")]
    [SerializeField] GameObject[] uiObjects;
    [SerializeField] VariableJoystick aimStick;
    [SerializeField] VariableJoystick powerStick;

    //Managers
    [Header("Other Managers")]
    [SerializeField] holeManager hMan;
    [SerializeField] courseManager cMan;
    mainCamera mCam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 1000f;
        mCam = Camera.main.GetComponent<mainCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case controlStates.aiming:
                {
                    //Hit ball
                    //mCam.isSetting = true;
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

                    if (rb.velocity.magnitude <= ballStopSpeed)
                    {
                        deadBallWait = deadBallWait - 1 * Time.deltaTime;
                        if (deadBallWait <= 0)
                        {
                            setAim();
                        }

                    }
                    break;
                }
            case controlStates.getScore:
                {
                    break;
                }

        }


    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "OutOfBounds")
        {
            transform.position = hMan.holeStart.transform.position;
            transform.rotation = hMan.holeStart.transform.rotation;
        }
    }

    public void shootBall()
    {
        rb.AddForce(-aimObject.transform.forward * (powerSlider.value / 20), ForceMode.Impulse);
        hMan.holeShots = hMan.holeShots + 1;
        startedSwing = false;
        foreach (GameObject uiPan in uiObjects)
        {
            uiPan.SetActive(false);
        }
        currentState = controlStates.inPlay;
    }

    public void setAim()
    {
        currentState = controlStates.aiming;
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;
        powerSlider.value = 0;
        deadBallWait = deadBallWaitMax;
        transform.LookAt(hMan.holeEnd);
        foreach (GameObject uiPan in uiObjects)
        {
            uiPan.SetActive(true);
        }
    }

    public void nextHole(holeManager hMann)
    {
        mCam.moveCam();
        hMan = hMann;
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;
        transform.position = hMan.holeStart.transform.position;
        transform.rotation = hMan.holeStart.transform.rotation;
        powerSlider.value = 0;
        deadBallWait = deadBallWaitMax;
        foreach (GameObject uiPan in uiObjects)
        {
            uiPan.SetActive(true);
        }
        currentState = controlStates.aiming;

    }
    public enum controlStates
    {
        aiming,
        inPlay,
        getScore,
    }
}
