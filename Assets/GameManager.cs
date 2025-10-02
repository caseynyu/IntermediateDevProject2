using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject ballPrefab;
    [SerializeField]
    Transform ballStartPosition;
    GameObject ballInPlay;
    GameObject ballInToilet = null;
    PinballCamera pinballCamera;
    void Start()
    {
        ballInPlay = GameObject.FindFirstObjectByType<PinballBall>().gameObject;
        pinballCamera = GameObject.FindFirstObjectByType<PinballCamera>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BallInToilet()
    {
        if (ballInToilet == null)
        {
            ballInToilet = ballInPlay;
            ballInPlay = Instantiate(ballPrefab, ballStartPosition.position, ballStartPosition.rotation);
            pinballCamera.ballTransform = ballInPlay.transform;
        }
    }

    public void FlushToilet()
    {
        Destroy(ballInToilet);
        ballInToilet = null;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            //PlayerPrefs.SetInt("Score", score);
            SceneManager.LoadScene("SampleScene");
            //set the ball's position to its original position
            //ballObj.transform.position = ballStartPos;
        }
    }
}
