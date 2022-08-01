using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

   
    [SerializeField] private AudioSource hookGrab_Gold_FX, hookGrab_Stone_FX, playerLaugh_FX, PullSoundFX, 
        RopeStrech_FX, timerRunningOutFX, gameEndFX;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    
        
  public void HookGrab_Gold()
    {
        hookGrab_Gold_FX.Play();
    }
    public void HookGrab_Stone()
    {
        hookGrab_Stone_FX.Play();
    }
    public void PlayerLaugh()
    {
        playerLaugh_FX.Play();
    }

    public void RopeStretch(bool playFX)
    {
        if (playFX)
        {
            if (!RopeStrech_FX.isPlaying)
            {
                RopeStrech_FX.Play();
            }
            else
            {
                if (!RopeStrech_FX.isPlaying)
                {
                    RopeStrech_FX.Stop();
                }
            }
        }
    }

    public void PullSound(bool playFX)
    {
        if(playFX)
        {
            if(!PullSoundFX.isPlaying)
            {
                PullSoundFX.Play();
            }
            else
            {
                if(PullSoundFX.isPlaying)
                {
                    PullSoundFX.Stop();
                }
            }
        }
    }

    public void TimeRunningOut(bool playFX)
    {
        if (playFX)
        {
            if (!timerRunningOutFX.isPlaying)
            {
                PullSoundFX.Play();
            }
            else
            {
                if (timerRunningOutFX.isPlaying)
                {
                    PullSoundFX.Stop();
                }
            }
        }
    }

    public void GameEnd()
    {
        gameEndFX.Play();
    }
}
