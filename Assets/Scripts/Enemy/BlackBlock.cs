using UnityEngine;

public class BlackBlock : MonoBehaviour {
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Black")) {
            collision.collider.gameObject.transform.parent.gameObject.GetComponent<EnemyState>().Die();
        }
    }
}
