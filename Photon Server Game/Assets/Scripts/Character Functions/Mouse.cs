using Photon.Pun;
using System.Runtime.Serialization.Json;
using UnityEngine;


public class Mouse : MonoBehaviourPunCallbacks
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] Ray ray;
    [SerializeField] Vector3 direction;
    [SerializeField] Transform rayPosition;
    [SerializeField] RaycastHit raycastHit;

    void Start()
    {
        ActiveMouse(false, CursorLockMode.Locked);
    }

    public static void ActiveMouse(bool state, CursorLockMode mode)
    {
        Cursor.visible = state;
        Cursor.lockState = mode;
    }

    public void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            direction = Camera.main.ScreenPointToRay(Input.mousePosition).direction;

            ray = new Ray(rayPosition.position, direction);

            if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity, layerMask))
            {
                PhotonView photonObject = raycastHit.collider.gameObject.GetComponent<PhotonView>();

                photonObject.GetComponent<Unit>().Damage(50);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawRay(rayPosition.position, direction * 100);
    }
}
