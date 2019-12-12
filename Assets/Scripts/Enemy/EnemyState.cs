using UnityEngine;

public class EnemyState : MonoBehaviour {
    public GameObject initBlock;
    public GameObject endBlock;

    private void Start() {
        initBlock.SetActive(true);
        endBlock.SetActive(false);
    }

    public void Die() {
        endBlock.transform.position = initBlock.transform.position;
        initBlock.SetActive(false);
        endBlock.SetActive(true);
    }
}
