using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Reflection;
using System.Linq;

using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Cysharp.Threading.Tasks;

class BattleManager : MonoBehaviour
{
	private List<Creature> enemies = new List<Creature>();
	private List<Character> allies = new List<Character>();
	public BattleData battleData;
	public SelectActionPanel selectActionPanel;
	public GameObject selectSkillPanel;
	public GameObject selectItemPanel;
	public GameObject selectTargetEnemyPanel;
	public GameObject selectTargetAllyPanel;
	public GameObject characterStatusPanel;

	// private Vector3[] enemyPosition;

	private bool BattleContinue = true;
	private CancellationToken cancellationToken;

	async void Awake()
	{
		// enemyPosition = new Vector3[]{
		// 	new Vector3(-6,2,2),
		// 	new Vector3(-2,2,2),
		// 	new Vector3(2,2,2),
		// 	new Vector3(6,2,2)
		// };
		await Prepare();
		Battle();
	}

	private async UniTask Prepare()
	{
		// logPanelComponent = logPanel.GetComponent<LogPanelComponent>();
		// TODO: エネミーの数が現在固定
		// for (int i = 0; i < 4; i++)
		// {
		// 	var enemyPrefab = await Addressables.LoadAssetAsync<GameObject>(enemy.prefabAddress).Task;
		// 	Vector3 position = enemyPosition[i];
		// 	GameObject enemyObject = Instantiate(enemyPrefab);
		// 	Transform transform = enemyObject.transform;
		// 	transform.position = position;
		// 	Creature enemyComponent = enemyObject.GetComponent<Creature>();
		// 	enemies.Add(enemyComponent);
		// }

		foreach (CreatureSetting character in battleData.selectedCharacterList)
		{
			var characterPrefab = await Addressables.LoadAssetAsync<GameObject>(character.prefabAddress).Task;
			GameObject ally = Instantiate(characterPrefab);
			Character allyComponent = ally.GetComponent<Character>();
			allies.Add(allyComponent);
		}
	}

	private async UniTaskVoid Battle()
	{
		cancellationToken = this.GetCancellationTokenOnDestroy();
		do
		{
			Character actioner = allies[0]; // TODO
			// IEnumerable<string> skillNameList = actioner.skills.Select(x => x.skillName);
			// selectSkillPanel.GetComponent<ToggleGroupInherit>().regenerateButtons(skillNameList);
			Action action = await selectActionPanel.selectAction(cancellationToken);
			// Debug.Log(actioner);
			actioner.execute(action);
		} while (BattleContinue);
		SceneManager.LoadScene("ResultScene");
	}
}