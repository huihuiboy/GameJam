using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour
{
    public Texture2D shoot, move;

    // Start is called before the first frame update
    void Start()
    {
        SetAttackCursor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetmouseCursor()
    {
        Cursor.SetCursor(move, Vector2.zero, CursorMode.Auto);
    }

    public void SetMoveCursor()
    {
        Cursor.SetCursor(move, Vector2.zero, CursorMode.Auto);
    }

    public void SetAttackCursor()
    {
        Cursor.SetCursor(shoot, Vector2.zero, CursorMode.Auto);
    }
}
