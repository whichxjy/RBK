using UnityEngine;
using Valve.VR;

public class GunController : MonoBehaviour {
    public ParticleSystem bulletLauncher;
    private SteamVR_Action_Boolean shootAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("default", "Shoot");
    private SteamVR_Input_Sources leftHand = SteamVR_Input_Sources.LeftHand;
    private SteamVR_Input_Sources rightHand = SteamVR_Input_Sources.RightHand;

    void Start() {
        bulletLauncher = GetComponentInChildren<ParticleSystem>();
    }

    void Update() {
        if (shootAction[leftHand].stateDown) {
            bulletLauncher.Emit(1);
        }
        if (shootAction[rightHand].stateDown) {
            bulletLauncher.Emit(1);
        }
    }
}