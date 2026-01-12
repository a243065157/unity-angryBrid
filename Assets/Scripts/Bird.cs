using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 等待 发射前 发射后
public enum BirdState
{
    Waiting,
    BeforeShoot,
    AfterShoot
}
public class Bird : MonoBehaviour
{
    // 等待 发射前 发射后
    public BirdState state = BirdState.BeforeShoot;
    public bool isMouseDown = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case BirdState.Waiting:
                break;
            case BirdState.BeforeShoot:
                MoveControl();

                break;
            case BirdState.AfterShoot:
                break;
        }
    }
    // OnmouseUp & onMouseUp
    private void OnMouseDown()
    {
        if (state == BirdState.BeforeShoot)
        {
            isMouseDown = true;
            Slingshot.Instance.StartDraw(this.transform);
        }
    }
    private void OnMouseUp()
    {
        if (state == BirdState.BeforeShoot)
        {
            isMouseDown = false;
            Slingshot.Instance.EndDraw();
        }
    }
    private void MoveControl()
    {
        if (isMouseDown)
        {
            transform.position = GetMousePosition();
        }
    }
    private Vector3 GetMousePosition()
    {
        // 将鼠标坐标转换为世界坐标 这里要修改他的z值坐标
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // 因为这是2d游戏，不要修改z坐标
        mousePosition.z = 0;
        return mousePosition;
    }
}
