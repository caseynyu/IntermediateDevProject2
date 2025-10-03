using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreText;
    int score = 0;
    [SerializeField]
    GameObject ballPrefab;
    [SerializeField]
    Transform ballStartPosition;
    GameObject ballInPlay;
    GameObject ballInToilet = null;
    PinballCamera pinballCamera;

    [SerializeField]
    AudioClip coinNoise;
    float flushTimerCount;
    float flushTimerMax;
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
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
            AddScore(1000);
        }
    }

    public void FlushToilet()
    {
        //
        ballInToilet = null;
        AddScore(10000);
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

    public void AddScore(int scoreToAdd)
    {
        GetComponent<AudioSource>().PlayOneShot(coinNoise);
        score += scoreToAdd;
        scoreText.text = "Score: " + score.ToString();

    }
}
