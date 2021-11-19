using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class videoPlay : MonoBehaviour
{
    // Texture to Output Video
    public RenderTexture outputTexture;

    // Video Vlip to Import
    public VideoClip clip;

    // Video Loop
    public bool loop;

    // Video Player
    private VideoPlayer videoPlayer;
    private VideoSource videoSource;

    void Start()
    {
        Application.runInBackground = true;
        StartCoroutine(playVideo());
    }

    private IEnumerator playVideo() {
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        videoPlayer.playOnAwake = false;

        // Set Video Player Source to Clip
        videoPlayer.source = VideoSource.VideoClip;
        videoPlayer.clip = clip;

        // Set Player Properties
        videoPlayer.isLooping = loop;
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.RenderTexture;

        // Set Output
        videoPlayer.targetTexture = outputTexture;

        // Prepare Video
        videoPlayer.Prepare();

        while (!videoPlayer.isPrepared) {
        yield return null;
        }

        // Play Video
        videoPlayer.Play();

        while (videoPlayer.isPlaying) {
        yield return null;
        }
    }
}
