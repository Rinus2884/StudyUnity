using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.InputSystem;

public class CSlimeCSharp : MonoBehaviour
{

    //이것을 사용하기 위해서는 InputActionCSharp 인풋액션즈 애셋을 스크립트로 만들어주어야한다.
    InputActionCSharp mInputActions = null;


    // Start is called before the first frame update
    void Start()
    {
        mInputActions = new InputActionCSharp(); //<-- 해당 인풋액션즈 객체를 생성
        mInputActions.ActionMapsAxis.DoMoveForwardAxis.Enable();
        //해당 액션 활성화
        mInputActions.ActionMapsAxis.DoRotate.Enable();

    }

    // Update is called once per frame
    void Update()
    {
        float tScalar = mInputActions.ActionMapsAxis.DoMoveForwardAxis.ReadValue<float>();

        mVelocity = this.transform.forward;
        mVelocity = mVelocity * tScalar * 10f * Time.deltaTime;

        //해당속도로 이동
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

           
            //축입력이므로 임의의 스칼라 타입의 데이터를 얻는다 이것은 액션에서 ControlType으로 설정
            float tScalar = tContext.ReadValue<float>();

            Debug.Log($"CSlimeBasic.DoMove: {tScalar.ToString()}");

            mVelocity = Vector3.forward;
            mVelocity = mVelocity * tScalar * 1f;

            //해당속도로 이동
            this.transform.Translate(mVelocity, Space.World);
        }
    }
}
