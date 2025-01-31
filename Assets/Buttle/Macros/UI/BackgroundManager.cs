using UnityEngine;
using UnityEngine.UI;
class BackgroundManager : MonoBehaviour
{
	public Sprite selectedImage;
	public Sprite deselectedImage;
	public GameObject targetObject;

	public void setData(Sprite _selectedImage, Sprite _deselectedImage, GameObject _targetObject){
		this.selectedImage = _selectedImage;
		this.deselectedImage = _deselectedImage;
		this.targetObject = _targetObject;

		targetObject.GetComponent<Image>().sprite = deselectedImage;
	}

	public void select(){
		targetObject.GetComponent<Image>().sprite = selectedImage;
	}

	public void deselect(){
		targetObject.GetComponent<Image>().sprite = deselectedImage;
	}
}