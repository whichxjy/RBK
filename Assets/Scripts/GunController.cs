using UnityEngine;
using Valve.VR;

public class GunController : MonoBehaviour
{
    public ParticleSystem bulletLauncher;

    private SteamVR_Action_Boolean shootAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Player", "Shoot");
    private SteamVR_Action_Boolean switchWeaponAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Player", "SwitchWeapon");

    private SteamVR_Input_Sources leftHand = SteamVR_Input_Sources.LeftHand;
    private SteamVR_Input_Sources rightHand = SteamVR_Input_Sources.RightHand;

    // Start is called before the first frame update
    void Start()
    {
        bulletLauncher = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(switchWeaponAction.state);
       // Debug.Log(shootAction.state);


        if (shootAction[leftHand].stateDown)
        {
            Debug.Log(1);
            bulletLauncher.Emit(1);
        }
        if (switchWeaponAction[rightHand].stateDown)
        {
            Debug.Log(1);
            bulletLauncher.Emit(1);
        }
    }
}
