using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform player;
    //public Transform camera;
    // Start is called before the first frame update
    void Start()
    {
        //player =GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
      float posX= player.position.x;
      float posY= player.position.y;
      CamMove(posX,posY);
    }

    void CamMove(float x, float y){
        Vector3 newPosition=new  Vector3(x,y,transform.position.z);
        //transform.position=newPosition;
        Camera.main.transform.position=newPosition;
        
    }
}
