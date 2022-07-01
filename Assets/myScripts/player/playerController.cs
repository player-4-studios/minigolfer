using UnityEngine;
using UnityEngine.UI;
public class playerController : MonoBehaviour
{
    //Physics
    private Rigidbody rb;

    //Power and Aiming
    [SerializeField] Slider powerSlider;
    [SerializeField] float powerValMultiplier;
    [SerializeField] GameObject aimObject;
    [SerializeField] float aimSpeed;
    [SerializeField] bool startedSwing;

    //State
    [SerializeField] controlStates currentState;

    //UI
    [SerializeField] GameObject[] uiObjects;
    [SerializeField] VariableJoystick aimStick;
    [SerializeField] VariableJoystick powerStick;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 1000f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(powerStick.Vertical);
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
                        if(startedSwing == true && powerStick.Vertical == 0)
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
