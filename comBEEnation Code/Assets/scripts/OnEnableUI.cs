using UnityEngine;
using UnityEngine.SceneManagement;

public class OnEnableUI : MonoBehaviour
{
    private Vector3 objectSize;
    public GameObject settingsWindow;
    public GameObject mainMenu;
    public Logic logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake(){
        objectSize = transform.localScale;
    }

    void OnEnable()
    {
        transform.localScale = Vector2.zero;
        LeanTween.scale(gameObject, objectSize, 0.8f).setEaseSpring();
    }

    public void settingsClose(){
        if (SceneManager.GetActiveScene().buildIndex == 1){
            logic.playing = true;
        }
        LeanTween.scale(gameObject, new Vector3(0,0,0),0.5f).setOnComplete(disableSettings);
    }

    public void disableSettings(){
        settingsWindow.SetActive(false);
        transform.localScale = objectSize;
    }

    public void backToMainMenu(){
        SceneManager.LoadScene(0);
        settingsWindow.SetActive(false);
    }

    void Update(){
        if (SceneManager.GetActiveScene().buildIndex == 1){
            logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
            mainMenu.SetActive(true);
        }else{
            mainMenu.SetActive(false);
        }
    }
}
