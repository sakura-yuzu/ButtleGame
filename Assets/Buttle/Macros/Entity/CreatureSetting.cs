using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[SerializeField]
public class CreatureSetting : ScriptableObject
{
  public string displayName;
  public int hp;
  public int mp;
  public int attackPower;
  public int defensePower;
  public int speed;
  public string prefabAddress;
  public string description;
  // public List<Skill> skills;
}