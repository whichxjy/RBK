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

            if (distance <= agent.stoppingDistance) {
                FaceTarget();
            }
        }
    }

    private void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5 * Time.deltaTime);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
