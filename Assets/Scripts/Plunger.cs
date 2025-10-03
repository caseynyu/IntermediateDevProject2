using UnityEngine;

public class Plunger : MonoBehaviour
{
    ToiletScript toilet;

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
            gameObject.GetComponent<Animator>().SetTrigger("Plunging");
        }
    }

    public void Plunging() {
        toilet.PlungeToilet();
    }
}
