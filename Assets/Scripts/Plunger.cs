using UnityEngine;

public class Plunger : MonoBehaviour
{
    ToiletScript toilet;


    AudioClip plungeAudio;
    void Start()
    {
        toilet = GameObject.FindFirstObjectByType<ToiletScript>();
    }


    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") && !gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Plunging"))
        {
            GameObject.FindFirstObjectByType<GameManager>().AddScore(400);
            gameObject.GetComponent<Animator>().SetTrigger("Plunging");
            GetComponent<AudioSource>().PlayOneShot(plungeAudio);
        }
    }

    public void Plunging() {
        toilet.PlungeToilet();
    }
}
