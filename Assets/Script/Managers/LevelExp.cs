using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExp : MonoBehaviour
{
    private int Expcurrent;
    private int ExpNextLevel;
    private float rateExpNivel; //Razon para subir de nivel
    private int level { get; set; }

    public int exp 
    { 
    
    get{return Expcurrent;}
    
    set{
        Expcurrent=value;
    } }
    // Start is called before the first frame update
    void Start()
    {

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
            exp+=CurvaExp(i);
        }

        return exp;
    }

    private void LevelUp()
    {

    }

    void configureNextLevel()
    {

    }


}
