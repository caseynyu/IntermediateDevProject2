using UnityEngine;

public class ToothpasteTube : MonoBehaviour
{
    ToothpasteGlob toothpasteGlob;
    void Start()
    {
        toothpasteGlob = GameObject.FindFirstObjectByType<ToothpasteGlob>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") && !toothpasteGlob.falling)
        {
            GameObject.FindFirstObjectByType<GameManager>().AddScore(300);
            toothpasteGlob.ToothpasteFallStart();
        }
    }
}
