using UnityEngine;
using UnityEngine.EventSystems;

public class Pipes : MonoBehaviour
{
    // variable générale
    Vector3 initialPos;
    SpriteRenderer sr;
    public GameObject child;
    SpriteRenderer csr;
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
        sr = GetComponent<SpriteRenderer>();
        c2d = GetComponent<Collider2D>();
        csr = child.GetComponent<SpriteRenderer>();
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

        sr.sortingOrder = 5;
        csr.sortingOrder = 4;

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

        sr.sortingOrder = 3;
        csr.sortingOrder = 1;

        if(!isPlaced)
        {
            // réinitialiser position de l'object
            transform.position = initialPos;
            transform.SetParent(intialeParent);
        }
    }
}
