using UnityEngine;

public class CameraManager : MonoBehaviour {
    #region Singleton
    public static CameraManager instance;

    private void Awake() {
        instance = this;
    }
    #endregion

    public GameObject vrCamera;
}
