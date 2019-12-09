using UnityEngine;
using Valve.VR;

public class GunController : MonoBehaviour {
    public ParticleSystem bulletLauncher;
    private SteamVR_Action_Boolean shootAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("default", "Shoot");
    public SteamVR_Input_Sources hand;

    void Start() {
        bulletLauncher = GetComponentInChildren<ParticleSystem>();
    }

    void Update() {
        if (shootAction[hand].stateDown) {
            bulletLauncher.Emit(1);
        }
    }
}