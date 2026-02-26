using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TransitionController : MonoBehaviour
{
    public GameObject blackScreen;  // 过渡中的黑屏覆盖
    public Text phoneText;          // 显示电话内容的文本
    public AudioClip phoneRing;     // 电话铃声
    public AudioSource audioSource;

    void Start()
    {
        // 开始加载过渡场景（此时你还看不到）
        StartCoroutine(LoadTransitionScene());
    }

    IEnumerator LoadTransitionScene()
    {
        // 异步加载过渡场景（不会阻塞当前场景）
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Studio_black", LoadSceneMode.Additive);

        // 等待直到过渡场景加载完成
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // 过渡场景加载完成后显示黑屏并播放铃声
        blackScreen.SetActive(true);
        audioSource.PlayOneShot(phoneRing);
        yield return new WaitForSeconds(1);  // 等待1秒钟

        // 显示电话内容
        phoneText.text = "My head is hurt, why I can't remember anything?";
        yield return new WaitForSeconds(4);  // 显示5秒钟

        phoneText.text = "你回拨回去，但发现对面电话打不通，只有录音：确认身份。";
        yield return new WaitForSeconds(4);  // 显示5秒钟

        // 隐藏黑屏并切换到房间布局
        blackScreen.SetActive(false);

        // 可以在此时显示房间布局并让玩家开始探索
    }
}
