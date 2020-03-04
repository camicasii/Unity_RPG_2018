using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEnemy : MonoBehaviour
{
    private Transform player;
    public float axiX { get{return directionToPlayer.x;}}
    public float axiY { get{return directionToPlayer.y;}}
    public float distance { get{return directionToPlayer.magnitude;}}
    public Vector2 directionToPlayer {get;private set;}



    // Start is called before the first frame update
    void Start()
    {
        getDirectionToPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        player=GameManager.Instance.player.transform; 
        getDirectionToPlayer();
    }
    public void getDirectionToPlayer(){
         directionToPlayer=player.position -transform.position;
    }
}
