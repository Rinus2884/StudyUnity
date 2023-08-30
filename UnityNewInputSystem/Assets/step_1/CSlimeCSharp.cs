using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.InputSystem;

public class CSlimeCSharp : MonoBehaviour
{

    //�̰��� ����ϱ� ���ؼ��� InputActionCSharp ��ǲ�׼��� �ּ��� ��ũ��Ʈ�� ������־���Ѵ�.
    InputActionCSharp mInputActions = null;


    // Start is called before the first frame update
    void Start()
    {
        mInputActions = new InputActionCSharp(); //<-- �ش� ��ǲ�׼��� ��ü�� ����
        mInputActions.ActionMapsAxis.DoMoveForwardAxis.Enable();
        //�ش� �׼� Ȱ��ȭ
        mInputActions.ActionMapsAxis.DoRotate.Enable();

    }

    // Update is called once per frame
    void Update()
    {
        float tScalar = mInputActions.ActionMapsAxis.DoMoveForwardAxis.ReadValue<float>();

        mVelocity = this.transform.forward;
        mVelocity = mVelocity * tScalar * 10f * Time.deltaTime;

        //�ش�ӵ��� �̵�
        this.transform.Translate(mVelocity, Space.World);

        float tScalarRotate = mInputActions.ActionMapsAxis.DoRotate.ReadValue<float>();
        this.transform.Rotate(Vector3.up, tScalarRotate);

    }

    Vector3 mVelocity = Vector3.zero;

    public void DoMove(InputAction.CallbackContext tContext)
    {
        if (tContext.phase == InputActionPhase.Performed)
        {
            Debug.Log("DoMove");

           
            //���Է��̹Ƿ� ������ ��Į�� Ÿ���� �����͸� ��´� �̰��� �׼ǿ��� ControlType���� ����
            float tScalar = tContext.ReadValue<float>();

            Debug.Log($"CSlimeBasic.DoMove: {tScalar.ToString()}");

            mVelocity = Vector3.forward;
            mVelocity = mVelocity * tScalar * 1f;

            //�ش�ӵ��� �̵�
            this.transform.Translate(mVelocity, Space.World);
        }
    }
}
