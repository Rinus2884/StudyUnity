using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSlimeInputB : MonoBehaviour
{
    InputActions_ActionMaps mInputActions = null;
    // Start is called before the first frame update
    void Start()
    {
        mInputActions = new InputActions_ActionMaps();
        mInputActions.ActionMapsSlimeB.DoMoveForwardAxis.Enable();
        //�ش� �׼� Ȱ��ȭ
        mInputActions.ActionMapsSlimeB.DoMoveRotate.Enable();
    }

    Vector3 mVelocity = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        float tScalar = mInputActions.ActionMapsSlimeB.DoMoveForwardAxis.ReadValue<float>();

        mVelocity = this.transform.forward;
        mVelocity = mVelocity * tScalar * 10f * Time.deltaTime;

        //�ش�ӵ��� �̵�
        this.transform.Translate(mVelocity, Space.World);

        float tScalarRotate = mInputActions.ActionMapsSlimeB.DoMoveRotate.ReadValue<float>();
        this.transform.Rotate(Vector3.up, tScalarRotate);
    }

    void OnDoFire()
    {
        Debug.Log("CSlimeInputB.OnDoFire");

    }
}
