using System.Collections;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class UnitManager : MonoBehaviourPunCallbacks
{
    [SerializeField] float time = 5.0f;
    [SerializeField] Transform[] warp;

    private void Start()
    {
        if(PhotonNetwork.IsMasterClient) StartCoroutine(CreateUnit());
    }

    IEnumerator CreateUnit()
    {
        WaitForSeconds waitForSecond = new WaitForSeconds(time);

        int random = 0;

        while (true)
        {
            random = Random.Range(0, warp.Length);

            PhotonNetwork.InstantiateRoomObject("Unit", warp[random].position, Quaternion.identity);

            yield return waitForSecond;
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);

        if (PhotonNetwork.IsMasterClient) StartCoroutine(CreateUnit());
    }
}
