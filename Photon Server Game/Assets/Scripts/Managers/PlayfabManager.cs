using PlayFab;
using PlayFab.ClientModels;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class PlayfabManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField email;
    [SerializeField] InputField password;

    public void Success(LoginResult loginResult)
    {
        PhotonNetwork.AutomaticallySyncScene = false;
        // ������ Ŭ���̾�Ʈ�� ���� ���� Ŭ���̾�Ʈ�� ���� �̵� ( true / false )

        PhotonNetwork.GameVersion = "1.0f";

        PhotonNetwork.LoadLevel("Photon Lobby");
        // SceneManager.LoadScene() �Լ��� �̵��� ��
        // PhotonNetwork.AutomaticallySyncScene�� �������
        // �ش� �Լ��� ȣ���� Ŭ���̾�Ʈ�� ���� �ε��ϱ� ������
        // PhotonNetwork.LoadLevel() �Լ��� �̿��Ͽ� ���� �ε��մϴ�.
    }

    public void Success(RegisterPlayFabUserResult result)
    {
        Alarm.Show(result.ToString(), AlarmType.Alarm);
    }

    public void SignUp()
    {
        // RegisterPlayFabUserRequest : ������ ������ ����ϱ� ���� Ŭ�����Դϴ�.
        RegisterPlayFabUserRequest request = new RegisterPlayFabUserRequest
        {
            Email = email.text,
            Password = password.text,
            RequireBothUsernameAndEmail = false
            // RequireBothUsernameAndEmail
            // : ����� �̸��� �̸����� ��� �ʿ�� �ϴ��� ������ �� �ִ� Property�Դϴ�.
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, Success, Failure);
    }

    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = email.text,
            Password = password.text
        };

        PlayFabClientAPI.LoginWithEmailAddress(request, Success, Failure);
    }
    
    public void Failure(PlayFabError playFabError)
    {
        Alarm.Show(playFabError.GenerateErrorReport(), AlarmType.Alarm);
    }
}
