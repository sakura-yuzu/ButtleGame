using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Sprite;
// using WeaponTypeEnum;

// バトル設定データ
[CreateAssetMenu]
[SerializeField]
public class BattleData : ScriptableObject
{
    public List<CreatureSetting> selectedCharacterList;
}