using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CSnd : MonoBehaviour
{

    void Awake()
    {
        //AudioSource ������Ʈ���� �����Ͽ� ���

        //N���� AudioSource������Ʈ�� ����
        AudioSource[] tASs = GetComponents<AudioSource>();

        foreach(var t in tASs)
        {
            //AudioSource������Ʈ���� ���
            CSndMgr.GetInst().DoRegist(t);
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        //AudioSource������Ʈ���� ������ �÷��̿� ���� ����� �����Ѵ�.
        //GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}