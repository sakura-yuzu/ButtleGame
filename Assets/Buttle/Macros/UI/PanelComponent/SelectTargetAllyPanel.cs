using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
class SelectTargetAllyPanel : ButtonPanel
{
	public Transform parentPanel;

	private List<AllyComponent> allies;

	void Awake(){
		Prepare();
	}

	public void setAllies(List<AllyComponent> _allies){
		allies = _allies;
	}

	private async UniTask Prepare(){
		var buttonPrefab = await Addressables.LoadAssetAsync<GameObject>("SystemButton").Task;
		foreach(AllyComponent ally in allies)
		{
			buttons.Add(Instantiate(buttonPrefab, parentPanel).GetComponent<Button>());
		}
	}
		public override async UniTask<Action> AwaitAnyButtonClickedAsync(CancellationToken cancellationToken)
    {
			var pushed = await UniTask.WhenAny(buttons
    									.Select(button => button.OnClickAsync(cancellationToken)));
			Action act =  new Action();
			act.targetAlly = allies[pushed];
			return act;
    }
}