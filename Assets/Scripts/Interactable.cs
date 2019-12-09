using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Interactable : MonoBehaviour {
    [HideInInspector]
    public CatcherController catcherController = null;
}
