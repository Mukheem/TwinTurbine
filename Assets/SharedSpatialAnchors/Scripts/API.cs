using OVRSimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
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
  

public class API : MonoBehaviour
{
    public TextMeshProUGUI voltageValue;
    public TextMeshProUGUI windDirValue;
    public TextMeshProUGUI temperatureValue;
    public TextMeshProUGUI loc;
    private float LatestT;
    private float latestWD;
    private string unit;
    private GameObject webSocketController;
    private WebSocketController webSocketControllerScript;
    private bool isButtonPressed = false; // Boolean to keep voltage updated as long as the turbine is rotating

    void Start()
    {
       
        //TestFromJsonToData();
        EmergencyButtonClick();
    }

    private void Update()
    {
        if (isButtonPressed)
        {
            voltageValue.text = webSocketControllerScript.voltageValue.ToString();
        }
    }

    public void OnButtonClick()
    {
        webSocketController = GameObject.FindGameObjectWithTag("WebController");
        webSocketControllerScript = webSocketController.GetComponent<WebSocketController>();
        StartCoroutine(GetText());
    }
    public void EmergencyButtonClick()
    {
        isButtonPressed = false;
        loc.SetText("----");
        windDirValue.SetText("----");
        temperatureValue.SetText("----");
        voltageValue.SetText("----");
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
        isButtonPressed = true; // Boolean to keep voltage updated as long as the turbine is rotating

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
            
            loc.SetText("Kista");
            if (point.name == "wd")
            {
                latestWD = point.values[0];
                windDirValue.SetText(latestWD.ToString());
                webSocketControllerScript.ws.Send(latestWD.ToString()+":take input");
            }
            if (point.name == "t")
            {
                LatestT = point.values[0];
                unit = point.unit;
                temperatureValue.SetText(LatestT.ToString()+ " "+ unit);
            }
        }
    }
}
