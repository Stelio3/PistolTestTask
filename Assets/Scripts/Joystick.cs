using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    public RectTransform circleArea;
    public RectTransform handle;

    private bool moving = false;
    private Vector2 canvasPos = Vector2.zero;
    private Vector2 origin = Vector2.zero;
    private float areaRadious = 0;
    private Vector2 inputPosition;

    void Start()
    {
        //Events
        //Down
        EventTrigger ZoomInEvents = handle.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry pointerDown = new EventTrigger.Entry();
        pointerDown.eventID = EventTriggerType.PointerDown;
        pointerDown.callback.AddListener(delegate { BeginMove(); });
        ZoomInEvents.triggers.Add(pointerDown);
        //Up
        EventTrigger.Entry pointerUp = new EventTrigger.Entry();
        pointerUp.eventID = EventTriggerType.PointerUp;
        pointerUp.callback.AddListener(delegate { StopMoving(); });
        ZoomInEvents.triggers.Add(pointerUp);

        areaRadious = (circleArea.sizeDelta.x * 0.5f) - (handle.sizeDelta.x * 0.5f);
    }

    void Update()
    {
        if (moving)
        {
            inputPosition = SetInputPosition();
            Vector2 offset = new Vector2(inputPosition.x, inputPosition.y) - new Vector2(origin.x, origin.y);
            Vector2 direction = Vector2.ClampMagnitude(offset, areaRadious);
            handle.position = new Vector2(origin.x + direction.x, origin.y + direction.y);
        }
    }

    private void BeginMove()
    {
        moving = true;
        origin = handle.position;
    }

    private void StopMoving()
    {
        moving = false;
        handle.anchoredPosition = Vector2.zero;
        origin = handle.position;
    }
    private Vector2 SetInputPosition()
    {
        if (Input.touchCount > 0)
            return Input.touches[0].position;
        else
            return Input.mousePosition;
    }
}