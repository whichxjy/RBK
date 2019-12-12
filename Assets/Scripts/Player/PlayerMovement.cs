
using UnityEngine;
using Valve.VR;

public class PlayerMovement : MonoBehaviour {
    private readonly float sensitivity = 0.1f;
    private readonly float maxSpeed = 1.0f;

    public SteamVR_Action_Boolean movePressAction;
    public SteamVR_Action_Vector2 moveValueAction;

    private float speed;

    private CharacterController characterController;
    private Transform vrCamera;
    private Transform head;

    private void Awake() {
        characterController = GetComponent<CharacterController>();
    }

    private void Start() {
        vrCamera = SteamVR_Render.Top().origin;
        head = SteamVR_Render.Top().origin;
    }

    private void Update() {
        HandleHead();
        HandleHeight();
        CalculateMovement();
    }

    private void HandleHead() {
        Vector3 oldPosition = vrCamera.position;
        Quaternion oldRotation = vrCamera.rotation;

        transform.eulerAngles = new Vector3(0.0f, head.rotation.eulerAngles.y, 0.0f);

        vrCamera.position = oldPosition;
        vrCamera.rotation = oldRotation;
    }

    private void HandleHeight() {
        float headHeight = Mathf.Clamp(head.localPosition.y, 1, 2);
        characterController.height = headHeight;

        Vector3 newCenter = Vector3.zero;
        newCenter.y = characterController.height / 2;
        newCenter.y += characterController.skinWidth;

        newCenter.x = head.localPosition.x;
        newCenter.z = head.localPosition.z;

        newCenter = Quaternion.Euler(0, -transform.eulerAngles.y, 0) * newCenter;

        characterController.center = newCenter;
    }

    private void CalculateMovement() {
        Vector3 orientationEuler = new Vector3(0, transform.eulerAngles.y, 0);
        Quaternion orientation = Quaternion.Euler(orientationEuler);
        Vector3 movement = Vector3.zero;

        if (movePressAction.GetStateUp(SteamVR_Input_Sources.Any)) {
            speed = 0;
        }

        if (movePressAction.state) {
            speed += moveValueAction.axis.y * sensitivity;
            speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
            movement = orientation * (speed * Vector3.forward) * Time.deltaTime;
        }

        movement = -movement;

        characterController.Move(movement);
    }
}
