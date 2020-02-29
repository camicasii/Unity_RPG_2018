using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamController : MonoBehaviour
{
    private CinemachineVirtualCamera cv;

    private void Start() {
        cv =GetComponent<CinemachineVirtualCamera>();
        Transform player = GameManager.Instance.player.transform;
        //GameObject.FindGameObjectWithTag("Player").transform;
        cv.m_Follow=player;
    }
}
