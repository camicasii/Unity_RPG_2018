using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SounStepsPlayer : MonoBehaviour
{
   private AudioSource audioSource;
   [SerializeField]
   [Range(-3,3)]
   private float maxPitch;
   [SerializeField]
   [Range(-3,3)]
   private float minPitch;
   
   
   
    // Start is called before the first frame update
    void Start()
    {
        audioSource=GetComponent<AudioSource>() ;
        audioSource.pitch=1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySoun(){
        audioSource.pitch=Random.Range(minPitch,maxPitch);
        audioSource.Play();
    }
}
