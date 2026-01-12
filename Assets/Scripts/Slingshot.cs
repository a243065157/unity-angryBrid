using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
 // 单例模式 我还不知道有什么用
    public static Slingshot Instance { get; private set;}
    private LineRenderer leftLineRenderer;
    private LineRenderer rightLineRenderer;
    private Transform LeftPoint;
    private Transform RightPoint;
    private Transform CenterPoint;
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
        leftLineRenderer = transform.Find("LeftLineRenderer").getComponent<LineRenderer>();
        rightLineRenderer = transform.Find("RightLineRenderer").getComponent<LineRenderer>();
        leftPoint = transform.Find("LeftPoint");
        rightPoint = transform.Find("RightPoint");
        centerPoint = transform.Find("CenterPoint");
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
    }
    public void EndDraw()
    {
        isDrawing = false;

    }
    public void Draw()
    {
        // 绘制左线
        // 第一个参数index，代表设置的位置
        leftLineRenderer.SetPosition(0, BirdTransform.position);
        leftLineRenderer.SetPosition(1, leftPoint.position);
        // 绘制右线
        rightLineRenderer.SetPosition(0, BirdTransform.position);
        rightLineRenderer.SetPosition(1, rightPoint.position);
    }
}
