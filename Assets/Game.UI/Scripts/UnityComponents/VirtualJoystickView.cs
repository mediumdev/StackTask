using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystickView : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
{
    [SerializeField]
    private RectTransform joystickTransform;

    [SerializeField]
    private float _dragThreshold = 0.6f;

    [SerializeField]
    private int _dragMovementDistance = 30;

    [SerializeField]
    private int _dragOffsetDistance = 100;
    public Vector3 inputDirection { get; private set; }

    void Awake()
    {
        inputDirection = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 offset = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickTransform, eventData.position, null, out offset);
        offset = Vector3.ClampMagnitude(offset, _dragOffsetDistance) / _dragOffsetDistance;
        joystickTransform.anchoredPosition = offset * _dragMovementDistance;

        inputDirection = CalculateMovementInput(offset);

        EventRegister.RegisterJoysticDragEvent(gameObject, inputDirection);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joystickTransform.anchoredPosition = Vector3.zero;
        inputDirection = Vector3.zero;

        EventRegister.RegisterJoysticDragEvent(gameObject, inputDirection);
    }

    private Vector3 CalculateMovementInput(Vector3 offset)
    {
        float x = Mathf.Abs(offset.x) > _dragThreshold ? offset.x : 0;
        float y = Mathf.Abs(offset.y) > _dragThreshold ? offset.y : 0;
        return new Vector3(x, 0, y);
    }
}