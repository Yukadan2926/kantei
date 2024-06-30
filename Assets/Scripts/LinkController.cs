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

    //[SerializeField] float fadeSpeed = 2.0f;
    //float t;
    //bool reverse;

    // Start is called before the first frame update
    void Start()
    {
        if (searchBar == null)
        {
            searchBar = GameObject.Find("SearchPanel").GetComponent<SearchBar>();
        }

        image = GetComponent<Image>();
        //t = 0;
        //reverse = true;

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

    // Update is called once per frame
    void Update()
    {
        //Color color = image.color;

        //if (!reverse)
        //{
        //    t += fadeSpeed * Time.deltaTime;
        //}
        //else
        //{
        //    t -= fadeSpeed * Time.deltaTime;
        //}
        //t = Mathf.Clamp(t, 0, 0.5f);
        //color.a = t;

        //image.color = color;
    }

    void Visible(BaseEventData data)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0.5f);
        //reverse = false;
    }

    void Invisible(BaseEventData data)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0.0f);
        //reverse = true;
    }

    void Jump(BaseEventData data)
    {
        searchBar.Jump(page);
    }
}
