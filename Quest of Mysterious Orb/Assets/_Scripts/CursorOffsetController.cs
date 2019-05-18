using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorOffsetController : MonoBehaviour
{
    [SerializeField]
    private Texture2D texture;
    private void Update() {
       Cursor.SetCursor(texture, new Vector2(0, 4f), CursorMode.Auto);
   }
}
