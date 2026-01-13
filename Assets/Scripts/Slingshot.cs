using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
 // 单例模式 让外部可以用这个类
    public static Slingshot Instance { get; private set;}
    private LineRenderer leftLineRenderer;
    private LineRenderer rightLineRenderer;
    private Transform leftPoint;
    private Transform rightPoint;
    private Transform centerPoint;
    private bool isDrawing = false;
    private Transform BirdTransform;

    // Awake 是 Unity 脚本的生命周期函数，在对象被加载时调用，早于 Start。
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        var t = transform.Find("LeftLineRenderer");
        Debug.Log("LeftLineRenderer find = " + (t ? t.name : "NULL"));
        leftLineRenderer = transform.Find("LeftLineRenderer").GetComponent<LineRenderer>();
        rightLineRenderer = transform.Find("RightLineRenderer").GetComponent<LineRenderer>();
        leftPoint = transform.Find("LeftPoint");
        rightPoint = transform.Find("RightPoint");
        centerPoint = transform.Find("CenterPoint");
        hideLine();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDrawing)
        {
            Draw();
        }
    }
    public void StartDraw(Transform BirdTransform)
    {
        isDrawing = true;
        // 这里用this的原因是他在这个方法里面定义了两个一模一样的变量名，this区分开是公共的还是方法里面自带的
        this.BirdTransform = BirdTransform;
        showLine();
    }
    public void EndDraw()
    {
        isDrawing = false;
        hideLine();

    }
    public void Draw()
    {
        Vector3 birdPosition = BirdTransform.position;
        // 绘制从弹弓到小鸟的后背的线
        birdPosition = (birdPosition - centerPoint.position).normalized * 0.4f + birdPosition;
        // 绘制左线
        // 第一个参数index，代表设置的位置
        leftLineRenderer.SetPosition(0, birdPosition);
        leftLineRenderer.SetPosition(1, leftPoint.position);
        // 绘制右线
        rightLineRenderer.SetPosition(0, birdPosition);
        rightLineRenderer.SetPosition(1, rightPoint.position);
    }

    public Vector3 getCenterPosition()
    {
        return centerPoint.position;
    }

    // 隐藏 显示皮筋
    public void hideLine()
    {
        leftLineRenderer.enabled = false;
        rightLineRenderer.enabled = false;
    }
    public void showLine()
    {
        leftLineRenderer.enabled = true;
        rightLineRenderer.enabled = true;
    }
}
