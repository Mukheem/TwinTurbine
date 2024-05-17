/*
 * Copyright (c) Meta Platforms, Inc. and affiliates.
 * All rights reserved.
 *
 * Licensed under the Oculus SDK License Agreement (the "License");
 * you may not use the Oculus SDK except in compliance with the License,
 * which is provided at the time of installation or download, or which
 * otherwise accompanies this software in either electronic or hard copy form.
 *
 * You may obtain a copy of the License at
 *
 * https://developer.oculus.com/licenses/oculussdk/
 *
 * Unless required by applicable law or agreed to in writing, the Oculus SDK
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using PhotonPun = Photon.Pun;
using PhotonRealtime = Photon.Realtime;
using System.Linq;
using System;
using System.Threading.Tasks;

public class SharedAnchorControlPanel : MonoBehaviour
{

    [SerializeField]
    private Transform referencePoint;

    [SerializeField]
    private GameObject cubePrefab;
    [SerializeField]
    private GameObject roomLayoutPanelRowPrefab;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    protected GameObject menuPanel;

    [SerializeField]
    protected GameObject lobbyPanel;

    [SerializeField]
    private GameObject roomLayoutPanel;
    [SerializeField]
    private Button createRoomButton;

    [SerializeField]
    private Button joinRoomButton;

    [SerializeField]
    private Image anchorIcon;

    [SerializeField]
    private TextMeshProUGUI pageText;

    [SerializeField]
    private TextMeshProUGUI statusText;

    [SerializeField]
    private GameObject TwinTurbine_windTurbine;

    [SerializeField]
    private GameObject TwinTurbine_menuItem;
    public TextMeshProUGUI StatusText
    {
        get { return statusText; }
    }

    [SerializeField]
    private TextMeshProUGUI renderStyleText;

    [SerializeField]
    private TextMeshProUGUI roomText;

    List<GameObject> lobbyRowList = new List<GameObject>();

    public TextMeshProUGUI RoomText
    {
        get { return roomText; }
    }

    [SerializeField]
    private TextMeshProUGUI userText;

    public TextMeshProUGUI UserText
    {
        get { return userText; }
    }

    private bool _isCreateMode;

    private void Start()
    {
        transform.parent = referencePoint;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        if (renderStyleText != null)
        {
            renderStyleText.text = "Render: " + CoLocatedPassthroughManager.Instance.visualization.ToString();
        }
        ToggleRoomButtons(false);
    }

    public async Task roomDetails()
    {
        var anchors = new List<OVRAnchor>();
        await OVRAnchor.FetchAnchorsAsync<OVRRoomLayout>(anchors);

        // no rooms - call Space Setup or check Scene permission
        if (anchors.Count == 0)
            return;

        SampleController.Instance.Log("Anchors Fetched.");
        SampleController.Instance.Log(anchors.Count.ToString());
        SampleController.Instance.Log(anchors[0].ToString());
        // access anchor data by retrieving the components
        var room = anchors.First();

        // access the ceiling, floor and walls with the OVRRoomLayout component
        var roomLayout = room.GetComponent<OVRRoomLayout>();
        if (roomLayout.TryGetRoomLayout(out Guid ceiling, out Guid floor, out Guid[] walls))
        {
            // use these guids to fetch the OVRAnchor object directly
            await OVRAnchor.FetchAnchorsAsync(walls, anchors);
        }

        // access the list of children with the OVRAnchorContainer component
        if (!room.TryGetComponent(out OVRAnchorContainer container))
        {
            SampleController.Instance.Log("No ROOM data FOUND.");
            return;
        }
           

        // use the component helper function to access all child anchors
        await container.FetchChildrenAsync(anchors);

        SampleController.Instance.Log("Child Anchors Fetched.");
        SampleController.Instance.Log(anchors.Count.ToString());
        SampleController.Instance.Log(anchors[0].ToString());

        int i = 0;
        // Log the children anchors and their positions
        foreach (var anchor in anchors)
        {
           
            // check that this anchor is the Table
            if (anchor.TryGetComponent(out OVRSemanticLabels labels) &&
                (labels.Labels.Contains(OVRSceneManager.Classification.Plant)) || labels.Labels.Contains(OVRSceneManager.Classification.Table)) 
            {

                // If it's the Table!
                // enable locatable/tracking
                if (!anchor.TryGetComponent(out OVRLocatable locatable))
                    continue;
                await locatable.SetEnabledAsync(true);

                // localize the anchor
                locatable.TryGetSceneAnchorPose(out OVRLocatable.TrackingSpacePose pose);
                Vector3? worldPosition = pose.ComputeWorldPosition(Camera.main);
                Quaternion? worldRotation = pose.ComputeWorldRotation(Camera.main);

                if (worldPosition != null && worldRotation != null)
                {
                    SampleController.Instance.Log("POSITION" + pose.Position.ToString());
                    SampleController.Instance.Log("WORLDPOSITION" + worldPosition.ToString());

                    
                    if (labels.Labels.Contains(OVRSceneManager.Classification.Table))
                    {
                         var networkedCube = PhotonPun.PhotonNetwork.Instantiate(TwinTurbine_windTurbine.name, new Vector3(((Vector3)worldPosition).x,-0.5f, ((Vector3)worldPosition).z), Quaternion.identity);
                        var photonGrabbable = networkedCube.GetComponent<PhotonGrabbableObject>();
                        i = i++;
                    }

                    if (labels.Labels.Contains(OVRSceneManager.Classification.Plant))
                    {
                        var networkedCube = PhotonPun.PhotonNetwork.Instantiate(TwinTurbine_menuItem.name, new Vector3(((Vector3)worldPosition).x, 1.3f, ((Vector3)worldPosition).z), Quaternion.identity);
                        var photonGrabbable = networkedCube.GetComponent<PhotonGrabbableObject>();
                        i = i++;
                    }


                }
                if (i == 2)
                    break;
            }
            continue;

        }
    }

    public void OnCreateModeButtonPressed()
    {
        SampleController.Instance.Log("OnCreateModeButtonPressed");

        if (!_isCreateMode)
        {
            SampleController.Instance.StartPlacementMode();
            anchorIcon.color = Color.green;
            _isCreateMode = true;
        }
        else
        {
            SampleController.Instance.EndPlacementMode();
            anchorIcon.color = Color.white;
            _isCreateMode = false;
        }
    }

    public void OnLoadLocalAnchorsButtonPressed()
    {
        if (SampleController.Instance.cachedAnchorSample)
        {
            SharedAnchorLoader.Instance.LoadLastUsedCachedAnchor();
        }
        else
        {
            SharedAnchorLoader.Instance.LoadLocalAnchors();
        }
    }

    public void OnLoadSharedAnchorsButtonPressed()
    {
        SharedAnchorLoader.Instance.LoadSharedAnchors();
    }

    public void OnSpawnCubeButtonPressed()
    {
        SampleController.Instance.Log("OnSpawnCubeButtonPressed");

        SpawnCube();
    }

    public void LogNext()
    {
        if (SampleController.Instance.logText.pageToDisplay >= SampleController.Instance.logText.textInfo.pageCount)
        {
            return;
        }

        SampleController.Instance.logText.pageToDisplay++;
        if(pageText)
            pageText.text = SampleController.Instance.logText.pageToDisplay + "/" + SampleController.Instance.logText.textInfo.pageCount;
    }

    public void LogPrev()
    {
        if (SampleController.Instance.logText.pageToDisplay <= 1)
        {
            return;
        }

        SampleController.Instance.logText.pageToDisplay--;
        if(pageText)
            pageText.text = SampleController.Instance.logText.pageToDisplay + "/" + SampleController.Instance.logText.textInfo.pageCount;
    }

    private void SpawnCube()
    {
        var networkedCube = PhotonPun.PhotonNetwork.Instantiate(cubePrefab.name, spawnPoint.position, spawnPoint.rotation);
        var photonGrabbable = networkedCube.GetComponent<PhotonGrabbableObject>();
        photonGrabbable.TransferOwnershipToLocalPlayer();

        // Read room details
        Task.Run(roomDetails);
    }


    public void ChangeUserPassthroughVisualization()
    {
        CoLocatedPassthroughManager.Instance.NextVisualization();
        if (renderStyleText)
        {
            renderStyleText.text = "Render: " + CoLocatedPassthroughManager.Instance.visualization.ToString();
        }
    }

    public void DisplayMenuPanel()
    {
        menuPanel.SetActive(true);
        lobbyPanel.SetActive(false);
    }

    public void DisplayLobbyPanel()
    {
        lobbyPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void ToggleRoomLayoutPanel(bool active)
    {
        roomLayoutPanel.SetActive(active);
    }

    public void ToggleRoomButtons(bool active)
    {
        if (createRoomButton)
            createRoomButton.interactable = active;

        if (joinRoomButton)
            joinRoomButton.interactable = active;
    }

    public void SetRoomList(List<PhotonRealtime.RoomInfo> roomList)
    {
        foreach (Transform roomTransform in roomLayoutPanel.transform)
        {
            if (roomTransform.gameObject != roomLayoutPanelRowPrefab)
                GameObject.Destroy(roomTransform.gameObject);
        }
        lobbyRowList.Clear();

        if (roomList.Count > 0)
        {
            for (int i = 0; i < roomList.Count; i++)
            {
                if (roomList[i].PlayerCount == 0)
                    continue;

                GameObject newLobbyRow = GameObject.Instantiate(roomLayoutPanelRowPrefab, roomLayoutPanel.transform);
                newLobbyRow.SetActive(true);
                newLobbyRow.GetComponentInChildren<TextMeshProUGUI>().text = roomList[i].Name;
                lobbyRowList.Add(newLobbyRow);
            }
        }
    }

    public void OnReturnToMenuButtonPressed()
    {
        if (PhotonPun.PhotonNetwork.IsConnected)
        {
            PhotonPun.PhotonNetwork.Disconnect();
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void OnSpawnTwinTurbineSceneButtonPressed()
    {
        SampleController.Instance.Log("OnSpawnTwinTurbineSceneButtonPressed");

        SpawnTwinTurbineScene();
    }
    private void SpawnTwinTurbineScene()
    {
        SampleController.Instance.Log("Trying to Spawn WT Object");
        SampleController.Instance.Log(spawnPoint.position.ToString());
        Debug.Log(spawnPoint.position);
        var networkedWindTurbine = PhotonPun.PhotonNetwork.Instantiate(TwinTurbine_windTurbine.name, new Vector3(Camera.main.transform.position.x,0, Camera.main.transform.position.z-2), Quaternion.identity);
        var photonGrabbable = networkedWindTurbine.GetComponent<PhotonGrabbableObject>();
        photonGrabbable.TransferOwnershipToLocalPlayer();
    }
}
