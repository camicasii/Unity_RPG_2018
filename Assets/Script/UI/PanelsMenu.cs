using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelsMenu : MonoBehaviour
{
    public static PanelsMenu instance{get;private set;}
    private CanvasGroup canvasGroup;

    private bool isOpen;

    private void Awake() {
        if(instance==null){
            instance=this;
        }
    }
    private void Start() {        
        canvasGroup =GetComponent<CanvasGroup>();
        canvasGroup.alpha=0;
    }
    public void OpenClosedPanels()
    {
        if(isOpen) open();
        else closed();        
            
        
    }

    public void open()
    {
            isOpen=!isOpen;
            canvasGroup.alpha=0;
            canvasGroup.blocksRaycasts=false;
            canvasGroup.interactable=false;
            //ajusta el tiempo interno de unity
            //se usa para pausa o camara lenta
            Time.timeScale=1;
    }
    public void closed()
    {
        isOpen=!isOpen;
        canvasGroup.alpha=1;
        canvasGroup.blocksRaycasts=true;
        canvasGroup.interactable=true;
        Time.timeScale=0;
    }
}
