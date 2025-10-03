using Unity.VisualScripting;
using UnityEngine;

public class BathFaucet : MonoBehaviour
{
    [SerializeField]
    ParticleSystem waterParticleSystem;

    [SerializeField]
    

    bool waterOn = false;

    void Start()
    {
        waterParticleSystem.Stop();
    }


    void Update()
    {

    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            GameObject.FindFirstObjectByType<GameManager>().AddScore(200);
            if (!waterOn)
            {
                GetComponent<AudioSource>().Play();
                waterOn = true;
                waterParticleSystem.Play();
            }
            else
            {
                GetComponent<AudioSource>().Pause();
                waterOn = false;
                waterParticleSystem.Stop();
            }
            
        }
    }
}
