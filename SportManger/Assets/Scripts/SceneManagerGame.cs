using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagerGame : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void loadSceneSoccerPlayer()
    {
        PlayerCreator.player = "Donatelo";
        SceneManager.LoadScene(1);
    }
    public void loadSceneBasketBallPlayer()
    {
        PlayerCreator.player = "LeBram";
        SceneManager.LoadScene(1);    
    }
    public void loadSceneTennisPlayer()
    {
        PlayerCreator.player = "Fernandinez";
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
