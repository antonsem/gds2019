using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EventButton : Button
{
    public UnityEvent onSelected;

    public override void OnSelect(BaseEventData eventData)
    {
        base.OnSelect(eventData);
        onSelected?.Invoke();
    }
}
