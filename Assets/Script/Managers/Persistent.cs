using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistent : MonoBehaviour
{
  
    // Start is called before the first frame update
    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
    

    private void DontDestroy(){
        DontDestroyOnLoad(this.gameObject);
    }
    
}
