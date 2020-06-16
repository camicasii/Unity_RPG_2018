using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    private static GameManager _instance=null;
    public static GameManager Instance{get{return _instance;} private set{}}
    public Transform playerSpawnPoint;
    //public Transform containerOfProyectile;  
    [HideInInspector]
    public GameObject player;  
    
    
    // Start is called before the first frame update
    private bool change=false;
    private bool oldchange;
    private void Awake() {
        if(_instance !=null && _instance!=this){
            change=!change;            
            Destroy(this.gameObject);    
                  
        }
        else{
        _instance=this;
        DontDestroyOnLoad(this.gameObject);
        player = GameObject.FindGameObjectWithTag("Player");}
        
        
    }
    
    void Start()
    {   
        player.transform.position=playerSpawnPoint.position;
        MusicManager.Instance.playMusic(1);
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void PlayerPosition(Vector3 position){
        player.transform.position=position;
    }
}
