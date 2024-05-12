using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windturbine : MonoBehaviour
{
    float angle;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        angle = Random.Range(0.0f, 120.0f);    
        speed = Random.Range(75.0f, 86.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0.0f, 0.0f, angle);
        angle += Time.deltaTime * speed;
    }
}
