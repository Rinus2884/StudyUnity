using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CSceneAudioMixer_step_1 : MonoBehaviour
{
    public AudioSource mAsBGM = null;
    public AudioSource mAsEffect = null;
    public AudioSource mAsShot = null;
    public AudioMixerSnapshot mSsDefault = null;
    public AudioMixerSnapshot mssDistorsionBGM = null;
    public AudioMixerSnapshot mssDistorsionEFx = null;


    private void OnGUI()
    {
        if(GUI.Button(new Rect(0,0,150,100), "play asEffect"))
        {
            mAsEffect.Play();
        }

        if (GUI.Button(new Rect(150, 0, 150, 100), "play asShot"))
        {
            mAsShot.Play();

        }


        if (GUI.Button(new Rect(0, 200, 150, 100), "play ssDefault"))
        {
            mSsDefault.TransitionTo(0f);

        }
        if (GUI.Button(new Rect(150, 200, 150, 100), "play ssDistorsionBGM"))
        {
            mssDistorsionBGM.TransitionTo(0f);

        }
        if (GUI.Button(new Rect(300, 200, 150, 100), "play ssDistorsionEFx"))
        {
            mssDistorsionEFx.TransitionTo(0f);

        }
       



    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
