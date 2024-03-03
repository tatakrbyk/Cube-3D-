
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class TouchSlider : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public UnityAction OnPointerDownEvent;
    public UnityAction<float> OnPointerDragEvent;
    public UnityAction OnPointerUpEvent;

    private Slider uiSlider;

    private void Awake()
    {
        uiSlider = GetComponent<Slider>();
        uiSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (OnPointerDownEvent != null)
            OnPointerDownEvent.Invoke();

        if (OnPointerDragEvent != null)
            OnPointerDragEvent.Invoke(uiSlider.value);
    }

    private void OnSliderValueChanged(float value)
    {
        if(OnPointerDragEvent != null)
            OnPointerDragEvent.Invoke(value);
       
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (OnPointerUpEvent != null)
            OnPointerUpEvent.Invoke();

        // reset
        uiSlider.value = 0f;
    }

    private void OnDestroy()
    {
        // to avoid memory leaks
        uiSlider.onValueChanged.RemoveListener(OnSliderValueChanged);
    }
}


