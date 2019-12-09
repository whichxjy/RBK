using UnityEngine;

public class Enemy : MonoBehaviour {
    private enum EnemyState { Stop, Moving, Dead };
    private EnemyState currentState;

    public GameObject initBlock;
    public GameObject blackBlock;

    public GameObject target;

    private float smoothing = 0.3f;

    private void Start() {
        initBlock.SetActive(true);
        blackBlock.SetActive(false);
        currentState = EnemyState.Stop;
    }

    public void Update() {
        if (currentState == EnemyState.Stop) {
            StopCoroutine("MoveTo");
            StartCoroutine("MoveTo", target);
        }
    }

    public void die() {
        initBlock.SetActive(false);
        blackBlock.SetActive(true);
        if (currentState == EnemyState.Moving) {
            StopCoroutine("MoveTo");
        }
        currentState = EnemyState.Dead;
    }

    private IEnumerator MoveTo(GameObject target) {
        currentState = EnemyState.Moving;
        while (Vector3.Distance(transform.position, target.transform.position) > 0.05f) {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, smoothing * Time.deltaTime);
            yield return null;
        }
        currentState = EnemyState.Stop;
    }
}
