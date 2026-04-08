using UnityEngine;
using UnityEngine.EventSystems;

public class Pipes : MonoBehaviour
{
    // variable générale
    Vector3 initialPos;
    Collider2D c2d;
    
    // variable path
    public bool pathRight;
    public bool pathLeft;
    public bool pathUp;
    public bool pathDown;

    // variable Drag & Drop
    public bool beingDrag;
    public bool isPlaced;
    Transform intialeParent;

    void Start()
    {
        // définir variables
        initialPos = transform.position;
        c2d = GetComponent<Collider2D>();
        intialeParent = transform.parent;
    }

    void Update()
    {
        
    }

    // fonctions du Drag (début action, action et fin d'action)
    public void OnBeginDrag(BaseEventData baseEventData)
    {
        beingDrag = true;
        isPlaced=false;

        // position du souris
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector3  posCursor = Camera.main.ScreenToWorldPoint(pointerEventData.position);
        posCursor.z = 0;
        transform.position = posCursor;
    }

    public void OnDrag(BaseEventData baseEventData)
    {
        c2d.enabled = false;

        // position du souris
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector3  posCursor = Camera.main.ScreenToWorldPoint(pointerEventData.position);
        posCursor.z = 0;
        transform.position = posCursor;
    }

    public void OnEndDrag()
    {
        beingDrag = false;
        c2d.enabled = true;

        if(!isPlaced)
        {
            // réinitialiser position de l'object
            transform.position = initialPos;
            transform.SetParent(intialeParent);
        }
    }
}
