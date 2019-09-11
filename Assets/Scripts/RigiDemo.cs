using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigiDemo : MonoBehaviour
{

    public float force = 10f;
    public float circle = 5.0f;
    private Rigidbody rigi;
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        Collider col = GetComponent<Collider>();
        float zL = col.bounds.size.z * 0.5f;
        position = new Vector3(0, 0, -zL);
        
        StartCoroutine(Force());
    }

    IEnumerator Force()
    {
        yield return new WaitForSeconds(2.0f);
        Debug.Log("Explosion");
        //rigi.AddExplosionForce(force, position, circle);
        rigi.AddForceAtPosition(new Vector3(0, 0, force), this.transform.position, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //rigi.AddExplosionForce(force, this.transform.position, circle);
    }
}
