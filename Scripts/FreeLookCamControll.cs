using System.Collections;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FreeLookCamControll : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Image img;
    [SerializeField] private CinemachineFreeLook cinemachineFreeLook;
    [SerializeField] private Joystick _joystick;
    private string strMouseX = "Mouse X";
    private string strMouseY = "Mouse Y";

    float x;
    float y;

    public void Update()
    {
        if (_joystick.Direction.x != 0)
        {
            x = _joystick.Direction.x;
            cinemachineFreeLook.m_XAxis.m_InputAxisValue += x * 1 * Time.deltaTime;
            //cinemachineFreeLook.m_XAxis.m_InputAxisValue = 0;
        }
        else
            cinemachineFreeLook.m_XAxis.m_InputAxisValue = 0;
        if (_joystick.Direction.y != 0)
        {
            y = _joystick.Direction.y;
            cinemachineFreeLook.m_YAxis.m_InputAxisValue += y * 1 * Time.deltaTime;
            //cinemachineFreeLook.m_YAxis.m_InputAxisValue = 0;
        }
        else
            cinemachineFreeLook.m_YAxis.m_InputAxisValue = 0;
    }

    void Start()
    {
        /*img = GetComponent<Image>();*/
    }

    public void OnDrag(PointerEventData data)
    {
        /*if (RectTransformUtility.ScreenPointToLocalPointInRectangle(img.rectTransform,
            data.position, data.enterEventCamera, out Vector2 posOut))
        {
            cinemachineFreeLook.m_XAxis.m_InputAxisName = strMouseX;
            cinemachineFreeLook.m_YAxis.m_InputAxisName = strMouseY;
        }*/
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        /*cinemachineFreeLook.m_XAxis.m_InputAxisName = null;
        cinemachineFreeLook.m_YAxis.m_InputAxisName = null;

        cinemachineFreeLook.m_XAxis.m_InputAxisValue = 0;
        cinemachineFreeLook.m_YAxis.m_InputAxisValue = 0;*/
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        /*OnDrag(eventData);*/
    }
}