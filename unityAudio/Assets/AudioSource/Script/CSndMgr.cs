using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Snd 음원들을 관리하는 관리자 클래스
/*
    음원관리 <-- 자료구조로 관리
    Play
    Stop
 
 */

public class CSndMgr
{
    private static CSndMgr mInstance = null;


    //AudioSource를 관리하는 자료구조
    //검색의 키는 string <-- 소스코드 작성시 직관적으로 하기 위해
    //Dictionary를 선택한 이유는 검색의 시간복잡도가 O(1)이기때문에
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
    //음원AudioSource 정보를 등록

    public void DoRegist(AudioSource tAs)
    {
        //원소추가
        mDictionary.Add(tAs.clip.name, tAs);
    }


    //음원 AudioSource정보를 등록 해제

    public void DoUseRegist(AudioSource tAs)
    {
        //원소삭제
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
