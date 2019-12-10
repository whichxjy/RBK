using System.Collections;
using UnityEngine;

public class EnemyState : MonoBehaviour {
    public GameObject initBlock;
    public GameObject endBlock;

    private void Start() {
        initBlock.SetActive(true);
        endBlock.SetActive(false);
    }

    public void die() {
        endBlock.transform.position = initBlock.transform.position;
        initBlock.SetActive(false);
        endBlock.SetActive(true);
    }
}
