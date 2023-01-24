using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarScript : MonoBehaviour
{
    public float velocityMultiplier = 1.0f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVelocity(Vector3 vel)
    {
        rb.velocity = vel * velocityMultiplier;
    }
}
