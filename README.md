# SpinRocket_Simulation
A Study on the Centrifugal Separated Space Rocket Launching System

# project summary
Charging batteries using solar energy (electric energy generation using solar energy on Mars)
Construction of a launch pad by transporting a rotating shaft and a rotating wing on a 3D printing technology or rocket.
Set Rocket Arrival Destination (Mars and Earth are orbiting, calculating appropriate orientation, and timing)
Motor Rotation (Motor Rotation Using Solar Battery Charged Electrical Energy)
Maximum rocket launch energy generation using centrifugal force.
Launch target (direction, timing, and launch energy calculation using sensor and mechanical learning)

# unity version
2019.4.1f1


# Cal_physics.cs
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


# spin_lanchers.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spin_launcher : MonoBehaviour
{

    public GameObject motor;
    public float speed;
    // public float width;
    // public float height;
    public Text MotorSpeed;    


    // Start is called before the first frame update
    void Start()
    {
        RectTransform rectTransform;
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        spin_around();
        MotorSpeed.text = "Motor Speed: " + speed;
        
    }

    void spin_around()
    {
        transform.RotateAround(motor.transform.position, Vector3.down, speed * Time.deltaTime);
    }
}

