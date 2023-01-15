using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
   public Rigidbody rb;
     AudioSource audioSource;
    public float rotatevalue = 1.0f;
    public float thrustvalue = 1.0f;
    public AudioClip mainengine;
    public ParticleSystem mainthrust;
    public ParticleSystem leftthrust;
    public ParticleSystem rightthrust;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        thrust();
        
         rotate();
    }

    void thrust()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            startthrust();
        }
        else
        {
            stopthrust();
        }
    }
    void startthrust()
    {
        startrotation();
    }
    void stopthrust()
    {
        audioSource.Stop();
        mainthrust.Stop();
    }

    

     void startrotation()
    {
        rb.AddRelativeForce(0, thrustvalue * Time.deltaTime, 0);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainengine);
        }
        if (!mainthrust.isPlaying)
        {
            mainthrust.Play();
        }
    }

    void rotate()
        {
        if (Input.GetKey(KeyCode.A))
            rotateleft();

        else if (Input.GetKey(KeyCode.D))
        {
            rotateright();
        }
        else
        {
            stoprotate();
        }


        void applyrotation(float rotateframe)
        {
            rb.freezeRotation = true;
            transform.Rotate(Vector3.forward * rotateframe * Time.deltaTime);
            rb.freezeRotation = false;
        }

        void rotateleft()
        {
            applyrotation(rotatevalue);
            if (!rightthrust.isPlaying)
            {

                rightthrust.Play();
            }
        }

        void rotateright()
        {
            applyrotation(-rotatevalue);
            if (!leftthrust.isPlaying)
            {

                leftthrust.Play();
            }
        }
    }

    void stoprotate()
    {
        rightthrust.Stop();
        leftthrust.Stop();
    }









}
