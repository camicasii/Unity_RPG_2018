using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextHitGenerator : MonoBehaviour
{
    public TextHit textHit;
    public Range xDefault;
    public Range yDefault;

    private void Start() {
        xDefault=new Range(-1,1);
        yDefault=new Range(-1,1);
    }


    public void createTextHit(TextHit textHit_, string content,
    Transform parent,float size, Color color, Range OffsetX,
    Range OffsetY,float lifeTime )
    {        
        Vector3 offset = new Vector2(Random.Range(OffsetX.Min,OffsetX.Max),
        Random.Range(OffsetY.Min,OffsetY.Max));
        textHit_.lifeTime=lifeTime;
        TextMesh newTexthit = textHit_.GetComponent<TextMesh>();        
        newTexthit.color=color;
        newTexthit.characterSize=size;
        newTexthit.text=content;        
        Instantiate(textHit_,parent.position + offset,Quaternion.identity,parent);
    }
    public void createTextHit(TextHit textHit_, float content,
    Transform parent,float size, Color color, Range OffsetX,
    Range OffsetY,float lifeTime )
    {
       string contentConvert= content.ToString();        
       createTextHit(textHit_,contentConvert,parent,size,color,
       OffsetX,OffsetY,lifeTime);
    }
     public void createTextHit(TextHit textHit_, string content,
    Transform parent,float size, Color color,float lifeTime )
    {        
        Range OffsetX = xDefault;
        Range OffsetY = yDefault;
        createTextHit(textHit_,content,parent,size,color,OffsetX,OffsetY,lifeTime);        
    }
     public void createTextHit(TextHit textHit_, float content,
    Transform parent,float size, Color color,float lifeTime ){        
         string contentConvert= content.ToString(); 
         createTextHit(textHit_,contentConvert,parent,size,color,lifeTime);
    }
     public void createTextHit(string content){        
         createTextHit(textHit,content, transform,0.25f,Color.white,2f);
    }
    public void createTextHit(float content){
        string contentConvert= content.ToString();
        createTextHit(contentConvert);
    }
    public void createTextHit(float content,Transform parent){
    
    createTextHit(textHit,content,parent,0.2f,Color.white,2f);
    }



}
