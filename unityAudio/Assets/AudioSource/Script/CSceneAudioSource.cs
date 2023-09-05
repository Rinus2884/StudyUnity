using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSceneAudioSource : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CSndMgr.GetInst().testDisplayAll();

        CSndMgr.GetInst().Play("bgm_0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if(GUI.Button(new Rect(0,0,150,100), "change bgm"))
        {
            CSndMgr.GetInst().Stop("bgm_0");
            CSndMgr.GetInst().Play("bgm_1");
        }

        if(GUI.Button(new Rect(0,100,150,100), "actor attack"))
        {
            CSndMgr.GetInst().Play("fx_0_ahha");
        }
        if (GUI.Button(new Rect(0, 200, 150, 100), "enemy spawn"))
        {
            CSndMgr.GetInst().Play("fx_1_createenemy");
        }
    }
}
