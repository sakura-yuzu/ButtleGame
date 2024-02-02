using UnityEngine;
using UnityEngine.UI;
class SystemButton : BaseButton
{
	public Sprite selectedImage;
	public Sprite deselectedImage;
	public GameObject targetObject;

	void Awake(){
		backgroundManager = new BackgroundManager(selectedImage, deselectedImage, targetObject);
	}
}