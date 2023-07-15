using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public void SpriteChange(Sprite car)
    {
        GameManager.Instance.carSprite = car; 
    }
}
