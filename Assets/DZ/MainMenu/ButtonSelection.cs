using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ButtonSelection : MonoBehaviour
{
    private float _targetPositionY = 30f;
    private float _startPositionY;
    private float _duration = 0.5f;

    private void Start()
    {
        _startPositionY = transform.position.y;
    }

    public void OnPointerEnter()
    {
        transform.DOMoveY(_startPositionY + _targetPositionY, _duration);
    }

    public void OnPointerExit()
    {
        transform.DOMoveY(_startPositionY, _duration);
    }
}
