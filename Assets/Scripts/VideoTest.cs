using UnityEngine;
using UnityEngine.Video;
using System.IO;

public class VideoTest : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    private string status;

    void Start()
    {
        GameObject cam = Camera.main.gameObject;
        videoPlayer = cam.AddComponent<VideoPlayer>();

        videoPlayer.renderMode = VideoRenderMode.CameraNearPlane;
        videoPlayer.targetCamera = Camera.main;
        videoPlayer.aspectRatio = VideoAspectRatio.FitVertically;

        videoPlayer.url = Path.Combine(Application.streamingAssetsPath, "video.mp4");
        videoPlayer.isLooping = true;
        videoPlayer.Pause();

        status = "Press to play";
    }

    void OnGUI()
    {
        GUIStyle buttonWidth = new GUIStyle(GUI.skin.GetStyle("button"));
        buttonWidth.fontSize = 18 * (Screen.width / 800);

        if (GUI.Button(new Rect(Screen.width / 16, Screen.height / 16, Screen.width / 3, Screen.height / 8), status, buttonWidth))
        {
            if (videoPlayer.isPlaying)
            {
                videoPlayer.Pause();
                status = "Press to play";
            }
            else
            {
                videoPlayer.Play();
                status = "Press to pause";
            }
        }
    }
}