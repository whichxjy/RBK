using UnityEngine;

public class SwordController : MonoBehaviour {
    public LayerMask layer;

    void Update() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1, layer)) { 
            Destroy(hit.transform.gameObject);
        }
    }
}
