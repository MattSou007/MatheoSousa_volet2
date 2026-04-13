using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScene : MonoBehaviour
{
    // scenes
    public string sceneIntro = "";
    public string sceneNiveau1 = "";

    public void DemarrerJeu()
    {
        SceneManager.LoadScene(sceneNiveau1);
    }
}
