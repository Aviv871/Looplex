using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour 
{
	public void quit()
	{
		Application.Quit();
	}

	public void play()
	{
		Fader.faderInstance.FadeTo("Main");
	}
}
