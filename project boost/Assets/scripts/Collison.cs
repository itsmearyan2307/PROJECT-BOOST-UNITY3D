using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
public class Collison : MonoBehaviour
{
    public float delaytime = 2.0f;
    public AudioClip success;
    public AudioClip failure;

    AudioSource audiosource;
    bool istransitioning = false;

    public ParticleSystem successparticle;
    public ParticleSystem failparticle;
    public Text hitcounter;
    int hits = 0 ; 

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    //private void Update()
   // {
       // hitcounter.text = hits.ToString();
   // }
    void OnCollisionEnter(Collision other)
    {
        if (istransitioning)
        {

            return; 
        }
        switch (other.gameObject.tag)
        {
            case  "Friendly":
                
                break;

            case "finish":
              
                startsuccess();
                
                break;

            case "Fuel":
               
                break;
                default:
                 
                crashsequence();
                     
                break;
                
        }
       
    }
   void  crashsequence()
    {
        istransitioning = true;
        
        audiosource.Stop();
        audiosource.PlayOneShot(failure);
        failparticle.Play();
        GetComponent<movement>().enabled = false;
        Invoke("reloadscene", delaytime);

        updatehit();

    }

    private void updatehit()
    { 
        hits = hits + 1; ;
       
    }

    void startsuccess()
    {
        istransitioning = true;
       
        audiosource.Stop();
        audiosource.PlayOneShot(success);
        successparticle.Play();
        GetComponent<movement>().enabled = false;
        Invoke("nextlevel", delaytime);
    }
    void reloadscene()
    {

        int currentsceneindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentsceneindex);
    }


    void nextlevel()
    {
        int currentsceneindex = SceneManager.GetActiveScene().buildIndex;
        int nextlevelindex = currentsceneindex + 1;

        if(nextlevelindex == SceneManager.sceneCountInBuildSettings)
        {

            nextlevelindex = 0;
        }
        SceneManager.LoadScene(nextlevelindex);

        
    }
}
