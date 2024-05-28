using OVRSimpleJSON;
using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using WebSocketSharp;

//https://github.com/GlitchEnzo/NuGetForUnity
// Creating the data structure according to the expected Json
[Serializable]
public class DataPoint
{
    public string name;
    public string levelType;
    public int level;
    public string unit;
    public List<float> values;
}

[Serializable]
public class DataPerHour
{
    public string validTime;
    public List<DataPoint> parameters;
}

[Serializable]
public class ApiResponse
{
    public string approvedTime;
    public string referenceTime;
    public string geometry;
    public List<DataPerHour> timeSeries;
}
  

public class API : MonoBehaviourPunCallbacks, IPunObservable
{
    public TextMeshProUGUI voltageValue;
    public TextMeshProUGUI windDirValue;
    public TextMeshProUGUI temperatureValue;
    public TextMeshProUGUI loc;
    public TextMeshProUGUI windSpeedValue;
    private float LatestT;
    public float latestWD = 0.0f;
    public float latestWS = 0.01f;
    private String windDirectionInDirectionTerms;
    private string unit;
    private GameObject webSocketController;
    private WebSocketController webSocketControllerScript;
    public bool isButtonPressed = false; // Boolean to keep voltage updated as long as the turbine is rotating
    PhotonView photonView;
    private GameObject avatar;
    private AudioController audioControllerScript;
    public bool turn_WT_on_Y_Axis = false;

  

    void Start()
    {

        //TestFromJsonToData();
        //EmergencyButtonClick();
        photonView = PhotonView.Get(this);
        photonView.RPC("RPC_EmergencyButtonClick", RpcTarget.All,false,0.0f);


        avatar = GameObject.FindGameObjectWithTag("Avatar");
        audioControllerScript = avatar.GetComponent<AudioController>();


        // Turning on both the buttons on GUI when something is playing
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
    }

    void Update()
    {
        if (isButtonPressed)
        {
            webSocketController = GameObject.FindGameObjectWithTag("WebController");
            webSocketControllerScript = webSocketController.GetComponent<WebSocketController>();
            if (webSocketControllerScript.ws.ReadyState != WebSocketState.Open)
            {
                webSocketControllerScript.ws.Connect();
            }
            photonView = PhotonView.Get(this);
            photonView.RPC("RPC_VoltageUpdate", RpcTarget.All, webSocketControllerScript.voltageValue.ToString());
           
        }

        if (audioControllerScript.audioSource.isActiveAndEnabled && !audioControllerScript.audioSource.isPlaying)
        {
            // Turning off both the buttons on GUI when something is playing
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(3).gameObject.SetActive(true);
        }
       
    }

    public void OnButtonClick()
    {
        if (!isButtonPressed)
        {
            webSocketController = GameObject.FindGameObjectWithTag("WebController");
            webSocketControllerScript = webSocketController.GetComponent<WebSocketController>();
            webSocketControllerScript.ConnectWithESP32();
            StartCoroutine(GetText());

            
            audioControllerScript.fn_call_AudioNarration2();
            Debug.Log("Button is Clicked");
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
        }
        
    }
    public void emergencyButtonClick()
    {
        photonView = PhotonView.Get(this);
        photonView.RPC("RPC_EmergencyButtonClick", RpcTarget.All, false, 0.0f);
    }
    [PunRPC]
    public void RPC_EmergencyButtonClick(bool isButtonPressedVal, float latestWS_val)
    {
        isButtonPressed = isButtonPressedVal;
        latestWS = latestWS_val;
        
        loc.SetText("----");
        windDirValue.SetText("----");
        temperatureValue.SetText("----");
        voltageValue.SetText("----");
        windSpeedValue.SetText("----");
        
    }
    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://opendata-download-metanalys.smhi.se/api/category/mesan2g/version/1/geotype/point/lon/17.94/lat/59.40/data.json");

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Received data" + www.downloadHandler.text);
            ExtractDataFromJson(www.downloadHandler.text);
           
        }
    }

    public void TestFromJsonToData()
    {
        string testJson = "{\r\n          \"name\": \"t\",\r\n          \"levelType\": \"hl\",\r\n          \"level\": 2,\r\n          \"unit\": \"Cel\",\r\n          \"values\": [\r\n            21.3\r\n          ]\r\n        }";

        DataPoint dataTurbine = JsonUtility.FromJson<DataPoint>(testJson);

        //Debug.Log(dataTurbine.name);
        //Debug.Log(dataTurbine.values[0]);
    }

public void ExtractDataFromJson(string json)
    {
        
        
        ApiResponse response = JsonUtility.FromJson<ApiResponse>(json);
        //Debug.Log("Api response worked!!!!");

        //Access the latest hour
        DataPerHour timeResponse = response.timeSeries[0];
        List<DataPoint> dataPoints = timeResponse.parameters;

        //Debug.Log("Total number of data points: " + dataPoints.Count);

        //Find the value of WD in the latest hour
        for (int i = 0; i < dataPoints.Count; i++)
        {
            DataPoint point = dataPoints[i];
            
            
            if (point.name == "wd")
            {
                latestWD = point.values[0];
                windDirectionInDirectionTerms = GetWindDirection(latestWD);
                //windDirValue.SetText(latestWD.ToString());
                if (webSocketControllerScript.ws.ReadyState != WebSocketState.Open)
                {
                    webSocketControllerScript.ws.Connect();
                }
                webSocketControllerScript.ws.Send(latestWD.ToString()+":take input");
                Debug.Log(latestWD.ToString()+" - Degrees sent to ESP");
            }
            if (point.name == "t")
            {
                LatestT = point.values[0];
                unit = point.unit;
                //temperatureValue.SetText(LatestT.ToString()+ " "+ unit);
            }
            if (point.name == "ws")
            {
                latestWS = point.values[0];
                Debug.Log("Latest WS is - "+latestWS);
            }
        }
        photonView = PhotonView.Get(this);
        photonView.RPC("RPC_GreenButtonClick", RpcTarget.All,windDirectionInDirectionTerms,LatestT+" C","Kista",latestWS+" m/s",true,latestWD,latestWS, true);
    }

    [PunRPC]
    public void RPC_GreenButtonClick(String windDirection,String locationTemperature,String location,String windSpeed,bool turn_WT_on_Y_Axis_val,float latestWD_val, float latestWS_val,bool isButtonPressed_val)
    {
        isButtonPressed = isButtonPressed_val;
        latestWD = latestWD_val; // Just for RPC purposes
        latestWS = latestWS_val; // Just for RPC purposes
        windDirValue.SetText(windDirection);
        temperatureValue.SetText(locationTemperature);
        loc.SetText(location);
        windSpeedValue.SetText(windSpeed);
        turn_WT_on_Y_Axis = turn_WT_on_Y_Axis_val; // flag set to true so that WT can rotate on it's Y axis.
        
    }
    [PunRPC]
    public void RPC_VoltageUpdate(String voltageGenerated)
    {
        //Debug.Log("Voltge generated is - " + voltageGenerated);
        voltageValue.text = voltageGenerated;
    }
    public string GetWindDirection(float degrees)
    {
        // Ensure degrees are within the range 0 to 359
        degrees = (degrees % 360 + 360) % 360;

        string[] directions = { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW" };
        int index = (int)Math.Floor((degrees + 11.25) / 22.5);
        return directions[index];
    }
   

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(turn_WT_on_Y_Axis);
            stream.SendNext(isButtonPressed);
        }
        else
        {
            turn_WT_on_Y_Axis = (bool)stream.ReceiveNext();
            isButtonPressed = (bool)stream.ReceiveNext();
        }
    }
}
