using UnityEngine;

public class ToothpasteGlob : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField]
    GameObject flipper;
    public bool falling = false;
    Animator animator;
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToothpasteFallStart()
    {
        spriteRenderer.enabled = true;
        falling = true;
        gameObject.GetComponent<Animator>().SetTrigger("ToothpasteFall");
    }
    public void ToothpasteFallEnd()
    {
        falling = false;
        spriteRenderer.enabled = false;
        flipper.GetComponent<PinballFlipper>().ToothpasteFall();
    }
    

}
