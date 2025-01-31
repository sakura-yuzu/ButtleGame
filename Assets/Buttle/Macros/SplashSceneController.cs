using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
class SplashSceneController : MonoBehaviour
{
	public Button gameStartButton;

	void Awake(){
		gameStartButton.onClick.AddListener(()=>{
			SceneManager.LoadScene("SettingScene");
		});
	}
}