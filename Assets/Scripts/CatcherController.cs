using UnityEngine;
using Valve.VR;

public class CatcherController : MonoBehaviour {
    private SteamVR_Action_Boolean catchAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("default", "Catch");

    private SteamVR_Input_Sources leftHand = SteamVR_Input_Sources.LeftHand;
    private SteamVR_Input_Sources rightHand = SteamVR_Input_Sources.RightHand;

    private GameObject catchedObj;

    private FixedJoint fixedJoint;

    private Rigidbody rigidBody;

    private bool throwing;
    private Rigidbody throwingRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        catchedObj = null;
        fixedJoint = GetComponent<FixedJoint>();

        throwing = true;

        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (catchAction[leftHand].stateDown)
        {
            Debug.Log(1);
            PickUpObj();
        }
        if (catchAction[rightHand].stateDown)
        {
            Debug.Log(1);
            PickUpObj();
        }


        if (catchAction[leftHand].stateUp)
        {
            Debug.Log(1);
            DropObj();
        }
        if (catchAction[rightHand].stateUp)
        {
            Debug.Log(1);
            DropObj();
        }
    }

    private void FixedUpdate()
    {
        if (throwing)
        {
           throwingRigidBody.velocity = rigidBody.velocity;
            throwingRigidBody.angularVelocity = rigidBody.angularVelocity * 0.25f;

            //throwingRigidBody.maxAngularVelocity = rigidBody.angularVelocity.magnitude;

           throwing = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        catchedObj = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        catchedObj = null;
    }

    void PickUpObj()
    {
        if (catchedObj == null)
        {
            fixedJoint.connectedBody = null;

            throwing = false;

            throwingRigidBody = null;
        }
        else
        {
            fixedJoint.connectedBody = catchedObj.GetComponent<Rigidbody>();
        }
    }

    void DropObj()
    {
        if (fixedJoint.connectedBody != null)
        {
            throwingRigidBody = fixedJoint.connectedBody;

            fixedJoint.connectedBody = null;

            throwing = true;
        }
    }
}
