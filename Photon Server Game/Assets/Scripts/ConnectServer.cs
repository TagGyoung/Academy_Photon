using Photon.Pun;
using UnityEngine;
using Photon.Realtime;
using TMPro;

public class ConnectServer : MonoBehaviourPunCallbacks
{
    [SerializeField] Canvas canvasRoom;
    [SerializeField] Canvas canvasLooby;
    [SerializeField] TMP_Dropdown server;

    private void Awake()
    {
        server.options[0].text = "Asia";
        server.options[1].text = "Europe";
        server.options[2].text = "America";

        if (PhotonNetwork.IsConnected)
        {
            canvasLooby.gameObject.SetActive(false);
        }

        PhotonNetwork.NickName = PlayerPrefs.GetString("NickName");

        if (PhotonNetwork.NickName == "")
        {
            Instantiate(Resources.Load<GameObject>("Nick Name Popup"));
        }
    }

    public void SelectServer()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnJoinedLobby()
    {
        canvasRoom.sortingOrder = 1;
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby
        (
            new TypedLobby(server.options[server.value].text, LobbyType.Default)
        );
    }
}
