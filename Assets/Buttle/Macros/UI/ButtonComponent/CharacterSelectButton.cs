using UnityEngine;
using UnityEngine.UI;

class CharacterSelectButton : BaseButton
{
	public AllyComponent character;
	public GameObject button;

	public Slider HPBar;
	public Slider MPBar;

	public async void Prepare(){
			// backgroundManager = new BackgroundManager(character.characterData.selectedImage, character.characterData.deselectedImage, button);
	}
}