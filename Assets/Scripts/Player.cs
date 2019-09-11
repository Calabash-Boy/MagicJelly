using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    //按下鼠标后的比例变化
    private float ratio = 100f; //移动100像素 物体scale变化1
    private float fixedArea = 0; //长宽的乘积 在变化中保持不变
    private Vector3 curPosition; //鼠标在当前帧的点击位置
    private float offsetY; //鼠标在Y轴的偏移距离 上移为正 下移为负
    private float maxScale = 2.5f; //可变化到的比例最大值
    private float curScaleY; //当前Y轴的比例值
    private float curScaleX; //当前X轴的比例值


    // Start is called before the first frame update
    void Start()
    {

        curScaleY = transform.localScale.y;
        curScaleX = transform.localScale.x;
        fixedArea = curScaleX * curScaleY;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if(curPosition.y <= 0)
            {
                curPosition = Input.mousePosition;
            } else
            {
                offsetY = Input.mousePosition.y - curPosition.y;
                curPosition = Input.mousePosition;

                //修改Y方向的scale 并修改Y值
                curScaleY += (offsetY / ratio);
                curScaleY = Mathf.Clamp(curScaleY, fixedArea / maxScale, maxScale);
                curScaleX = fixedArea / curScaleY;

                transform.localScale = new Vector3(curScaleX, curScaleY, transform.localScale.z);

                float newY = (curScaleY - 1) * 0.5f; //默认高度是1 父坐标的中点

                //因为外部有父物体 更改Y轴的scale时没有贴到父物体底部
                transform.localPosition = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);
            }
            
        }

        if(Input.GetMouseButtonUp(0))
        {
            curPosition = new Vector3(0, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("children Collider");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("children Trigger");
    }


}
