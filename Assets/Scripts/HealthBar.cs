using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Texture2D emptyTex;
    public Texture2D fullTex;

    private BoxCollider boxCollider;
    private Health health;

    private Rect fullBar; // rectangle for reuse
    public GUIStyle style;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        health = GetComponent<Health>();
        fullBar = new Rect(0, 0, GameSettings.healthBarSize.x, GameSettings.healthBarSize.y);

        // Style is set through Unity
        //style = new GUIStyle();
        //style.alignment = TextAnchor.MiddleCenter;
        //style.normal.textColor = new Color(1, 1, 1, 0.5f);
        //style.fontStyle = FontStyle.Bold;
        //style.font = Font.CreateDynamicFontFromOSFont("Margarine-Regular", 0);
    }

    void Update()
    {

    }

    void OnGUI()
    {
        Vector3 position = transform.position; // get current position
        position.y += boxCollider.size.y * transform.localScale.y; // move to top of object
        Vector2 targetPos = Camera.main.WorldToScreenPoint(position); // convert to screen coordinates

        //draw the background rectangle:
        GUI.BeginGroup(new Rect(targetPos.x - GameSettings.healthBarSize.x / 2, Screen.height - targetPos.y, GameSettings.healthBarSize.x, GameSettings.healthBarSize.y));
        style.normal.background = emptyTex; // Fill background
        GUI.Box(fullBar, health.hp + "/" + health.maxHp, style);

        //draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, GameSettings.healthBarSize.x * health.hp / health.maxHp, GameSettings.healthBarSize.y));
        style.normal.background = fullTex;
        GUI.Box(fullBar, health.hp + "/" + health.maxHp, style);
        GUI.EndGroup();
        GUI.EndGroup();
    }
}
