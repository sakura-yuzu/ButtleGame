using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

using Cysharp.Threading.Tasks;

class ButtleManager : MonoBehaviour
{

	public Enemy enemy;
	public List<EnemyClass> enemies;
	public Character[] allies;

	public Transform allyListArea;

	private Vector3[] enemyPosition;

	private CancellationToken cancellationToken;
	public Canvas selectTargetAllyPanel;
	public Canvas selectTargetEnemyPanel;

	private List<GameObject> allyActionPanelList;
	private SelectTargetAllyPanel selectTargetAllyPanelComponent;
	private SelectTargetEnemyPanel selectTargetEnemyPanelComponent;

	private bool ButtleEnd = false;

	async void Awake()
	{
		enemyPosition = new Vector3[]{
			new Vector3(-6,2,2),
			new Vector3(-2,2,2),
			new Vector3(2,2,2),
			new Vector3(6,2,2)
		};
		await Prepare();
		Buttle();
	}

	private async UniTask Prepare()
	{

		for(int i=0;i<4;i++){
			EnemyClass enemyClass = new EnemyClass(enemy);
			enemies.Add(enemyClass);
			var enemyPrefab = await Addressables.LoadAssetAsync<GameObject>(enemy.prefabAddress).Task;
			Vector3 position = enemyPosition[i];
			GameObject enemyObject = Instantiate(enemyPrefab);
			Transform transform = enemyObject.transform;
			transform.position = position;
		}

		selectTargetEnemyPanelComponent = selectTargetEnemyPanel.GetComponent<SelectTargetEnemyPanel>();
		selectTargetEnemyPanelComponent.setEnemies(enemies);
		selectTargetEnemyPanel.gameObject.SetActive(true);

		selectTargetAllyPanelComponent = selectTargetAllyPanel.GetComponent<SelectTargetAllyPanel>();
		selectTargetAllyPanelComponent.setAllies(allies);
		selectTargetAllyPanelComponent.gameObject.SetActive(true);

		allyActionPanelList = new List<GameObject>();
		var allyPrefab = await Addressables.LoadAssetAsync<GameObject>("AllyButton").Task;
		var actionPanelPrefab = await Addressables.LoadAssetAsync<GameObject>("Assets/Buttle/Prefab/Action.prefab").Task;

		foreach (Character character in allies)
		{
			GameObject ally = Instantiate(allyPrefab, allyListArea, false);
			// サイズを指定
			RectTransform sd = ally.GetComponent<RectTransform>();
			sd.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 220);
			sd.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 480);
			// 独自コンポーネント追加
			CharacterSelectButton characterButton = ally.GetComponent<CharacterSelectButton>();
			characterButton.character = character;
			characterButton.Prepare(); // TODO: これキモくね？

			GameObject allyActionPanel = Instantiate(actionPanelPrefab);
			AllyActionPanel allyActionPanelComponent = allyActionPanel.GetComponent<AllyActionPanel>();
			allyActionPanelComponent.character = character;
			allyActionPanelComponent.selectTargetAllyPanel = selectTargetAllyPanel;
			allyActionPanelComponent.selectTargetAllyPanelComponent = selectTargetAllyPanelComponent;
			allyActionPanelComponent.selectTargetEnemyPanel = selectTargetEnemyPanel;
			allyActionPanelComponent.selectTargetEnemyPanelComponent = selectTargetEnemyPanelComponent;
			await allyActionPanelComponent.Prepare();
			allyActionPanelList.Add(allyActionPanel);
		}
	}

	private async UniTaskVoid Buttle()
	{
		cancellationToken = this.GetCancellationTokenOnDestroy();
		do{
			// ユーザーの入力を待つ
			List<Action> actions = await PlayerAction(cancellationToken);
			// 与ダメを計算する
			bool BattleEnd = await Calculate(actions, cancellationToken);
			// 残っているエネミーの攻撃を計算する
			// await EnemyAttack();
			// ユーザーの版
		}while(ButtleEnd);
	}

	private async UniTask<List<Action>> PlayerAction(CancellationToken cancellationToken)
	{
		List<Action> actions = new List<Action>();

		foreach(GameObject allyActionPanel in allyActionPanelList){
			allyActionPanel.GetComponent<Canvas>().enabled = true;
			Action action = await allyActionPanel.GetComponent<AllyActionPanel>().AwaitAnyButtonClickedAsync(cancellationToken);
			allyActionPanel.GetComponent<Canvas>().enabled = false;
			actions.Add(action);
		}

		return actions;
	}

	private async UniTask<bool> Calculate(List<Action> actions, CancellationToken cancellationToken)
	{
		Debug.Log("目印");
		// TODO: キャラクターの素早さを加味する
		foreach(Action action in actions){
			// TODO: HPがゼロになったエネミーを削除する
			switch(action.actionType){
				case Action.Types.Attack:
					Debug.Log("ActionType.Attack");
					action.targetEnemy.hp -= 100;
					action.targetEnemy.Damaged();
					Debug.Log(action.targetEnemy.hp);
					break;
				default:
					Debug.Log("Default");
					break;
			}
		}
		return true;
	}

}