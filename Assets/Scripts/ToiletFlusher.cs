using UnityEngine;

public class ToiletFlusher : MonoBehaviour
{
    ToiletScript toiletScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        toiletScript = GameObject.FindFirstObjectByType<ToiletScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            toiletScript.FlushFlush();
        }
    }
}
