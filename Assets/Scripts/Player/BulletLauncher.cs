using UnityEngine;
using System.Collections.Generic;

public class BulletLauncher : MonoBehaviour {
    public ParticleSystem bulletLauncher;
    private readonly List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();

    private void Start() {
        bulletLauncher = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other) {
        bulletLauncher.GetCollisionEvents(other, collisionEvents);
        foreach (ParticleCollisionEvent collisionEvent in collisionEvents) {
            collisionEvent.colliderComponent.gameObject.transform.parent.gameObject.GetComponent<EnemyState>().Die();
        }
    }
}
