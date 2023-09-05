using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Snd �������� �����ϴ� ������ Ŭ����
/*
    �������� <-- �ڷᱸ���� ����
    Play
    Stop
 
 */

public class CSndMgr
{
    private static CSndMgr mInstance = null;


    //AudioSource�� �����ϴ� �ڷᱸ��
    //�˻��� Ű�� string <-- �ҽ��ڵ� �ۼ��� ���������� �ϱ� ����
    //Dictionary�� ������ ������ �˻��� �ð����⵵�� O(1)�̱⶧����
    public Dictionary<string, AudioSource> mDictionary = new Dictionary<string, AudioSource>();
    private CSndMgr() 
    {
        mInstance = null;


    }

    public static CSndMgr GetInst()
    {
        if(mInstance == null)
        {
            mInstance = new CSndMgr();
        }

        return mInstance;
    }
    //����AudioSource ������ ���

    public void DoRegist(AudioSource tAs)
    {
        //�����߰�
        mDictionary.Add(tAs.clip.name, tAs);
    }


    //���� AudioSource������ ��� ����

    public void DoUseRegist(AudioSource tAs)
    {
        //���һ���
       mDictionary.Remove(tAs.clip.name);
    }

    public void testDisplayAll()
    {
        foreach(KeyValuePair<string, AudioSource> t in mDictionary)
        {
            Debug.Log(t.Key);
        }
    }

    public void Play(string tKey)
    {

        mDictionary[tKey].Play();
    }

    public void Stop(string tKey)
    {
        //O(1)
        mDictionary[tKey].Stop();
    }
}
