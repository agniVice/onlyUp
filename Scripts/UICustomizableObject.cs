using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Assets
{
    public class UICustomizableObject : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        public int Id;
        [SerializeField] private UICustomizer _customizer;
        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;//Input.GetTouch(0).position;
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            _customizer.SaveCustomization();
        }
    }
}