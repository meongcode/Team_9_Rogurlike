using Cainos.PixelArtPlatformer_VillageProps;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    public event Action<CharacterStatus> OnPotionEnd;
    public CharacterStatus status;
    public bool potionTime = false;
    public float time;


    private void Update()
    {
        if (potionTime)
        {
            potionTime = false;
            Debug.Log("Jump!");
            CallPosionEndEvent(status, time);
        }
    }

    public void CallPosionEndEvent(CharacterStatus status, float time)
    {
       StartCoroutine(WaitForIt(time));
    }

    IEnumerator WaitForIt(float time)   
    {
        yield return new WaitForSeconds(time);
        OnPotionEnd?.Invoke(status);
    }
}
