using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        Create();
    }

    public void Create()
    {
        PhotonNetwork.Instantiate("Character", RandomPosition(5), Quaternion.identity);
    }

    public Vector3 RandomPosition(int value)
    {
        Vector3 direction = Random.insideUnitSphere.normalized;

        direction *= value;

        direction.y = 1;

        return direction;
    }
}
