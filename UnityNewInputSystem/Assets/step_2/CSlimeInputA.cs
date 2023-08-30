using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSlimeInputA : MonoBehaviour
{
    InputActions_ActionMaps mInputActions = null;
    // Start is called before the first frame update
    void Start()
    {
        mInputActions = new InputActions_ActionMaps();
        mInputActions.ActionMapsSlimeA.DoMoveForwardAxis.Enable();
        //해당 액션 활성화
        mInputActions.ActionMapsSlimeA.DoMoveRotate.Enable();
    }

    Vector3 mVelocity = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        float tScalar = mInputActions.ActionMapsSlimeA.DoMoveForwardAxis.ReadValue<float>();

        mVelocity = this.transform.forward;
        mVelocity = mVelocity * tScalar * 10f * Time.deltaTime;

        //해당속도로 이동
        this.transform.Translate(mVelocity, Space.World);

        float tScalarRotate = mInputActions.ActionMapsSlimeA.DoMoveRotate.ReadValue<float>();
        this.transform.Rotate(Vector3.up, tScalarRotate);
    }

    void OnDoFire()
    {
        Debug.Log("CSlimeInputA.OnDoFire");

    }
}
