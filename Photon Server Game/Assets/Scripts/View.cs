using UnityEngine;
using TMPro;
using Photon.Pun;

public class View : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_Text nickName;

    private void Start()
    {
        nickName.text = photonView.Owner.NickName;
    }

    private void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
