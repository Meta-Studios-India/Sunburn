using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSetup : MonoBehaviour
{
    public List<MonoBehaviour> playerComponents = new List<MonoBehaviour>();
    public GameObject cameraPrefab;
    public GameObject canvasObject;
    [SerializeField]
    bool _masterPlayer;
    PhotonView photonView;

    public void Start() {
        photonView = GetComponentInParent<PhotonView>();
        foreach (MonoBehaviour script in playerComponents) {
            script.enabled = photonView.IsMine;
            cameraPrefab.SetActive(photonView.IsMine);
            canvasObject.SetActive(photonView.IsMine);
        }
    }

    public void SetupPlayer(bool masterPlayer) {
        _masterPlayer = masterPlayer;
    }
}