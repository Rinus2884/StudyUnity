using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CSnd : MonoBehaviour
{

    void Awake()
    {
        //AudioSource 컴포넌트들을 수집하여 등록

        //N개의 AudioSource컴포넌트도 가정
        AudioSource[] tASs = GetComponents<AudioSource>();

        foreach(var t in tASs)
        {
            //AudioSource컴포넌트들을 등록
            CSndMgr.GetInst().DoRegist(t);
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        //AudioSource컴포넌트에서 음원의 플레이와 중지 기능을 제공한다.
        //GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}