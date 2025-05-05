using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoSceneController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private void Start()
    {
        // Video bitince LevelCompleted fonksiyonunu çağır
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        LevelCompleted();
    }

    private void LevelCompleted()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
