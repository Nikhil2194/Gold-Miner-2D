using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour
{
    [SerializeField]
    private Transform itemHolder;

    private bool itemAttached;
    private HookMovement hookMovement;
    private PlayerAnimation playerAnim;
    void Awake()
    {
        hookMovement = GetComponentInParent<HookMovement>();
        playerAnim = GetComponentInParent<PlayerAnimation>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SmallGold" || collision.tag == "MiddleGold" ||
            collision.tag == "LargeGold" || collision.tag == "LargeStone" || collision.tag == "MiddleStone")
        {
            itemAttached = true;

            collision.transform.parent = itemHolder;
            collision.transform.position = itemHolder.position;

            hookMovement.move_Speed = collision.GetComponent<ItemScripts>().hook_Speed;
            hookMovement.HookAttachedItem();

           
            playerAnim.PullingItemAnimation();    //animate player
            if (collision.tag == "SmallGold"  || collision.tag == "MiddleGold" || collision.tag == "LargeGold")
            {
                SoundManager.instance.HookGrab_Gold();
            }
            else if(collision.tag == "MiddleStone"  || collision.tag == "LargeStone")
            {
                SoundManager.instance.HookGrab_Stone();
            }
            SoundManager.instance.PullSound(true);
        }

        if(collision.tag == "DeliverItem")
        {
            if(itemAttached)
            {
                itemAttached = false;
                Transform objChild = itemHolder.GetChild(0);
                objChild.parent = null;
                objChild.gameObject.SetActive(false);

                playerAnim.IdleAnimation();
                SoundManager.instance.PullSound(false);
            }
        }

    }
}
