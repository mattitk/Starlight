using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.UIElements;
using UnityEngine.EventSystems; // For Unity's event system

public class CanvasInput : MonoBehaviour
{
private VisualElement canv;
//, button0;

public event Action<Vector2> OnPointerDown, OnPointerMoved;
	private UIDocument uiDocument;
	private void Awake(){
		uiDocument = GetComponent<UIDocument>();
		canv = uiDocument.rootVisualElement.Q<VisualElement>("Canvas");
		canv.RegisterCallback<PointerDownEvent>(OnPointerDownEvent);
		canv.RegisterCallback<PointerMoveEvent>(OnPointerMoveEvent);
		canv.RegisterCallback<PointerUpEvent>(OnPointerUpEvent);
		canv.RegisterCallback<PointerOutEvent>(OnPointerOutEvent);
		//button0.RegisterCallback<ClickEvent>(OnButtonAClicked)
	}
  	private void OnPointerDownEvent(PointerDownEvent evt){}
  	private void OnPointerUpEvent(PointerUpEvent evt){}
  	private void OnPointerMoveEvent(PointerMoveEvent evt){}
  	
  	private void OnPointerOutEvent(PointerOutEvent evt){}
 //	private void OnPointerReleaseEvent(PointerReleaseEvent evt){}
  //	private void OnPointerOutEvent(PointeroutEvent evt){}
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
