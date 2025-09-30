using UnityEngine;

public class PinballFlipper : MonoBehaviour
{
    [SerializeField]
    KeyCode flipKey;
    [SerializeField]
    Rigidbody2D myBody;
    
    HingeJoint2D myHingeJoint;
    JointMotor2D myJointMotor;

    [SerializeField]
    float flipPowerForward;
    [SerializeField]
    float flipPowerBack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myHingeJoint = gameObject.GetComponent<HingeJoint2D>();
        myJointMotor = myHingeJoint.motor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(flipKey))
        {
            myJointMotor.motorSpeed = -flipPowerForward;
            myHingeJoint.motor = myJointMotor;
        }
        if (!Input.GetKey(flipKey)){
            myJointMotor.motorSpeed = flipPowerBack;
            myHingeJoint.motor = myJointMotor;
        }
    }
}
