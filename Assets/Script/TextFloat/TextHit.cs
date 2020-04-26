using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHit : MonoBehaviour
{
    
    public float lifeTime=1f;
    public float distanceUp=2;
    public TextMesh textMesh;
    public float timeInitHide;    
    public Color color;
    public string sortingLayer="TEXT";
    private float currentDistance=0;
    private bool hiding;
    private Vector3 movementVertical;
    private float valueUp=0.1f;

     
     
    // Start is called before the first frame update
//    public MeshRenderer meshRenderer;
    void Start()
    {
        GetComponent<Renderer>().sortingLayerName=sortingLayer;
        //tiene el mismo efecto que la linea anterior
        //GetComponent<MeshRenderer>().sortingLayerName=sortingLayer;
        textMesh = GetComponent<TextMesh>();
        movementVertical =new Vector3(0,valueUp);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentDistance<distanceUp){
            transform.localPosition += movementVertical;
            currentDistance +=  valueUp;
        }  
        else
        {
            if(hiding==false)
            {
                hiding=true;
                Destroy(gameObject,lifeTime);
                StartCoroutine(Hiding());
                
            }
            
        }     
    }
    IEnumerator Hiding(){
        Color currentColor = textMesh.color;
        //Razon entre el alfa y el tiempo de vida 
        //(1/lifeTime)*Time.deltaTime
        for (float alpha = 1 ; alpha > 0; alpha-=((1/lifeTime)*Time.deltaTime))
        {
            currentColor.a=alpha;    
            textMesh.color=currentColor;        
            yield return new WaitForEndOfFrame();
        }
    }
}
