using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.AddressableAssets;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
class ButtonPanel : MonoBehaviour
{
	public GameObject selfPanel;
	public GameObject prevPanel;
	public EventSystem eventSystem;
	public List<Button> buttons;
	protected CancellationTokenSource m_cancellationTokenSource;
	// Bボタンとかで（プレイヤーの意思で）キャンセルされるやつ
	protected CancellationToken playerCancellationToken;

	protected CancellationToken gameManagerCancellationToken;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Fire2"))
		{
			Cancel();
		}
	}


	public void Cancel()
	{
		Debug.Log("キャンセル");
		ToggleGroupInherit toggleGroup = prevPanel.GetComponent<ToggleGroupInherit>();
		// 操作不能にしていたパネルのトグルを復活させる
		toggleGroup.SetAllTogglesEnable(true);
		// 選択していたものがOn状態のままでは困るのでOffにする
		Toggle selected = toggleGroup.ActiveToggles().FirstOrDefault();
		selected.isOn = false;
		// eventSystemで前のパネルの選択状態を復元
		// ここでeventSystemを操作しないと十字キーとかで動かせなくなる
		eventSystem.SetSelectedGameObject(selected.gameObject);
		// このパネルを非表示にする
		selfPanel.SetActive(false);
	}
}