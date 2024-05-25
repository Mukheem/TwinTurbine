using UnityEngine;
using System.Collections;

public class TurbineController : MonoBehaviour
{
    public float startRotationY = 0f;
    public float endRotationY = 90f;

    private void Start()
    {
        // Start the rotation when the game starts
        StartCoroutine(RotateObject(startRotationY, endRotationY, 1f));
    }

    IEnumerator RotateObject(float startAngle, float endAngle, float duration)
    {
        float timeElapsed = 0f;
        Quaternion startRotation = Quaternion.Euler(0, startAngle, 0);
        Quaternion endRotation = Quaternion.Euler(0, endAngle, 0);

        while (timeElapsed < duration)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the rotation exactly matches the end rotation at the end
        transform.rotation = endRotation;
    }
}
