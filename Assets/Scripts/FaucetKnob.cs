using Unity.Mathematics;
using UnityEngine;

public class FaucetKnob : MonoBehaviour
{

    [SerializeField]
    AudioClip sound;
    Rigidbody2D myBody;
    [SerializeField]
    float spinPower;
    [SerializeField]
    float stoppingAngularVelocity;

    Vector3 defaultPosition;
    Quaternion defaultRotation;
    [SerializeField]
    string rotatingDirection = "none";
    void Start()
    {
        myBody = gameObject.GetComponent<Rigidbody2D>();
        defaultPosition = gameObject.transform.position;
        defaultRotation = gameObject.transform.rotation;
    }

    void Update()
    {
        //Debug.Log(myBody.angularVelocity);
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            myBody.AddForce(Vector2.up * spinPower);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            myBody.AddForce(Vector2.down * spinPower);
        }*/
        if (myBody.angularVelocity >0) {
            rotatingDirection = "Up";
        }
        if (myBody.angularVelocity <0) {
            rotatingDirection = "Down";
        }
        //Debug.Log(gameObject.transform. .z);
        if (rotatingDirection == "Up")
        {
            if (myBody.angularVelocity < stoppingAngularVelocity)
            {

                rotatingDirection = "None";
                gameObject.transform.rotation = defaultRotation;
                gameObject.transform.position = defaultPosition;
                myBody.angularVelocity = 0;
            }
        }
        if (rotatingDirection == "Down") {
            if (myBody.angularVelocity > -stoppingAngularVelocity)
            {
                rotatingDirection = "None";
                gameObject.transform.rotation = defaultRotation;
                gameObject.transform.position = defaultPosition;
                myBody.angularVelocity = 0;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            GetComponent<AudioSource>().PlayOneShot(sound);
            GameObject.FindFirstObjectByType<GameManager>().AddScore(400);
            if (collision.gameObject.transform.position.y > transform.position.y)
            {
                gameObject.transform.rotation = defaultRotation;
                gameObject.transform.position = defaultPosition;
                myBody.angularVelocity = 0;
                myBody.AddForce(Vector3.up * spinPower);
            }
            else
            {
                rotatingDirection = "None";
                gameObject.transform.rotation = defaultRotation;
                gameObject.transform.position = defaultPosition;
                myBody.angularVelocity = 0;
                myBody.AddForce(Vector3.up * spinPower);
            }
        }
    }
}
