using UnityEngine;

public class SwordController : MonoBehaviour {
    public LayerMask blueLayer;

    void Update() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1, blueLayer)) {
            hit.transform.parent.gameObject.GetComponent<EnemyStateController>().die();
        }
    }
}
