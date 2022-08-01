using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScripts : MonoBehaviour
{
    public float hook_Speed;
    public int scoreValue;

    private void OnDisable()
    {
        GameplayManager.instance.DisplayScore(scoreValue);

    }
}
