using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(TextHitGenerator))]
public class LevelExp : MonoBehaviour
{
    public Image barExp;
    private TextHitGenerator textHitGenerator;
    private Range rangeTextLevelUp= new Range(0,0);
    private int Expcurrent;
    private int ExpNextLevel;
    private float rateExpNivel; //Razon para subir de nivel
    private int poinStab;
    private int level { get; set; }

    public int exp 
    { 
    
    get{return Expcurrent;}
    
    set{
        Expcurrent=value;
        
        if(level>1){
            rateExpNivel=(float)( Expcurrent-CurvaExpAcumulativa(level))/ExpNextLevel;                      
           
            while (rateExpNivel>=1)
            {
                LevelUp();
                
            }
             
        }
        else{
            rateExpNivel=(float)Expcurrent/ExpNextLevel;
            Debug.Log(Expcurrent+"/"+ExpNextLevel+"my rate "+rateExpNivel);
            while (rateExpNivel>=1)
            {
                LevelUp();
                
            }            
        }
        updateExpBar();        
    } }
    // Start is called before the first frame update
    void Start()
    {
        level=1;
        ExpNextLevel=CurvaExp(level);
        textHitGenerator=GetComponent<TextHitGenerator>();
        updateExpBar();
    }


    private int CurvaExp(int nivel)    {

        int exp =Mathf.CeilToInt(Mathf.Log(nivel,3f) + 20);

        return exp;
    }

    private int CurvaExpAcumulativa(int nivel)
    {
        int exp = 0;
        for (int i = 0; i <nivel; i++)
        {
            
            exp+=CurvaExp(++i);
            
        }

        return exp;
    }

    private void LevelUp()
    {
        level++;
        configureNextLevel();        
        textHitGenerator.createTextHit(textHitGenerator.textHit,"new level",
        transform,0.4f,Color.cyan,rangeTextLevelUp,rangeTextLevelUp, 2f);
        rateExpNivel=(float)(Expcurrent-CurvaExpAcumulativa(level))/ExpNextLevel;        

    }

    void configureNextLevel()
    {
        poinStab++;
        ExpNextLevel=CurvaExp(level);


    }


void updateExpBar()
{
    barExp.fillAmount=Mathf.Abs(rateExpNivel);
}
}
