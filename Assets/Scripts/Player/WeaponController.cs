using UnityEngine;
using Valve.VR;

public class WeaponController : MonoBehaviour {
    private enum WeaponState { Sword, Catcher };
    private WeaponState currentState;

    private SteamVR_Action_Boolean switchAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("default", "Switch");
    public SteamVR_Input_Sources hand;

    public GameObject edge;
    public GameObject gun;
    public GameObject catcher;

    private void Start() {
        currentState = WeaponState.Sword;
    }

    private void Update() {
        if (switchAction[hand].stateDown) {
            if (currentState == WeaponState.Sword) {
                SwitchToCatcherState();
            }
            else {
                SwitchToSwordState();
            }
        }
    }

    private void SwitchToSwordState() {
        currentState = WeaponState.Sword;
        edge.SetActive(true);
        gun.SetActive(true);
        catcher.SetActive(false);
    }

    private void SwitchToCatcherState() {
        currentState = WeaponState.Catcher;
        edge.SetActive(false);
        gun.SetActive(false);
        catcher.SetActive(true);
    }
}
