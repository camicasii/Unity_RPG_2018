using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(TextHitGenerator))]
public class LevelExp : MonoBehaviour
{
    public ButtonAtributes[] buttonsAttributes;
    public Image barExp;
    private TextHitGenerator textHitGenerator;
    private Range rangeTextLevelUp= new Range(0,0);
    private int Expcurrent;
    private int ExpNextLevel;
    private float rateExpNivel; //Razon para subir de nivel
    public int poinStab{
        get{return pointAttributes;}        
        private set{}
     }
    private int pointAttributes;    

    
    public Attributes attributesPlayer;
    private Health health;
    
    private PlayerController player;
    private int level_=1;
    public int level { get{return level_;} set{level_ +=value;} }

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
            //Debug.Log(Expcurrent+"/"+ExpNextLevel+"my rate "+rateExpNivel);
            while (rateExpNivel>=1)
            {
                LevelUp();
                
            }            
        }
        updateExpBar();    
        updatePanelAttributes();
    } }
    // Start is called before the first frame update
    

    private void Start() {
        
        Debug.Log(level+"safasdfasfasdfsd");
        ExpNextLevel=CurvaExp(level);
        textHitGenerator=GetComponent<TextHitGenerator>();
        player = GetComponent<PlayerController>();        
        health  = GetComponent<Health>();        
        updateExpBar();
        CallButtonsAttrbutes();
        updatePanelAttributes();
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
        
        pointAttributes++;
        ExpNextLevel=CurvaExp(level);
        CallButtonsAttrbutes();
    }


void updateExpBar()
{
    barExp.fillAmount=Mathf.Abs(rateExpNivel);
}

public void subtractAtributes(){
    pointAttributes--;
    updatePanelAttributes();
    CallButtonsAttrbutes();
    
}

private void CallButtonsAttrbutes(){
    for (int button = 0; button < buttonsAttributes.Length; button++)
    {
        buttonsAttributes[button].isActivate(pointAttributes);
    }

/*
//foreach no es recomendable usar porque en caso de sel llamada en el update genera basura en la memoria
//reduciendo el performans del juego, puede ser usado en caso de que app sea pequeña.
    foreach (var item in buttonsAttributes)
    {
        item.isActivate(pointAttributes);
    }
    */
}
private void updatePanelAttributes(){    
    PanelsAttributes.Instance.updateTextAttributes(player.attributesPlayer,health,this);
}



}
