using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
class AllyActionPanelComponent : ButtonPanel
{
	public AllyComponent character;
	public Transform panel;
	public Canvas selectTargetAllyPanel;
	public Canvas selectTargetEnemyPanel;
	public SelectTargetAllyPanel selectTargetAllyPanelComponent;
	public SelectTargetEnemyPanelComponent selectTargetEnemyPanelComponent;

	public async UniTask Prepare(){
		var systemButtonPrefab = await Addressables.LoadAssetAsync<GameObject>("ActionButton");

		GameObject button = Instantiate(systemButtonPrefab, panel, false);
		ActionButton buttonComponent = button.GetComponent<ActionButton>();
		buttonComponent.setText("Attack");
		buttonComponent.setType(Action.Types.Attack);
		buttons.Add(button.GetComponent<Button>());

		button = Instantiate(systemButtonPrefab, panel, false);
		buttonComponent = button.GetComponent<ActionButton>();
		buttonComponent.setText("Defence");
		buttonComponent.setType(Action.Types.Defence);
		buttons.Add(button.GetComponent<Button>());

		foreach(Skill skill in character.skills){
			button = Instantiate(systemButtonPrefab, panel, false);
			buttonComponent = button.GetComponent<ActionButton>();
			buttonComponent.setText("Skill");
			buttonComponent.setType(Action.Types.Skill);
			buttons.Add(button.GetComponent<Button>());
		}
	}

	public override async UniTask<Action> AwaitAnyButtonClickedAsync(CancellationToken cancellationToken)
	{
		var pushed = await UniTask.WhenAny(buttons.Select(button => button.OnClickAsync(cancellationToken)));
		Action.Types type = buttons[pushed].GetComponent<ActionButton>().getType();
		Action action;

		switch(type){
			case Action.Types.Attack:
				Debug.Log("攻撃！");
				selectTargetEnemyPanel.enabled = true;
				action = await selectTargetEnemyPanelComponent.AwaitAnyButtonClickOrCancelAsync(cancellationToken);
				selectTargetEnemyPanel.enabled = false;
				action.actionType = Action.Types.Attack;
				action.actioner = character;
				return action;
			case Action.Types.Defence:
				Debug.Log("防御！");
				selectTargetAllyPanel.enabled = true;
				action = await selectTargetAllyPanelComponent.AwaitAnyButtonClickOrCancelAsync(cancellationToken);
				selectTargetAllyPanel.enabled = false;
				action.actionType = Action.Types.Defence;
				action.actioner = character;
				return action;
			case Action.Types.Skill:
				Debug.Log("スキル！");
				// skillPanel.enabled = true;
				// Action act = await skillPanelComponent.AwaitAnyButtonClickOrCancelAsync(cancellationToken);
				// skillPanel.enabled = false;
				// return act;
				break;
		}
		return new Action();
	}
}