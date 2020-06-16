using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager _instance=null;
    public static MusicManager Instance{get{return _instance;} private set{}}
    public AudioClip[] music;
    private AudioSource audioSource;
    private void Awake() {
        if(_instance !=null && _instance!=this){                  
            Destroy(this.gameObject);    
                  
        }
        else{
        _instance=this;
        DontDestroyOnLoad(this.gameObject);        
        
        
    }
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource =GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void  playMusic(int index) {
        audioSource.clip=music[index];
        audioSource.Play();
    }
}
