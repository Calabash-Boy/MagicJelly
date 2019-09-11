using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateElement : MonoBehaviour
{
    public GameObject heavyGate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //获取父类的速度属性
            PlayerSystem s = other.GetComponentInParent<PlayerSystem>();
            float speed = s.speed;
            Debug.Log(speed);
            GameObject go = Instantiate(heavyGate, this.transform.position, this.transform.rotation);
            Rigidbody rigi = go.GetComponent<Rigidbody>();
            //rigi.AddExplosionForce(10, this.transform.position, 0.5f);
            rigi.AddForceAtPosition(new Vector3(0, 0, speed * 1.5f), this.transform.position, ForceMode.Impulse);
            Destroy(this.gameObject);
        }
    }
}
