using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using WeaponTypeEnum;

[CreateAssetMenu]
[SerializeField]
public class SkillSetting : ScriptableObject
{
    public int id;                                      //ID
    public string skillName;
    public string description;
    public int requiredPoint;                           // 必要MP
    public int target;                                  // 効果対象　自分、仲間一人、仲間全体、敵一人、敵全体
    public bool acquired;                               // 習得済み
    public int weaponType;                              // このスキルを利用できる武器　あとでenum書く
    public int attributeType;                           // 属性
    public string animationName;                        // 実行時に再生するアニメーション
    public SkillType skillType;
    public enum WeaponEnum
    {
        Rod,                                             // 杖
        Sword,                                           // 剣
        Bow,                                             // 弓
        Spear,                                           // 槍
    }

    public enum AttributeType
    {
        None,                                            // なし
        Fire,                                            // 炎
        Thunder,                                         // 雷
        Ice,                                             // 氷
    }

    public enum SkillType
    {
        Enchant,                                         // 回復とかバフとか
        Attack                                           // 攻撃とかデバフとか
    }

    public void execute(){
        Debug.Log("execute");
    }
}