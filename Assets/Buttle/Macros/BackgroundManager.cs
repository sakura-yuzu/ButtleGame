using UnityEngine;
using UnityEngine.UI;
class BackgroundManager
{
	public Sprite selectedImage;
	public Sprite deselectedImage;
	public GameObject targetObject;

	public BackgroundManager(Sprite _selectedImage, Sprite _deselectedImage, GameObject _targetObject){
		this.selectedImage = _selectedImage;
		this.deselectedImage = _deselectedImage;
		this.targetObject = _targetObject;
	}

	public void select(){
		targetObject.GetComponent<Image>().sprite = selectedImage;
	}

	public void deselect(){
		targetObject.GetComponent<Image>().sprite = deselectedImage;
	}
}