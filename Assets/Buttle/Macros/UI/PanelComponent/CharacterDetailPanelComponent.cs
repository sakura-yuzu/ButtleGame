using UnityEngine;
using TMPro;
class CharacterDetailPanelComponent : MonoBehaviour
{
	private CreatureSetting character;

	public TextMeshProUGUI characterName;

	public void setCharacter(CreatureSetting _character){
		character = _character;
		characterName.text = character.displayName;
	}
	public CreatureSetting getCharacter(){
		return character;
	}
}