using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public CardObject cardObject;
    public Image artwork;

    public virtual void SetCard(CardObject cardObject)
    {
        this.cardObject = cardObject;
        artwork.sprite = cardObject.artwork;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).position -= new Vector3(0, 3, 0);
        }

        OnButtonDown();
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).position += new Vector3(0, 3, 0);
        }

        OnButtonUp();
    }

    protected virtual void OnButtonDown() { }

    protected virtual void OnButtonUp() { }
}
