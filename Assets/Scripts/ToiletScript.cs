using UnityEngine;
using System.Collections;

public class ToiletScript : MonoBehaviour
{
    GameObject ballInToilet;

    GameObject toiletball;
    [SerializeField]
    Transform ballPoint;
    GameManager gameManager;
    [SerializeField]

    float rotationAmount;
    float flushTimerCount;
    [SerializeField]
    float flushTimerMax;

    bool plunged = false;
    [SerializeField]
    AudioClip toiletFlushAudio;
    bool full = false;

    bool flushing = false;
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
            GameObject.FindFirstObjectByType<GameManager>().AddScore(500);
            full = true;
            ballInToilet = collision.transform.gameObject;
            ballInToilet.transform.parent = gameObject.transform.parent;
            ballInToilet.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            ballInToilet.GetComponent<PinballBall>().enabled = false;
            ballInToilet.GetComponent<CircleCollider2D>().enabled = false;
            ballInToilet.transform.position = ballPoint.position;
            gameManager.BallInToilet();
            
        }
        if (collision.gameObject.CompareTag("Ball") && plunged)
        {
            //StartCoroutine(Flush());
            //flushing = true;
            //gameManager.FlushToilet();
        }
    }
    public void PlungeToilet()
    {
        Debug.Log("testeest");
        plunged = true;
    }

    public void FlushFlush()
    {
        
        if (full && plunged && !flushing)
        {
            StartCoroutine(Flush());
            flushing = true;
            gameManager.FlushToilet();
        }
    }

    public IEnumerator Flush()
    {
        flushing = true;
        GetComponent<AudioSource>().PlayOneShot(toiletFlushAudio);
        float elapsedTime = 0f;
        //StartCoroutine(Shake(flushTimerMax, .2f));
        while (elapsedTime < flushTimerMax)
        {

            ballInToilet.transform.Rotate(0f, 0, rotationAmount);
            elapsedTime += Time.deltaTime;

            yield return null;

        }
        gameManager.FlushToilet();
        plunged = false;
        full = false;
        flushing = false;
        Destroy(ballInToilet);
        Debug.Log("2");
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
