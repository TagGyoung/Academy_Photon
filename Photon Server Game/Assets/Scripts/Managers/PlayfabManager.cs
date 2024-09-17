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
        // 마스터 클라이언트를 따라서 하위 클라이언트가 전부 이동 ( true / false )

        PhotonNetwork.GameVersion = "1.0f";

        PhotonNetwork.LoadLevel("Photon Lobby");
        // SceneManager.LoadScene() 함수로 이동할 시
        // PhotonNetwork.AutomaticallySyncScene과 상관없이
        // 해당 함수를 호출한 클라이언트만 씬을 로드하기 떄문에
        // PhotonNetwork.LoadLevel() 함수를 이용하여 씬을 로드합니다.
    }

    public void Success(RegisterPlayFabUserResult result)
    {
        Alarm.Show(result.ToString(), AlarmType.Alarm);
    }

    public void SignUp()
    {
        // RegisterPlayFabUserRequest : 서버에 유저를 등록하기 위한 클래스입니다.
        RegisterPlayFabUserRequest request = new RegisterPlayFabUserRequest
        {
            Email = email.text,
            Password = password.text,
            RequireBothUsernameAndEmail = false
            // RequireBothUsernameAndEmail
            // : 사용자 이름과 이메일을 모두 필요로 하는지 설정할 수 있는 Property입니다.
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
