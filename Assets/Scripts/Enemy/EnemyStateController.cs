using System.Collections;
using UnityEngine;

public class EnemyStateController : MonoBehaviour {
    public GameObject initBlock;
    public GameObject endBlock;

    private void Start() {
        initBlock.SetActive(true);
        endBlock.SetActive(false);
    }

    public void die() {
        initBlock.SetActive(false);
        endBlock.SetActive(true);
    }
}
