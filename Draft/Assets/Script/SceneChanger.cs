using UnityEngine;
using UnityEngine.SceneManagement; // 导入场景管理命名空间

public class SceneChanger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created 
    SceneManager sceneManager; // 场景管理器对象
   
    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); // 加载指定名称的场景
    }
}
