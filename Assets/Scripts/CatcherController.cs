using UnityEngine;
using Valve.VR;
using System.Collections.Generic;

public class CatcherController : MonoBehaviour {
    public SteamVR_Behaviour_Pose pose;
    private SteamVR_Action_Boolean catchAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("default", "Catch");
    public SteamVR_Input_Sources hand;

    private FixedJoint fixedJoint;
    private Interactable currentInteractable = null;
    public List<Interactable> contactInteractables = new List<Interactable>();

    private void Awake() {
        fixedJoint = GetComponent<FixedJoint>();
    }

    private void Update() {
        if (catchAction[hand].stateDown) {
            PickUp();
        }
        if (catchAction[hand].stateUp) {
            Drop();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("BlackBlock")) {
            contactInteractables.Add(other.gameObject.GetComponent<Interactable>());
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("BlackBlock")) {
            contactInteractables.Remove(other.gameObject.GetComponent<Interactable>());
        }
    }

    private void PickUp() {
        currentInteractable = GetNearestInteractable();
        if (!currentInteractable) {
            return;
        }

        if (currentInteractable.catcherController) {
            currentInteractable.catcherController.Drop();
        }

        currentInteractable.transform.position = transform.position;

        Rigidbody targetBody = currentInteractable.GetComponent<Rigidbody>();
        fixedJoint.connectedBody = targetBody;

        currentInteractable.catcherController = this;
    }

    private void Drop() {
        if (!currentInteractable) {
            return;
        }

        Rigidbody targetBody = currentInteractable.GetComponent<Rigidbody>();
        targetBody.velocity = pose.GetVelocity();
        targetBody.angularVelocity = pose.GetAngularVelocity();

        fixedJoint.connectedBody = null;

        currentInteractable.catcherController = null;
        currentInteractable = null;
    }

    private Interactable GetNearestInteractable() {
        Interactable nearest = null;
        float minDistance = float.MaxValue;

        foreach (Interactable interactable in contactInteractables) {
            float distance = (interactable.transform.position - transform.position).sqrMagnitude;

            if (distance < minDistance) {
                minDistance = distance;
                nearest = interactable;
            }
        }

        return nearest;
    }
}
