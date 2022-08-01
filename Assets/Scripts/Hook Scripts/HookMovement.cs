using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    public float min_Z = -55f, max_Z = 55f; //rotation of hook on z axis
    public float rotate_Speed = 5f;

    private float rotateAngle;
    private bool rotate_Right;
    private bool canRotate;

    public float move_Speed = 3f;
    private float initial_Move_Speed;

    public float min_Y = -2.5f;
    private float initial_Y;

    private bool moveDown;

    //FOr Line Renderer
    private RopeRenderer ropeRenderer;

    private void Awake()
    {
        ropeRenderer = GetComponent<RopeRenderer>();
    }

    void Start()
    {
        initial_Y = transform.position.y;
        initial_Move_Speed = move_Speed;

        canRotate = true;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        GetInput();
        MoveRope();
    }

    void Rotate()
    {
        if (!canRotate)
            return;

        if(rotate_Right)
        {
            rotateAngle += rotate_Speed * Time.deltaTime;
        }
        else
        {
            rotateAngle -= rotate_Speed * Time.deltaTime;
        }
        transform.rotation = Quaternion.AngleAxis(rotateAngle, Vector3.forward);

        if(rotateAngle >= max_Z)
        {
            rotate_Right = false;
        }
        else if(rotateAngle <= min_Z)
        {
            rotate_Right = true;
        }
    }

    void GetInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(canRotate)
            {
                canRotate = false;
                moveDown = true;
                SoundManager.instance.RopeStretch(true);
            }
        }
    }
    void MoveRope()
    {
        if (canRotate)
            return;
        if(!canRotate)
        {
            Vector3 temp = transform.position;

            if(moveDown)
            {
                temp -= transform.up * Time.deltaTime * move_Speed;
            }
            else
            {
                temp += transform.up * Time.deltaTime * move_Speed;
            }
            transform.position = temp;

            if(temp.y <= min_Y)
            {
                moveDown = false;
            }

            if(temp.y >= initial_Y)
            {
                canRotate = true;
                //deactive line rendere
                ropeRenderer.RenderLine(temp, false);
                move_Speed = initial_Move_Speed;
                SoundManager.instance.RopeStretch(false);
            }

            ropeRenderer.RenderLine(temp, true);


        } //canot rotate
    }

    public void HookAttachedItem()
    {
        moveDown = false;
    }
}
