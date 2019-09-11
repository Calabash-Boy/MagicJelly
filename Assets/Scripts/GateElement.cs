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
            
            GameObject go = Instantiate(heavyGate, this.transform.position, this.transform.rotation);
            Rigidbody rigi = go.GetComponent<Rigidbody>();
            //rigi.AddExplosionForce(10, this.transform.position, 0.5f);
            Vector3 force = transform.forward * speed * 1.5f;
            rigi.AddForceAtPosition(force, this.transform.position, ForceMode.Impulse);
            Destroy(this.gameObject);
            Destroy(go, 2.0f);
        }
    }
}
