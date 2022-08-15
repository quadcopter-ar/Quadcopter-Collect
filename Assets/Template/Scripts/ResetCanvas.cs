using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ResetCanvasPos();
    }

    void ResetCanvasPos()
    {
        GameObject canvas = GameObject.Find("Canvas");
        var canvasePos = canvas.GetComponent<RectTransform>();
        Debug.Log("Canvas Pos: " + canvasePos.localPosition);
        canvasePos.localPosition = new Vector3(-15,10,15);
        canvasePos.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        canvasePos.sizeDelta = new Vector2(20,10);
    }
}
