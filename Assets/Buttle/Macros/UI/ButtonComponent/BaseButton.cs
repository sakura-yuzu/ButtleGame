using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

class BaseButton : MonoBehaviour
{
	public TextMeshProUGUI tmp;

	public string value;

	public GameObject mountedButton;

	public void setText(string text)
	{
		tmp.text = text;
	}
}