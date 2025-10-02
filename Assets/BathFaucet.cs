using Unity.VisualScripting;
using UnityEngine;

public class BathFaucet : MonoBehaviour
{
    [SerializeField]
    ParticleSystem waterParticleSystem;

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
            if (!waterOn)
            {
                waterOn = true;
                waterParticleSystem.Play();
            }
            else
            {
                waterOn = false;
                waterParticleSystem.Stop();
            }
            
        }
    }
}
