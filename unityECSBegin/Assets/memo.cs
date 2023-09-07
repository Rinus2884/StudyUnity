using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    unity에서 DOTS기술이 적용된도구가 바로 ECS이다.
    DOTS
    Data Oriented Technology Stack
    <-- DOP의 일환으로 유니티가 여러가지 기술을 모아놓은 집합
    (ECS, Burst컴파일러,  JOB 시스템,....)
    ECS: 메모리 레이아웃을 최적화하여 성능을 끌어올린다.
    Burst:좀더 성능이 좋은 버스트 컴파일러를 이용하여 '성능을 끌어올린다.'
    JOB: 멀티스레딩을 이용하여 '성능을 끌어올린다.'


    structured programming
    OOP Object Orietned Programming
    <-- 클래스간 관계, 객체 간 관계를 기반으로 프로그램 구조를 작성하는 방법론
   
    장점:사람에 생각에 보다 가깝게 추상화하여 다루는 방법이다.
    (기능을 관련있는 데이터와 묶어 다룬다.)

    단점:기능과 관련 있는 데이터끼리 묶어 메모리에 배치되므로 컴퓨터 입장에서 보면 성능상 굉장한 단점이 된다.
    ==>메모리가 파편화될 가능성이 매우 크다.

    배열:동일한 타입의 원소들의 연속적인 메모리 블럭(캐쉬적중률이 높아진다 -->프로그램 성능이 좋아진다)


    General Programming
    

    DOTS
    Data Oriented Technology Stack
    -프로그램 성능을 높이기 위해, '데이터 중심'으로 프로그래밍 하는 방법이다.
    <-동일한 타입의 원소들을 연속적으로 배치하는 것이 핵심이다.
    (캐쉬적중률이 높아진다 -->프로그램 성능이 좋아진다)
    
    OOP의 단점을 극복하기 위한 방법론
    OOP의 방법을 버리므로 즉, unity의 기존의 시스템의 장점을 버리게된다.

  
    
 
    <-- 데이터를 묶는(연속적으로 배치하는)방법
    
    i) spare type
        mX/mX/mX/mX/mX/...
        mHP/mHP/mHp/mHP/...

    ii) arche type(클래스라고 오해할수있음)
       (mX/mHP)
 

  Unity ECS 도구
    
    ECS
        Entitiy     ECS에서 게임오브젝트를 이야기함
        Component   ECS에서 컴포넌트를 이야기한다.

        <-- arche type 방식을 쓴다.

        System:     기능(method)에 해당하는 것이다.
 
    ==Hybrid ECS방법 사용

 */
public class memo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
