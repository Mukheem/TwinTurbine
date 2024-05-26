using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windturbine : MonoBehaviour
{
    float angle;
    public float speed;
    private API apiScript;
    private GameObject GUIdataGameObject;
    PhotonView photonView;

    public float startRotationY = 0f;
    public float endRotationY;

    

    // Start is called before the first frame update
    void Start()
    {
        angle = Random.Range(0.0f, 120.0f);    
        speed = Random.Range(75.0f, 86.0f);
        GUIdataGameObject = GameObject.FindGameObjectWithTag("GUIData");
        apiScript = GUIdataGameObject.GetComponent<API>();

        //THis condition is to detach the map with the Wind turbine after Instantiating. This helps the map stick to the ground when the turbine rotates.
        GameObject.FindGameObjectWithTag("map").transform.SetParent(null); ;
        
    }

    // Update is called once per frame
    void Update()
    {
        photonView = PhotonView.Get(this);
        photonView.RPC("RPC_WT_Turn", RpcTarget.All);

        if(apiScript.turn_WT_on_Y_Axis)
        {
            WT_TurnOnIts_Y_Axis();
            apiScript.turn_WT_on_Y_Axis = false;
        }
    }

    // Method to turn the 'Turbine blades' as per the SPEED of wind that is fetched from API
    [PunRPC]
    public void RPC_WT_Turn()
    {
        Debug.Log("WIND SPEED FROM API SCRIPT:" + apiScript.latestWS);
        transform.localEulerAngles = new Vector3(0.0f, 0.0f, angle);
        angle += Time.deltaTime * (apiScript.latestWS * 10); // as the value we are fetching could not turn the blades completely, Multiplying the value we are fetching from API by 10.

    }

    public void WT_TurnOnIts_Y_Axis()
    {
        photonView = PhotonView.Get(this);
        photonView.RPC("RPC_WT_TurnOnIts_Y_Axis", RpcTarget.All);
    }

    [PunRPC]
    public void RPC_WT_TurnOnIts_Y_Axis()
    {
        Debug.Log("Rotate On it's Y-Axis");
        endRotationY = apiScript.latestWD;
        StartCoroutine(RotateObject(startRotationY, endRotationY, 3.5f));
    }

    // Method to turn the 'Turbine' on its Y axis as per the DIRECTION of wind that is fetched from API
    IEnumerator RotateObject(float startAngle, float endAngle, float duration)
    {
        yield return new WaitForSeconds(2f);
        float timeElapsed = 0f;
        Quaternion startRotation = Quaternion.Euler(0, startAngle, 0);
        Quaternion endRotation = Quaternion.Euler(0, endAngle, 0);

        while (timeElapsed < duration)
        {
            transform.parent.gameObject.transform.rotation = Quaternion.Lerp(startRotation, endRotation, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the rotation exactly matches the end rotation at the end
        transform.parent.gameObject.transform.rotation = endRotation;
    }

}
