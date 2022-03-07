using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[System.Serializable]
public class BtnNameEvent : UnityEvent<string>
{
}

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField]
    string btn_name;
    [SerializeField]
    bool pressable;
    [SerializeField]
    float move_height;
    [SerializeField]
    BtnNameEvent action;

    bool isMouseDown = false;
    float init_y;

    void OnMouseDown()
    {
        if(!isMouseDown){
            action.Invoke(btn_name);
            isMouseDown = !isMouseDown;
            if(pressable){
                gameObject.transform.DOMoveY(init_y-move_height, 0.2f);
            }
        }
    }

    void OnMouseUp()
    {
        if(isMouseDown){
            isMouseDown = !isMouseDown;
            if(pressable){
                gameObject.transform.DOMoveY(init_y, 0.2f);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
        init_y = gameObject.transform.position.y;
    }
}
