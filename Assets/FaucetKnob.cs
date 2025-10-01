using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class FaucetKnob : MonoBehaviour
{

    Rigidbody2D myBody;
    [SerializeField]
    float spinPower;
    [SerializeField]
    float stoppingAngularVelocity;

    Vector3 defaultPosition;
    Quaternion defaultRotation;
    void Start()
    {
        myBody = gameObject.GetComponent<Rigidbody2D>();
        defaultPosition = gameObject.transform.position;
        defaultRotation = gameObject.transform.rotation;
    }

    void Update()
    {
        //Debug.Log(gameObject.transform. .z);
        if (myBody.angularVelocity < stoppingAngularVelocity)
        {
            gameObject.transform.rotation = defaultRotation;
            gameObject.transform.position = defaultPosition;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if (collision.gameObject.transform.position.y > transform.position.y)
            {
                myBody.AddForce(Vector3.down * spinPower);
            }
            else
            {
                myBody.AddForce(Vector3.down * spinPower);
            }
        }
    }
}
