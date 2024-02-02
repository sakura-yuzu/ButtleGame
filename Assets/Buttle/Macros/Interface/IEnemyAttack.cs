using System.Collections;
using System.Collections.Generic;

interface IEnemyAttack
{
	public Action Attack(List<AllyComponent> allies);
}