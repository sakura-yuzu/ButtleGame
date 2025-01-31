using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
class BackgroundButton : BaseButton, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
	public BackgroundManager backgroundManager;

	void Awake()
	{
		backgroundManager = mountedButton.GetComponent<BackgroundManager>();
	}

// イベントハンドラもvirtual化できるのおもろ
	public virtual void OnSelect(BaseEventData e)
	{
		backgroundManager.select();
		// soundManager.Play();
	}

	public void OnDeselect(BaseEventData e)
	{
		backgroundManager.deselect();
	}

	public void OnPointerEnter(PointerEventData e)
	{
		backgroundManager.select();
	}

	public void OnPointerExit(PointerEventData e)
	{
		backgroundManager.deselect();
	}
}