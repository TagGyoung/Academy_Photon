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
        // Resources�� �ִ� Alarm �Ǵ� NickName�� �����մϴ�.

        window.GetComponent<Alarm>().content.text = message;
        // message�� �Է¹޾Ƽ� Alarm �Ǵ� NickName Resources�� �����ϴ� ���� Text ������Ʈ�� �����մϴ�.

        window.GetComponent<Alarm>().content.fontSize = 65;
        // Alarm �Ǵ� NickName Resources�� �����ϴ� ���� Text ������Ʈ�� ��Ʈ ����� �����մϴ�.

        window.GetComponent<Alarm>().content.alignment = TextAnchor.MiddleCenter;
        // Alarm �Ǵ� NickName Resources�� �����ϴ� ���� Text ������Ʈ�� ��ġ�� �߾����� �����ݴϴ�.
    }

    public void Close()
    {
        Destroy(gameObject);
    }
}
