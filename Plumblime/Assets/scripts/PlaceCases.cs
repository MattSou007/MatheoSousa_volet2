using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceCases : MonoBehaviour
{
    // variable générale
    Pipes comPipe;
    SpriteRenderer sr;
    GameObject jeu;
    bool hasWon=false;

    // variable path
    public GameObject caseRight;
    public GameObject caseLeft;
    public GameObject caseUp;
    public GameObject caseDown;

    // variable connection
    public bool connectPathR = false;
    public bool connectPathL = false;
    public bool connectPathU = false;
    public bool connectPathD = false;
    public bool activePath = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        jeu = GameObject.FindWithTag("jeu");

        if(transform.childCount<=1)
        {
             comPipe = GetComponentInChildren<Pipes>();
        }

        if(gameObject.CompareTag("start"))
        {
            activePath = true;
        }
    }

    void Update()
    {
        if(transform.childCount>0)
        {
            if(comPipe.pathRight && caseRight!=null && caseRight.transform.childCount!=0 && caseRight.GetComponentInChildren<Pipes>().pathLeft)
            {
                connectPathR = true;
            }
            else
            {
                connectPathR = false;
            }

            if(comPipe.pathLeft && caseLeft!=null && caseLeft.transform.childCount!=0 && caseLeft.GetComponentInChildren<Pipes>().pathRight)
            {
                connectPathL = true;            
            }
            else
            {
                connectPathL = false;
            }

            if(comPipe.pathUp && caseUp!=null && caseUp.transform.childCount!=0 && caseUp.GetComponentInChildren<Pipes>().pathDown)
            {
                connectPathU = true;
            }
            else
            {
                connectPathU = false;
            }

            if(comPipe.pathDown && caseDown!=null && caseDown.transform.childCount!=0 && caseDown.GetComponentInChildren<Pipes>().pathUp)
            {
                connectPathD = true;
            }
            else
            {
                connectPathD = false;
            }
        }
        else if(transform.childCount==0)
        {
            Pipes comPipe = null;
            connectPathR = false;
            connectPathL = false;
            connectPathU = false;
            connectPathD = false;
        }

        if(connectPathR && caseRight.GetComponent<PlaceCases>().activePath || connectPathL && caseLeft.GetComponent<PlaceCases>().activePath || connectPathU && caseUp.GetComponent<PlaceCases>().activePath || connectPathD && caseDown.GetComponent<PlaceCases>().activePath)
        {
            activePath = true;
        }
        else if(!gameObject.CompareTag("start"))
        {
            activePath = false;
        }

        if(gameObject.CompareTag("end") && activePath)
        {
            if(!hasWon)
            {
                GestionJeu jeuScript = jeu.GetComponent<GestionJeu>();
                jeuScript.onWin();
                hasWon=true;
            }   
            Debug.Log("HAHAHA YOU DID IT!!! WOWIE!!!");
        }
    }

    // fonctions du Drop (Drop, début Hover. fin Hover)
    public void OnDrop(BaseEventData baseEventData)
    {
        // obtenir l'infomation du tuyau déplacer
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        GameObject dragObject = pointerEventData.pointerDrag;
        
        comPipe = dragObject.GetComponent<Pipes>();
        if (comPipe != null && transform.childCount==0 && dragObject.GetComponent<Pipes>().beingDrag)
        {
        dragObject.GetComponent<Pipes>().isPlaced = true;
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0f);

        // Centrer les tuyaux sur la case
        dragObject.transform.SetParent(this.transform);
        dragObject.transform.localPosition = Vector3.zero;
        }
    }

    public void OnHoverBegin(BaseEventData baseEventData)
    {
        // obtenir l'infomation du tuyau déplacer
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        GameObject dragObject = pointerEventData.pointerDrag;

        // indication de quel cases est en sélections
        if (dragObject != null)
        {
            comPipe = dragObject.GetComponent<Pipes>();
            if (comPipe != null && dragObject.GetComponent<Pipes>().beingDrag)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.8f);
            }
             
        }
    }

    public void OnHoverEnd(BaseEventData baseEventData)
    {
        // obtenir l'infomation du tuyau déplacer
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        GameObject dragObject = pointerEventData.pointerDrag;

        // indication de quel cases est en sélections
        if (dragObject != null)
        {
            comPipe = dragObject.GetComponent<Pipes>();
            if (comPipe != null && dragObject.GetComponent<Pipes>().beingDrag == true)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0f);

            }
        }
    }
}
