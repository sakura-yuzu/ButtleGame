using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[SerializeField]
public class SkillDatabase : ScriptableObject
{
    public List<Skill> skillList = new List<Skill>();
}
