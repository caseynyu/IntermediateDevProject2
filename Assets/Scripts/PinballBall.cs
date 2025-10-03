//using System.Numerics;
//using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UIElements;

public class PinballBall : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D myBody;
    [SerializeField]
    float gravityWellForce;

    [SerializeField]
    float launchSpeed;

    [SerializeField]
    float fallMultiplier = 2.5f;

    PinballCamera pinballCamera;
    [SerializeField]
    AudioClip normalPing;
    [SerializeField]
    AudioClip bigPing;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pinballCamera = FindFirstObjectByType<PinballCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myBody.linearVelocityY < 0)
        {
            myBody.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1f) * Time.deltaTime;
        }

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
            case "Bounce":
                StartCoroutine(pinballCamera.Shake(0.2f, .2f));
                GetComponent<AudioSource>().PlayOneShot(normalPing);
                break;
            case "Big Bounce":
                StartCoroutine(pinballCamera.Shake(0.3f, .3f));
                GameObject.FindFirstObjectByType<GameManager>().AddScore(100);
                GetComponent<AudioSource>().PlayOneShot(bigPing);
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Gravity Well":
                GravityWellScript gravityWell = collision.GetComponent<GravityWellScript>();
                Vector3 vectoer = gravityWell.gravityWellPoint.position - transform.position;
                myBody.AddForce(vectoer * gravityWell.gravityWellValue, ForceMode2D.Impulse);
                break;
            case "Knob":
                StartCoroutine(pinballCamera.Shake(0.3f, .3f));
                break;
        }
        

    }
    void OnTriggerExit2D(Collider2D col)
    {
        //Debug.Log("test");
        if (col.gameObject.tag == "Launcher")
        {
            myBody.AddForce(Vector3.up * launchSpeed, ForceMode2D.Impulse);
        }
    }
}
