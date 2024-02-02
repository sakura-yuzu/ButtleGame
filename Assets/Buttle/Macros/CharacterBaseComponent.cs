using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

[SerializeField]
public class CharacterBaseComponent : MonoBehaviour
{

	public CharacterBase characterData;
	public string displayName;
	public int hp;
	public int mp;
	public int attackPower;
	public int defensePower;

	public int speed;

	public Animator anim;

	public CharacterBaseComponent(CharacterBase _characterData){
		setData(_characterData);
	}

	public void setData(CharacterBase _characterData){
		characterData = _characterData;
		displayName = _characterData.displayName;
		hp = _characterData.hp;
		mp = _characterData.mp;
		attackPower = _characterData.attackPower;
		defensePower = _characterData.defensePower;
		speed = _characterData.speed;
	}

	public async UniTask<int> Damaged(int damage){
		hp -= damage;
		anim?.SetBool("Damaged", true);
		await UniTask.DelayFrame(25);
		anim?.SetBool("Damaged", false);
		return hp;
	}

  public async UniTask Death(){
		anim?.SetBool("Death", true);
		await UniTask.DelayFrame(25);
		anim?.SetBool("Death", false);
		Destroy(gameObject);
	}
}