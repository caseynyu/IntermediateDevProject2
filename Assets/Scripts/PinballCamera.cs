using UnityEngine;
using System.Collections;
//using System.Numerics;

public class PinballCamera : MonoBehaviour
{
    [SerializeField]
    public Transform ballTransform;
    [SerializeField]
    float smoothVal;

    Vector3 velocity = Vector3.zero;
    Vector3 startPos;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = ballTransform.position;
        target.z = -10;
        gameObject.transform.parent.transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothVal);
        if (gameObject.transform.parent.position.x < 1.31f)
        {
            gameObject.transform.parent.position = new Vector3(1.31f, gameObject.transform.parent.position.y, gameObject.transform.parent.position.z);

        }
        if (gameObject.transform.parent.position.x > 4.98)
        {
            gameObject.transform.parent.position = new Vector3(4.98f, gameObject.transform.parent.position.y, gameObject.transform.parent.position.z);

        }
        if (gameObject.transform.parent.position.y > 13.52f)
        {
            gameObject.transform.parent.position = new Vector3(gameObject.transform.parent.position.x, 13.52f, gameObject.transform.parent.position.z);

        }
        if (gameObject.transform.parent.position.y < -16.38)
        {
            gameObject.transform.parent.position = new Vector3(gameObject.transform.parent.position.x, -16.38f, gameObject.transform.parent.position.z);
            
        }
        /*if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(Shake(.5f, .2f));
        }*/
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
