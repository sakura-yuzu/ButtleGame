using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

using TMPro;
class LogPanelComponent : MonoBehaviour
{
	public GameObject textPrefab;
	public Transform textArea;
	public Scrollbar scrollBar;
	void Awake(){
		// var textPrefab = Addressables.LoadAssetAsync<GameObject>("LogText").Task;
		scrollBar.value = 1;
	}

	public void addText(string text){
		GameObject textRow = Instantiate(textPrefab, textArea, false);

		// サイズを指定
		RectTransform sd = textRow.GetComponent<RectTransform>();
		sd.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 50);
		sd.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1920);

		textRow.GetComponent<TextMeshProUGUI>().text = text;
		scrollBar.value = 0;
	}
}