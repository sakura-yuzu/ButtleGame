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
abstract class ButtonPanel : MonoBehaviour
{
	public ButtonPanel nextPanel;
	public List<Button> buttons;
	protected CancellationTokenSource m_cancellationTokenSource;
	// Bボタンとかで（プレイヤーの意思で）キャンセルされるやつ
	protected CancellationToken playerCancellationToken;

	protected CancellationToken gameManagerCancellationToken;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			m_cancellationTokenSource?.Cancel();
			m_cancellationTokenSource = null;
		}
	}

	public abstract UniTask<Action> AwaitAnyButtonClickedAsync(CancellationToken cancellationToken);
	public UniTask waitKeyDown(){
		return UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Escape));
	}
	public async UniTask<Action> AwaitAnyButtonClickOrCancelAsync(CancellationToken cancellationToken)
	{
		m_cancellationTokenSource = new CancellationTokenSource();
		playerCancellationToken = m_cancellationTokenSource.Token;

		CancellationTokenSource linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource (gameManagerCancellationToken, playerCancellationToken);

		var (index, result1) = await UniTask.WhenAny(AwaitAnyButtonClickedAsync(linkedTokenSource.Token), waitKeyDown());

		Debug.Log($"index: {index}");
		Debug.Log($"result1: {result1}");

		return result1;
	}

	public void Cancel()
	{
		Debug.Log("キャンセル");
	}
}