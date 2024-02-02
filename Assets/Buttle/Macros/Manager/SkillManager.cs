using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class SkillManager : MonoBehaviour
{
    protected SkillDatabase skillDatabase;

    public SkillManager(SkillDatabase _skillDatabase){
        skillDatabase = _skillDatabase;
    }

    public void AddSkillData(Skill skill)
    {
        skillDatabase.skillList.Add(skill);
    }

    public List<Skill> getSkillListWithConditions(Dictionary<string, string> conditions)
    {
        return skillDatabase.skillList;
    }

    public List<Skill> getAll()
    {
        return skillDatabase.skillList;
    }
}
