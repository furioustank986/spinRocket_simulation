using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cal_physics : MonoBehaviour
{
    public Material fastWheelMaterial;
    public Material slowWheelMaterial;
    public Rigidbody rb;
    public MeshRenderer rend;
    float ang_velocity;
    public Text velocityText;
    public Vector3 com;
    public Text massText;
    public float R_radius_distance;
    private float Centerforce_re;
    private float mass;
    public Text Centerforce;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<MeshRenderer>();
        rb.centerOfMass = com;
        velocityText.text = "Angular Velocity: " + ang_velocity;

        mass = rb.mass;
        massText.text = "Rocket Mass: " + mass;
        Centerforce.text = "Center Forece: " + Centerforce_re;

    }
   
    void Update()
    {
         

        if (rb.angularVelocity.magnitude < 5)
        {
            rend.sharedMaterial = slowWheelMaterial;
            ang_velocity = rb.angularVelocity.magnitude;
            //Debug.Log("velocity < 5 :" + ang_velocity);
            velocityText.text = "Angular Velocity: " + ang_velocity;
            var Centerforce_re = mass * R_radius_distance * ang_velocity * ang_velocity;
            //Debug.Log("CenterForece:" + Centerforce);
            Centerforce.text = "Center Forece: " + Centerforce_re;

        }
        else
        {
            rend.sharedMaterial = fastWheelMaterial;
            ang_velocity = rb.angularVelocity.magnitude;
            //Debug.Log("velocity > 5 :" + ang_velocity);
            velocityText.text = "Angular Velocity: " + ang_velocity;
            var Centerforce_re = mass * R_radius_distance * ang_velocity * ang_velocity;
            //Debug.Log("CenterForece:" + Centerforce);
            Centerforce.text = "Center Forece: " + Centerforce_re;
        }

    }
}
