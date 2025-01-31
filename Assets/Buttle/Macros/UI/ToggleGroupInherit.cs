
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using System.Threading;
using Cysharp.Threading.Tasks;

class ToggleGroupInherit : ToggleGroup
{
	public List<Toggle> toggles;
	public void SetAllTogglesEnable(bool enable)
	{
		toggles.ForEach((Toggle toggle)=>{ toggle.enabled = enable; });
	}

	public string getValue()
	{
		IEnumerable<Toggle> ggles = this.ActiveToggles();
		Toggle toggle = ggles.FirstOrDefault();
		if(toggle){
			return toggle.GetComponent<BaseButton>().value;
		}
		return "";
	}

	public string[] getValues()
	{
		IEnumerable<Toggle> ggles = this.ActiveToggles();
		// Debug.Log(toggles.Count());
		IEnumerable<Toggle> activeToggles = ggles.Where(toggle => toggle.isOn); // FIXME: ここが取れない
		// Debug.Log(activeToggles.Count());
		IEnumerable<string> onToggles = activeToggles.Select(toggle => toggle.GetComponent<BaseButton>().value);
		// Debug.Log(onToggles.Count());
		return onToggles.ToArray();
	}

	public async UniTask selectAsync(CancellationToken cancellationToken)
	{
		await UniTask.WhenAny(toggles
			.Select(toggle => toggle.OnValueChangedAsync(cancellationToken)));
	}

	// public async UniTaskVoid regenerateButtons(IEnumerable<string> buttonName)
	// {
	// 	foreach(Toggle toggle in toggles)
	// 	{
	// 		// トグル全削除して作り直し
	// 	}
	// }
}