using UnityEngine;
using Valve.VR;

public class GunController : MonoBehaviour {
    public ParticleSystem bulletLauncher;
    private readonly SteamVR_Action_Boolean shootAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("default", "Shoot");
    public SteamVR_Input_Sources hand;

    private void Start() {
        bulletLauncher = GetComponentInChildren<ParticleSystem>();
    }

    private void Update() {
        if (shootAction[hand].stateDown) {
            bulletLauncher.Emit(1);
        }
    }
}