using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Sprite;
// using WeaponTypeEnum;

[CreateAssetMenu]
[SerializeField]
public class Character : CharacterBase
{
    public int id;                                      //ID
    public Sprite image;

    public List<Skill> skills;

}