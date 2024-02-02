class Action
{
	public CharacterBaseComponent actioner;
	// public Item item;
	public Skill skill;
	public AllyComponent targetAlly;
	public EnemyComponent targetEnemy;

	public Types actionType;

	public enum Types
	{
		Attack,
		Defence,
		Skill,
		Item
	}
}