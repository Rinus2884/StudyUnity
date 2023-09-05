using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 
    unity는 wav, mp3, ogg,... 등의 여러 다양한 음원파일포맷의 임포트를 지원한다.
(vs unreal 4.27 dml 경우는 wav만 가능하다)


Audio Clip 애셋
    임포트된 음원 리소스(자원)은 audio clip애셋으로 취급된다.

    효과음의 경우 : 용량이 작고 빠르게 플레이되야 하는 성질이므로 PreLoad 속성을 주는게 일반적이다.
    배경의 경우
 



    Force to Mono:. 저품질의 모바일 장치라면 굳이 스테레오 성질이 필요없다면 Mono 형식으로 용량을 줄일 수있다.

Audio Source 컴포넌트:
    음원의 기능을 가지는 컴포넌트 소리가 난다.

    Spatial Blend
    2D <------>3D
    2D이면 그냥 항상 들린다.
    3D이면 공간상 해당 음원과 청자의 위치에 영향을 받는다.
    <--가까우면 크게, 멀면 작게 들린다.


Audio Listener 컴포넌트: 
청자의 기능을 가지는 컴포넌트 소리를 듣는다.



=================================================

AudiMixer애셋
:AudioSource와 AudioListener 사이에 위치한다.
AudioSource의 음원에 임의의 변형을 가하기 위한 단계로서 준비되었다.

 N개의 group의 집합이다.
 AudioSource에 group을 설정할수있다.
 Master Group은 기본으로 세팅된다.
 Group을 커스텀하게 작성할 수 있다.
 모든 group은 MAster guoup으로 귀결된다.

group: AudioMixer의 구성요소이다. 임의의 효과들의 집합이다.

snapshot: 현재 AudioMixer의 모든 그룹의 모든 효과의 데이터값들의 집합의 저장단위

 
view: 임의의 그룹들의 가시성 여부에 대한 정보이다.(편집에 편리한 기능이다.)

========================
ducking
:강조해야할 오디오가 있을때 다른 오디오의 볼륨을 줄이는 효과를 말한다.

예) 나레이션 오디오를 강조하기 위해 배경음악의 볼륨을 줄인다.
    찰랑거리는 발자국 소리를 강조하기위해 빗소리환경음의 볼륨 줄인다. 등

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
