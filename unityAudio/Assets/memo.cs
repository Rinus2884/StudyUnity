using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 
    unity�� wav, mp3, ogg,... ���� ���� �پ��� �������������� ����Ʈ�� �����Ѵ�.
(vs unreal 4.27 dml ���� wav�� �����ϴ�)


Audio Clip �ּ�
    ����Ʈ�� ���� ���ҽ�(�ڿ�)�� audio clip�ּ����� ��޵ȴ�.

    ȿ������ ��� : �뷮�� �۰� ������ �÷��̵Ǿ� �ϴ� �����̹Ƿ� PreLoad �Ӽ��� �ִ°� �Ϲ����̴�.
    ����� ���
 



    Force to Mono:. ��ǰ���� ����� ��ġ��� ���� ���׷��� ������ �ʿ���ٸ� Mono �������� �뷮�� ���� ���ִ�.

Audio Source ������Ʈ:
    ������ ����� ������ ������Ʈ �Ҹ��� ����.

    Spatial Blend
    2D <------>3D
    2D�̸� �׳� �׻� �鸰��.
    3D�̸� ������ �ش� ������ û���� ��ġ�� ������ �޴´�.
    <--������ ũ��, �ָ� �۰� �鸰��.


Audio Listener ������Ʈ: 
û���� ����� ������ ������Ʈ �Ҹ��� ��´�.



=================================================

AudiMixer�ּ�
:AudioSource�� AudioListener ���̿� ��ġ�Ѵ�.
AudioSource�� ������ ������ ������ ���ϱ� ���� �ܰ�μ� �غ�Ǿ���.

 N���� group�� �����̴�.
 AudioSource�� group�� �����Ҽ��ִ�.
 Master Group�� �⺻���� ���õȴ�.
 Group�� Ŀ�����ϰ� �ۼ��� �� �ִ�.
 ��� group�� MAster guoup���� �Ͱ�ȴ�.

group: AudioMixer�� ��������̴�. ������ ȿ������ �����̴�.

snapshot: ���� AudioMixer�� ��� �׷��� ��� ȿ���� �����Ͱ����� ������ �������

 
view: ������ �׷���� ���ü� ���ο� ���� �����̴�.(������ ���� ����̴�.)

========================
ducking
:�����ؾ��� ������� ������ �ٸ� ������� ������ ���̴� ȿ���� ���Ѵ�.

��) �����̼� ������� �����ϱ� ���� ��������� ������ ���δ�.
    �����Ÿ��� ���ڱ� �Ҹ��� �����ϱ����� ���Ҹ�ȯ������ ���� ���δ�. ��

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
