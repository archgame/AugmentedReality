using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button MenuButton;

    //scene buttons
    public GameObject[] SceneButtons;

    private void Start()
    {
        foreach (GameObject button in SceneButtons)
        {
            // Toggle the active state of the objectToToggle
            button.SetActive(false);
        }
    }

    /// <summary>
    /// Turn off Scene Buttons
    /// </summary>
    public void ToggleObject()
    {
        foreach (GameObject button in SceneButtons)
        {
            // Toggle the active state of the objectToToggle
            button.SetActive(!button.activeSelf);
        }
    }

    public void BlaneLoad()
    {
        SceneManager.LoadScene("ARImageTracking_Blane", LoadSceneMode.Single);
    }

    public void FloLoad()
    {
        SceneManager.LoadScene("ARImageTracking_Flo", LoadSceneMode.Single);
    }

    public void GaroLoad()
    {
        SceneManager.LoadScene("ARImageTracking_Garo", LoadSceneMode.Single);
    }

    public void JieunLoad()
    {
        SceneManager.LoadScene("ARImageTracking_Jieun", LoadSceneMode.Single);
    }

    public void MeiLoad()
    {
        SceneManager.LoadScene("ARImageTracking_Mei", LoadSceneMode.Single);
    }

    public void MingxiLoad()
    {
        SceneManager.LoadScene("ARImageTracking_MingXi", LoadSceneMode.Single);
    }

    public void TheaLoad()
    {
        SceneManager.LoadScene("ARImageTracking_Thea", LoadSceneMode.Single);
    }

    public void YifeiLoad()
    {
        SceneManager.LoadScene("ARImageTracking_Yifei", LoadSceneMode.Single);
    }

    public void ZachLoad()
    {
        SceneManager.LoadScene("ARImageTracking_Zach", LoadSceneMode.Single);
    }
}