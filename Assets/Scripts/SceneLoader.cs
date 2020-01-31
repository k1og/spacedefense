using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class SceneLoader : MonoBehaviour
{
    public PlayableDirector playableDirector;
    // public GameObject player;
    // Vector3 playerDesiredPosition;
    // Vector3 cameraDesiredPosition;
    // PlayerMovement playerMovement;

    void Start()
    {
        // player = GameObject.FindGameObjectWithTag("Player");
        // cameraDesiredPosition = new Vector3(0, 0, Camera.main.transform.position.z);
        // playerMovement = player.GetComponent<PlayerMovement>();
        // playerDesiredPosition = new Vector3(0, playerMovement.radius, 0); 
        // playerMovement.enabled = false;
        // player.GetComponentInChildren<ShootingController>().enabled = false;
        // player.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
    }
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    IEnumerator LoadSceneCoroutine(string sceneName)
    {
        // check if scene is not loaded already
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        playableDirector.Play();
        // while(player.transform.position != playerDesiredPosition && Camera.main.transform.position != cameraDesiredPosition)
        // {
        //     player.transform.position = Vector3.Lerp(player.transform.position, playerDesiredPosition, 0.05f);
        //     Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, cameraDesiredPosition, 0.05f);
        //     yield return null;
        // }
        // playerMovement.enabled = true;
        // player.GetComponentInChildren<ShootingController>().enabled = true;
        yield return new WaitForSeconds(3f);
        // GameStateManager
    }
}
