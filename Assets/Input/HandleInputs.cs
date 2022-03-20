using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandleInputs : MonoBehaviour
{
    public Vector3 mousePos;
    public Vector2 mouseToWorldPos;

    public ISelection selectionScript;

    public bool canPlace = true;

    private void Start()
    {
        selectionScript = GetComponent<ISelection>();
        ObjectBank.current.onPlay.AddListener(onSongPlay);
        ObjectBank.current.onStop.AddListener(onSongPause);
    }

    public void onSongPlay(){
        canPlace = false;
    }

    public void onSongPause(){
        canPlace = true;
    }

    public void onMouseMove(InputAction.CallbackContext ctx)
    {
        if(SceneManagement.current.isPlaying && canPlace){
            mousePos = ctx.ReadValue<Vector2>();
            mouseToWorldPos = GetComponent<Camera>().ScreenToWorldPoint(mousePos);

            selectionScript.OnHover(mouseToWorldPos);
        }
    }

    public void onMouseClick(InputAction.CallbackContext ctx)
    {
        if(SceneManagement.current.isPlaying && canPlace)
            if (ctx.started)
                selectionScript.OnSelect(mouseToWorldPos);
    }

    public void onMouseRight(InputAction.CallbackContext ctx)
    {
        if(SceneManagement.current.isPlaying && canPlace)
            if (ctx.started)
                selectionScript.OnCollect(mouseToWorldPos);
    }

    public void onRotate(InputAction.CallbackContext ctx){
        if(SceneManagement.current.isPlaying && canPlace)
            if (ctx.started)
                selectionScript.OnRotate(1);
    }

    public void onEscape(InputAction.CallbackContext ctx){
        if(ctx.started)
            SceneManagement.current.TogglePause();
    }
}
