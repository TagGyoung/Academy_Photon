using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    [SerializeField] float speed = 5.0f;

    public void OnMove(float x, float z)
    {
        direction.x = x;
        direction.z = z;

        direction.Normalize();

        transform.position += transform.TransformDirection((direction) * speed * Time.deltaTime);

        // transform.Translate(direction * speed * Time.deltaTime);
    }

}
