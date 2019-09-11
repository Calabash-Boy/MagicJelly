using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    private Vector3 direction;
    private Rigidbody rigi;
    public float speed = 5f;
    private float rSpeed = 0;
    private float delayDistance;
    private Vector3 yAxis;

    // Start is called before the first frame update
    void Start()
    {
        //添加一个力
        rigi = this.GetComponent<Rigidbody>();

        Collider col = GetComponent<Collider>();
        delayDistance = col.bounds.size.z * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
    }
    private void FixedUpdate()
    {

        rigi.MovePosition(rigi.position + transform.forward * Time.deltaTime * speed);
        //Debug.Log("positin" + rigi.position + "\n" + "forfard" + transform.forward);
    }

    

    private void OnCollisionEnter(Collision collision)
    {
       
        GameObject cor = collision.gameObject;
        direction = cor.transform.forward;
        //Debug.Log(cor.tag);
        if (cor.tag == "Path")
        {



        }
        else if (cor.tag == "Corner")
        {
            
            Debug.Log("Enter Corner");
            //获取要旋转的正方向
            float angle = Vector3.Angle(transform.forward, direction);
            Vector3 normal = Vector3.Cross(transform.forward, direction);//叉乘求出法线向量
            angle *= Mathf.Sign(Vector3.Dot(normal, transform.up));
            Quaternion start_rotation = this.transform.rotation;
            Quaternion target_rotation = Quaternion.AngleAxis(angle, Vector3.up) * start_rotation;

            float time = Mathf.PI * 0.25f / speed;
            float delayTime = delayDistance / speed;
            rSpeed = angle / time;
            yAxis = new Vector3(-delayDistance, 1, delayDistance);
            yAxis = cor.transform.TransformPoint(yAxis);

            Vector3 targetP = new Vector3(0, 1, delayDistance);
            targetP = cor.transform.TransformPoint(targetP);
            //修改一下y值为玩家的y值
            targetP.y = transform.position.y;

            StartCoroutine(PlayerRotation(target_rotation, time, delayTime, yAxis, targetP));
        }
        else if (cor.tag == "Barrier")
        {
            //Debug.Log("Barrier");
            ////碰到了障碍物 给一个反向上的速度
            //Vector3 inverseV = new Vector3(0, 3, -speed * 2);
            //rigi.velocity = inverseV;
        }
    }

    

	private void OnTriggerEnter(Collider collision)
	{
		GameObject cor = collision.gameObject;
		if(cor.tag == "Barrier")
		{
            Vector3 v = -transform.forward * (speed + 2);
            v.y = 2;
			//碰到了障碍物 给一个反向上的速度
			Vector3 inverseV = v;
			rigi.velocity = inverseV;
		}
	}


	IEnumerator PlayerRotation(Quaternion target_rotation, float time, float delayTime, Vector3 axis, Vector3 targetP)
    {
        yield return new WaitForSeconds(delayTime);

        Debug.Log("rotation");
        speed = 0;
        float timer = 0;
        rigi.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        while (timer <= time)
        {
            timer += Time.fixedDeltaTime;
            this.transform.RotateAround(axis, Vector3.up, rSpeed * Time.fixedDeltaTime);
            if (timer >= time)
            {
                Debug.Log("timer: " + timer + "time: " + time);
                //最后一帧修复偏差
                speed = 5;
                transform.rotation = target_rotation;
                transform.position = targetP;

                rigi.constraints = RigidbodyConstraints.FreezeRotation;

            }

            yield return new WaitForFixedUpdate();
        }
    }
}
