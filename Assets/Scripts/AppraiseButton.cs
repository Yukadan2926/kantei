using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppraiseButton : MonoBehaviour
{
    public enum Type
    {
        Real,
        Fake,
    }

    public Type type;

    // Start is called before the first frame update
    void Start()
    {
        GameObject manager = GameObject.Find("Manager");
        BaseEvent baseEvent = manager.GetComponent<BaseEvent>();
        StageManager stageManager = manager.GetComponent<StageManager>();
        SceneLoader sceneLoader = manager.GetComponent<SceneLoader>();
        PanelLoader panelLoader = manager.GetComponent<PanelLoader>();

        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => { baseEvent.EndingEvent(type == Type.Real); });
        button.onClick.AddListener(() => { stageManager.Judge(type == Type.Real); });
        button.onClick.AddListener(() => { sceneLoader.UnLoadScene("Appraise"); });
        button.onClick.AddListener(() => { sceneLoader.UnLoadScene("SearchScreen"); });

        panelLoader.UnloadPanel(transform.parent.gameObject);
    }
}
