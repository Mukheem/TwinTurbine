using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windturbine : MonoBehaviour
{
    float angle;
    public float speed;
    private API apiScript;
    private GameObject GUIdataGameObject;
    // Start is called before the first frame update
    void Start()
    {
        angle = Random.Range(0.0f, 120.0f);    
        speed = Random.Range(75.0f, 86.0f);
        GUIdataGameObject = GameObject.FindGameObjectWithTag("GUIData");
        apiScript = GUIdataGameObject.GetComponent<API>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("WIND SPEED FROM API SCRIPT:" + apiScript.latestWS);
        transform.localEulerAngles = new Vector3(0.0f, 0.0f, angle);
        angle += Time.deltaTime * (apiScript.latestWS*10);
    }
}
