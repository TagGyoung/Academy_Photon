using UnityEngine;
using UnityEngine.UI;

public enum AlarmType
{
    Alarm,
    NickName
}

public class Alarm : MonoBehaviour
{
    [SerializeField] Text content;

    public static void Show(string message, AlarmType alarmType)
    {
        GameObject window = Instantiate(Resources.Load<GameObject>(alarmType.ToString()));
        // Resources에 있는 Alarm 또는 NickName을 생성합니다.

        window.GetComponent<Alarm>().content.text = message;
        // message를 입력받아서 Alarm 또는 NickName Resources에 존재하는 하위 Text 오브젝트에 전달합니다.

        window.GetComponent<Alarm>().content.fontSize = 65;
        // Alarm 또는 NickName Resources에 존재하는 하위 Text 오브젝트의 폰트 사이즈를 변경합니다.

        window.GetComponent<Alarm>().content.alignment = TextAnchor.MiddleCenter;
        // Alarm 또는 NickName Resources에 존재하는 하위 Text 오브젝트의 위치를 중앙으로 맞춰줍니다.
    }

    public void Close()
    {
        Destroy(gameObject);
    }
}
