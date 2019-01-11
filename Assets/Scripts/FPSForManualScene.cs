using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPSForManualScene : MonoBehaviour
{
    float deltaTime = 0.0f;
    public float fps;
    public float msec;
 
    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
	}
    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;
        GUIStyle style = new GUIStyle();
        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 50;

#if UNITY_EDITOR      
		 if (fps < 40)
            style.normal.textColor = Color.yellow;
        else
        if (fps < 10)
            style.normal.textColor = Color.red;
        else
            style.normal.textColor = Color.green;
#endif

#if UNITY_STANDALONE      
		 if (fps < 40)
            style.normal.textColor = Color.yellow;
        else
        if (fps < 10)
            style.normal.textColor = Color.red;
        else
            style.normal.textColor = Color.green;
#endif

#if UNITY_ANDROID
 if (fps < 25)
            style.normal.textColor = Color.yellow;
        else
        if (fps < 10)
            style.normal.textColor = Color.red;
        else
            style.normal.textColor = Color.green;
#endif

#if UNITY_IOS
 if (fps < 25)
            style.normal.textColor = Color.yellow;
        else
        if (fps < 10)
            style.normal.textColor = Color.red;
        else
            style.normal.textColor = Color.green;
#endif
        msec = deltaTime * 1000.0f;
        fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }

}