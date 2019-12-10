using UnityEngine;

public class BlackBlock : MonoBehaviour {
    public LayerMask blackLayer;

    private void OnCollisionEnter(Collision collision) {
        Debug.Log(1);
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Black")) {
            Debug.Log(2);
            Debug.Log(collision.collider.transform.parent);
            collision.collider.gameObject.transform.parent.gameObject.GetComponent<EnemyStateController>().die();
        }
    }
}
