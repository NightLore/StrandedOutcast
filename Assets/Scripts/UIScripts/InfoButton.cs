using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InfoButton : MonoBehaviour
{
    private GameObject infoPanel;
    // Start is called before the first frame update
    void Start()
    {
        infoPanel = GameObject.Find("/Canvas/GameScreen/InfoPanel");

        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((data) => { OnPointerEnter(); });
        trigger.triggers.Add(entry);

        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((data) => { OnPointerExit(); });
        trigger.triggers.Add(entry);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter()
    {
        infoPanel.SetActive(true);
    }

    public void OnPointerExit()
    {
        infoPanel.SetActive(false);
    }
}
