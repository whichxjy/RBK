using System.Collections;
using UnityEngine;

public class EnemyStateController : MonoBehaviour {
    public GameObject initBlock;
    public GameObject blackBlock;

    private void Start() {
        initBlock.SetActive(true);
        blackBlock.SetActive(false);
    }

    public void die() {
        initBlock.SetActive(false);
        blackBlock.SetActive(true);
    }
}
