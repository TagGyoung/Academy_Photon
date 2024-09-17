using UnityEngine;
using Photon.Pun;
using TMPro;

public class Information : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI textMeshProUGUI;
    private string roomName;

    public void ConnectRoom()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.JoinRoom(roomName);
        }
    }

    public void SetData(string name, int currentStaff, int maxStaff)
    {
        textMeshProUGUI.fontSize = 50;
        textMeshProUGUI.color = Color.black;
        textMeshProUGUI.alignment = TextAlignmentOptions.Center;
        roomName = name;
        textMeshProUGUI.text = name + " ( " + currentStaff + " / " + maxStaff + ")";
    }
}
