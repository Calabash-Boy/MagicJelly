using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody rigi;
    bool isRotating;

    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();

        StartCoroutine(turnCorner());
    }


    IEnumerator turnCorner()
    {
        yield return new WaitForSeconds(2);

        //给一个旋转角度
        //this.transform.Rotate(new Vector3(0, -90, 0));
        isRotating = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        if(isRotating)
        {
            Debug.Log(transform.rotation.eulerAngles.y);
            if(transform.rotation.eulerAngles.y <= 270 && transform.rotation.eulerAngles.y > 0)
            {
                isRotating = false;
            } else
            {
                transform.Rotate(new Vector3(0, -90 * Time.deltaTime, 0));
            }
            
        }
    }

    
}
