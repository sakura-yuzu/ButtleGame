using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
class AllyComponent : CharacterBaseComponent
{
  public List<Skill> skills;

	public AllyComponent(Character characterData) : base(characterData)
	{
		skills = characterData.skills;
	}
}