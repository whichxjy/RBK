using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementController : MonoBehaviour {
    private float lookRadius = 5f;
    private Transform target;
    private NavMeshAgent agent;

    private void Start() {
        target = CameraManager.instance.vrCamera.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius) {
            agent.SetDestination(target.position);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
