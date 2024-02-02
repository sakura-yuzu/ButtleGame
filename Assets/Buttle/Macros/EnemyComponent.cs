using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System;
class EnemyComponent : CharacterBaseComponent, IEnemyAttack
{
	public EnemyComponent(Enemy enemyData) : base(enemyData)
	{
	}

	public Action Attack(List<AllyComponent> allies){
		System.Random random = new System.Random();
		int rnd = random.Next(allies.Count);

		Action action = new Action();
		action.targetAlly = allies[rnd];
		action.actionType = Action.Types.Attack;
		action.actioner = this;

		return action;
	}
}