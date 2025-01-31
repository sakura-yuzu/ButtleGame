using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading;
using Cysharp.Threading.Tasks;
public class Creature : MonoBehaviour
{
  public CreatureSetting setting;
  public List<SkillSetting> skills;
  protected string displayName;
  protected int hp;
  protected int mp;
  protected int attackPower;
  protected int defensePower;
  protected int speed;
  protected string prefabAddress;
  protected string description;
  public Animator anim;

	void Start(){
		displayName = setting.displayName;
		hp = setting.hp;
		mp = setting.mp;
		attackPower = setting.attackPower;
		defensePower = setting.defensePower;
		speed = setting.speed;
    prefabAddress = setting.prefabAddress;
    // anim = setting.anim;
	}

	public async UniTask<int> Damaged(int damage){
		hp -= damage;
		anim?.SetBool("Damaged", true);
		await UniTask.Delay(TimeSpan.FromSeconds(1f));
		anim?.SetBool("Damaged", false);
		return hp;
	}

  public async UniTask Death(){
		anim?.SetBool("Death", true);
		await UniTask.Delay(TimeSpan.FromSeconds(1f));
		anim?.SetBool("Death", false);
		Destroy(gameObject);
	}
}