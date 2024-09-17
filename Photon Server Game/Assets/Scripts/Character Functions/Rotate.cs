using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float speed = 200f;
    [SerializeField] Vector3 direction;

    public void OnRotate(float x, float y, float z)
    {
        direction.x = x * speed;
        direction.y = y * speed;
        direction.z = z * speed;

        transform.eulerAngles += direction * Time.deltaTime;
    }
}
