using UnityEngine;

public class PinballLaunch : MonoBehaviour
{
    SpringJoint2D mySpring;
    Rigidbody2D myBody;

    [SerializeField]
    float minDist;

    [SerializeField]
    public float launchPower;

    [SerializeField]
    PinballBall ballScript;

    [SerializeField]
    float distanceEachFrame;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mySpring = GetComponent<SpringJoint2D>();
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (mySpring.distance > minDist)
            {
                mySpring.distance -= distanceEachFrame;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            myBody.AddForce(transform.up * launchPower);
            mySpring.distance = 2.5f;
        }
    }
}
