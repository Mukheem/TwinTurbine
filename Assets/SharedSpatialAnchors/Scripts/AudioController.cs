using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioNarration_1;
    public AudioClip audioNarration_2;
    PhotonView photonView;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        
    }

    // Audio Narration 1
    public void fn_call_AudioNarration1()
    {
        photonView = PhotonView.Get(this);
        photonView.RPC("RPC_startAudioNarration1", RpcTarget.All);
    }

    [PunRPC]
    public void RPC_startAudioNarration1()
    {
        StartCoroutine(CoRoutine_startAudioNarration1());
    }
    IEnumerator CoRoutine_startAudioNarration1()
    {
        yield return new WaitForSeconds(1.0f);
        audioSource.PlayOneShot(audioNarration_1);
    }

    // Audio Narration 2
    public void fn_call_AudioNarration2()
    {
        photonView = PhotonView.Get(this);
        photonView.RPC("RPC_startAudioNarration2", RpcTarget.All);
    }

    [PunRPC]
    public void RPC_startAudioNarration2()
    {
        StartCoroutine(CoRoutine_startAudioNarration2());
    }
    IEnumerator CoRoutine_startAudioNarration2()
    {
        yield return new WaitForSeconds(0.0f);
        audioSource.PlayOneShot(audioNarration_2);
        yield return new WaitForSeconds(audioNarration_2.length+2.0f);
        audioSource.gameObject.SetActive(false);
    }

   

    
}
