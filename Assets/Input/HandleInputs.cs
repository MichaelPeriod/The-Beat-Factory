using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandleInputs : MonoBehaviour
{
    public Vector3 mousePos;
    public Vector2 mouseToWorldPos;

    public ISelection selectionScript;

    private void Start()
    {
        selectionScript = GetComponent<ISelection>();
    }

    public void onMouseMove(InputAction.CallbackContext ctx)
    {
        mousePos = ctx.ReadValue<Vector2>();
        mouseToWorldPos = GetComponent<Camera>().ScreenToWorldPoint(mousePos);

        selectionScript.OnHover(mouseToWorldPos);
    }

    public void onMouseClick(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
            selectionScript.OnSelect(mouseToWorldPos);
    }

    public void onMouseRight(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
            selectionScript.OnCollect(mouseToWorldPos);
    }

    public void onRotate(InputAction.CallbackContext ctx){
        if (ctx.started)
            selectionScript.OnRotate(1);
    }
}
