using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class InfoText : MonoBehaviour
{
    public string info;
    protected TextMeshProUGUI recipeText;
    protected static bool textLock;
    // Start is called before the first frame update
    void Start()
    {
        recipeText = GameObject.Find("/Canvas/GameScreen/InfoPanel/RecipeText").GetComponent<TextMeshProUGUI>();

        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((data) => { LockInfo(); });
        trigger.triggers.Add(entry);

        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((data) => { UnlockInfo(); });
        trigger.triggers.Add(entry);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LockInfo()
    {
        if (!textLock)
        {
            textLock = true;
            UpdateInfo();
        }
    }

    public virtual void UpdateInfo()
    {
        recipeText.text = info;
    }

    private void UnlockInfo()
    {
        textLock = false;
    }
}
