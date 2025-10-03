using UnityEngine;
using System.Collections;

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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") && !full)
        {
            full = true;
            ballInToilet = collision.transform.gameObject;
            ballInToilet.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            ballInToilet.GetComponent<PinballBall>().enabled = false;
            ballInToilet.GetComponent<CircleCollider2D>().enabled = false;
            ballInToilet.transform.position = ballPoint.position;
            gameManager.BallInToilet();
        }
        if (collision.gameObject.CompareTag("Ball") && plunged)
        {
            gameManager.FlushToilet();
        }
    }
    public void PlungeToilet()
    {
        StartCoroutine(Shake(.25f, .2f));
        plunged = true;
    }
    
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = new Vector3(0, 0, 0);
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float xOffset = Random.Range(-0.5f, 0.5f) * magnitude;
            float yOffset = Random.Range(-0.5f, 0.5f) * magnitude;
            transform.localPosition = new Vector3(xOffset, yOffset, originalPos.z);
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        transform.localPosition = originalPos;
    }
}
