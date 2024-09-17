using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(Move))]
[RequireComponent(typeof(Mouse))]
[RequireComponent(typeof(Rotate))]

public class Controller : MonoBehaviourPunCallbacks
{
    private GameObject panel;
    [SerializeField] Move move;
    [SerializeField] Mouse mouse;
    [SerializeField] Rotate rotate;
    [SerializeField] Camera temporaryCamera;

    private void Awake()
    {
        move = GetComponent<Move>();
        mouse = GetComponent<Mouse>();
        rotate = GetComponent<Rotate>();
    }
    
    void Start()
    {
        if (photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
        }
        else
        {
            temporaryCamera.enabled = false;

            GetComponentInChildren<AudioListener>().enabled = false;
        }
    }

    void Update()
    {
        if (!photonView.IsMine) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Mouse.ActiveMouse(true, CursorLockMode.None);

            if (panel == null) Instantiate(Resources.Load<GameObject>("Pause Popup"));
        }

        move.OnMove(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        rotate.OnRotate(0, Input.GetAxisRaw("Mouse X"), 0);
    }

    
}
