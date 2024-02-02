using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Sprite;
// using WeaponTypeEnum;

[SerializeField]
public class CharacterBase : ScriptableObject
{
  public string displayName;
  public int hp;
  public int mp;
  public int attackPower;
  public int defensePower;
  public int speed;
  // FIXME: なんか嫌
  public Sprite selectedImage;
  public Sprite deselectedImage;

    public string prefabAddress;
}