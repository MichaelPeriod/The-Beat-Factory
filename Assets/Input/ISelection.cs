using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelection
{
    //Both pass through world position
    public void OnSelect(Vector2 pos);
    public void OnHover(Vector2 pos);
}
