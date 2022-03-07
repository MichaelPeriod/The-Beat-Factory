using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelection
{
    public void ChangeTile(TileVariants tileToChangeTo);

    //Both pass through world position
    public void OnSelect(Vector2 pos);
    public void OnHover(Vector2 pos);

    public void OnCollect(Vector2 pos);

    public void OnRotate(int rotation);
}
