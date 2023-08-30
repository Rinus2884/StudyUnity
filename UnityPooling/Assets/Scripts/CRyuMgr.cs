using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
    object pool의 개념은 
    역사적으로 볼 때 memory pool의 개념으로 부터 온 것이다. 

    memory pool은 메모리 단편화를 방지하기 위한 기법이다. <--메모리 관점
    메모리 단편화는 동적할당과 해제 연산자의 범용성 때문에 생겨난다 

    그러므로 이를 해결하기 위해서는 범용성을 포기하는 방법을 쓴다. 
    
    즉, 객체(데이터)의 크기가 모두 같아야 한다는 것이다. 

    C#에서는 연산자 오버로드 등이 제한적이고 메모리 관리가 자동화 되어 있어 
    그냥 객체 단위로 관리하는 방법을 쓴다. <-- 객체 관점
    그래서 
    object pool이다.


*/

public class CRyuMgr
{
    private static CRyuMgr mpInst = null;

    //prefab link
    public CUnit PFUnit = null;

    //object pooling collection
    Stack<CUnit> mUnitStack = null;
    //<--CUnit은 참조타입 

    //singleton pattern 적용
    private CRyuMgr()
    {
        mpInst = null;
    }

    public static CRyuMgr GetInst()
    {
        if (null == mpInst)
        {
            mpInst = new CRyuMgr();
        }
        return mpInst;
    }

    //미리 객체들을 확보한다.
    public void CreateRyu()
    {
        if (null == PFUnit)
        {
            PFUnit = Resources.Load<CUnit>("PFUnit");
        }


        if (null == mUnitStack)
        {
            mUnitStack = new Stack<CUnit>();
        }

        if (null != mUnitStack)
        {
            //일단 n개만 만든다.(여기서는 일단 5개를 하겠다 )
            int ti = 0;
            int tCount = 5;
            CUnit tUnit = null;

            for (ti = 0; ti < tCount; ++ti)
            {
                tUnit = null;
                tUnit = GameObject.Instantiate<CUnit>(PFUnit, Vector3.zero, Quaternion.identity);

                GameObject.DontDestroyOnLoad(tUnit.gameObject);
                tUnit.gameObject.SetActive(false);//메모리에 할당되어 있지만 비활성화

                mUnitStack.Push(tUnit);
            }
        }
    }

    //객체 풀을 이용하여 객체를 할당(실제로 할당은 아니다)<--게임오브젝트를 활성
    public CUnit NewUnit()
    {
        CUnit t = null;

        //스택(pool)에서 가져온다
        if(mUnitStack.Count> 0)
        {
            t = mUnitStack.Pop();
        }
        else
        {
            //풀pool이 없으므로 좀더 확보한다.
            //일단 m개만 만든다.(여기서는 일단 5개를 하겠다 )
            int ti = 0;
            int tCount = 5;
            CUnit tUnit = null;

            for (ti = 0; ti < tCount; ++ti)
            {
                tUnit = null;
                tUnit = GameObject.Instantiate<CUnit>(PFUnit, Vector3.zero, Quaternion.identity);

                GameObject.DontDestroyOnLoad(tUnit.gameObject);
                tUnit.gameObject.SetActive(false);//메모리에 할당되어 있지만 비활성화

                mUnitStack.Push(tUnit);
            }

            //스택(pool)에서 가져온다
            t = mUnitStack.Pop();
        }


        t.gameObject.SetActive(true);
        t.CreateRyu();//<--해당 유닛에서 동적할당?시 필요한 처리들을 수행한다(이를테면 멤버변수의 참조, 코루틴 등)

        return t;
    }
    //객체 풀을 이용하여 객체를 해제(실제로 해제는 아니다)<--게임오브젝트를 비활성
    public void DeleteUnit(CUnit t)
    {
        t.DestroyRyu();//<--해당 유닛에서 해제?시 필요한 처리들을 수행한다(이를테면 멤버변수의 참조, 코루틴 등)
        t.gameObject.SetActive(false);
        //스택(pool)에 다시 넣는다
        mUnitStack.Push(t);
    }
}
