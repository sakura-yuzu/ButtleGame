using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
class SelectActionPanel : MonoBehaviour
{
	public GameObject selectActionPanel;
	public GameObject selectSkillPanel;
	public GameObject selectItemPanel;
	public GameObject selectTargetEnemyPanel;
	public GameObject selectTargetAllyPanel;

	public ToggleGroupInherit[] panels;

	public BattleManager battleManager;

	public async UniTask<Action> selectAction(CancellationToken cancellationToken)
	{
		// selectActionPanel.SetActive(true);
		// await selectActionPanel.GetComponent<ToggleGroupInherit>().selectAsync(cancellationToken);
		await UniTask.WhenAny(panels
			.Select(panel => panel.selectAsync(cancellationToken)));
		string actionType = selectActionPanel.GetComponent<ToggleGroupInherit>().getValue();
		string skill = selectSkillPanel.GetComponent<ToggleGroupInherit>()?.getValue();
		string item = selectItemPanel.GetComponent<ToggleGroupInherit>()?.getValue();
		// string enemy = selectTargetEnemyPanel.GetComponent<ToggleGroupInherit>()?.getValue();
		string[] enemies = selectTargetEnemyPanel.GetComponent<ToggleGroupInherit>()?.getValues();
		foreach(string enemy in enemies){
			Debug.Log("test: "+enemy);
		}
		// string[] enemies = new string[] {enemy};
		string ally = selectTargetAllyPanel.GetComponent<ToggleGroupInherit>()?.getValue();
		string[] allies = new string[] {ally};
		Debug.Log("action: " + actionType);
		Debug.Log("skill: " + skill);
		Debug.Log("item: " + item);
		// Debug.Log("enemy: " + enemy);
		Debug.Log("ally: " + ally);

		return new Action(
			actionType,
			skill,
			item,
			enemies,
			allies
		);
	}
}