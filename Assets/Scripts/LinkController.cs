using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LinkController : MonoBehaviour
{
    static SearchBar searchBar;
    [SerializeField] PageManager page;

    Image image;

    void Start()
    {
        if (searchBar == null)
        {
            searchBar = GameObject.Find("SearchPanel").GetComponent<SearchBar>();
        }

        image = GetComponent<Image>();

        EventTrigger trigger = gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener(Visible);
        trigger.triggers.Add(entry);

        trigger = gameObject.AddComponent<EventTrigger>();
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener(Invisible);
        trigger.triggers.Add(entry);

        trigger = gameObject.AddComponent<EventTrigger>();
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener(Jump);
        trigger.triggers.Add(entry);
    }

    void Visible(BaseEventData data)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0.5f);
    }

    void Invisible(BaseEventData data)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0.0f);
    }

    void Jump(BaseEventData data)
    {
        searchBar.Jump(page);
    }
}
