using UnityEngine;

public class SwordController : MonoBehaviour {
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Blue")) {
            collision.collider.gameObject.transform.parent.gameObject.GetComponent<EnemyState>().Die();
        }
    }
}
