using UnityEngine;

public class ToiletScript : MonoBehaviour
{
    GameObject ballInToilet;

    GameObject toiletball;
    [SerializeField]
    Transform ballPoint;
    GameManager gameManager;

    bool plunged = false;
    bool full = false;
    void Start()
    {
        gameManager = GameObject.FindFirstObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball") && !full)
        {
            full = true;
            ballInToilet = collision.transform.gameObject;
            ballInToilet.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            ballInToilet.GetComponent<PinballBall>().enabled = false;
            ballInToilet.GetComponent<CircleCollider2D>().enabled = false;
            ballInToilet.transform.position = ballPoint.position;
            gameManager.BallInToilet();
        }
        if (collision.CompareTag("Ball") && plunged) {
            gameManager.FlushToilet();            
        }
    }
}
