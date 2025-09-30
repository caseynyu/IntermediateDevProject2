//using System.Numerics;
//using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class PinballBall : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D myBody;
    [SerializeField]
    float gravityWellForce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            myBody.bodyType = RigidbodyType2D.Dynamic;
            //myBody.linearVelocity = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5));
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Bumper":
                myBody.AddForce(transform.up * 500);
                break;
            case "Flipper":
                myBody.AddForce(transform.up * 0);
                break;
            case "Button":
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gravity Well")
        {
            Vector3 vectoer = collision.GetComponent<GravityWellScript>().gravityWellPoint.position - transform.position;
            myBody.AddForce(vectoer * gravityWellForce,ForceMode2D.Impulse);
            //transform.position
            //myBody.AddRelativeForce(collision.GetComponent<GravityWellScript>().gravityWellPoint.position * gravityWellForce);
            //myBody.AddForce
        }
    }
}
