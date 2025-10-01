using UnityEngine;
using System.Collections;

public class PinballCamera : MonoBehaviour
{
    [SerializeField]
    Transform ballTransform;
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
