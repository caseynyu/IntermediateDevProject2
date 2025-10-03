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
    [SerializeField]
    Sprite noToothpasteSprite;
    [SerializeField]
    Sprite ToothpasteSprite;

    [SerializeField]
    float toothpasteLaunchSpeed;

    bool toothpasteOn = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = noToothpasteSprite;
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
        if (!Input.GetKey(flipKey))
        {
            myJointMotor.motorSpeed = flipPowerBack;
            myHingeJoint.motor = myJointMotor;
        }
    }

    public void ToothpasteFall()
    {
        GetComponent<SpriteRenderer>().sprite = ToothpasteSprite;
        toothpasteOn = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") && toothpasteOn)
        {
            toothpasteOn = false;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * toothpasteLaunchSpeed, ForceMode2D.Impulse);
            GetComponent<SpriteRenderer>().sprite = noToothpasteSprite;
            GameObject.FindFirstObjectByType<GameManager>().AddScore(300);
        }
    }

}
