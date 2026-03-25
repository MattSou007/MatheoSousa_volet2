using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceCases : MonoBehaviour
{
    // variable générale
    SpriteRenderer sr;
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    // fonctions du Drop (Drop, début Hover. fin Hover)
    public void OnDrop(BaseEventData baseEventData)
    {
        // obtenir l'infomation du tuyau déplacer
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        GameObject dragObject = pointerEventData.pointerDrag;

        dragObject.GetComponent<Pipes>().isPlaced = true;
        sr.color = new Color(sr.color.r, sr.color.g, sr. color.b, 0f);

        // Centrer les tuyaux sur la case
        dragObject.transform.SetParent(this.transform);
        dragObject.transform.localPosition = Vector3.zero;
    }

    public void OnHoverBegin(BaseEventData baseEventData)
    {
        // obtenir l'infomation du tuyau déplacer
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        GameObject dragObject = pointerEventData.pointerDrag;

        // indication de quel cases est en sélections
        if(dragObject!=null && dragObject.GetComponent<Pipes>().beingDrag==true)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr. color.b, 0.8f);
        }
    }

    public void OnHoverEnd(BaseEventData baseEventData)
    {
        // obtenir l'infomation du tuyau déplacer
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        GameObject dragObject = pointerEventData.pointerDrag;

        // indication de quel cases est en sélections
        if(dragObject!=null && dragObject.GetComponent<Pipes>().beingDrag==true)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr. color.b, 0f);
        }
    }
}
