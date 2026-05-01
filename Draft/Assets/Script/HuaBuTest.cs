using UnityEngine;
using UnityEngine.UI;

public class HuaBuTest : MonoBehaviour
{
    public RawImage HuaBu;         
    public int BiShuaSize = 10;    //笔刷大小 可以改
    private int width, height;
    
    private Texture2D HuaBu_texture;

    private void Awake()
    {
    //    Texture2D tex = (Texture2D)HuaBu.mainTexture;
    //    HuaBu_texture = new Texture2D(tex.width, tex.height, TextureFormat.ARGB32, false);
    //    width = HuaBu_texture.width;
    //     height = HuaBu_texture.height;

    //     HuaBu_texture.Apply();
    //     HuaBu.texture = HuaBu_texture;

    Texture2D originalTex = (Texture2D)HuaBu.mainTexture;
    if (originalTex == null) return;

    // 创建一个新贴图，但这次我们要把原图的像素拷贝过来
    HuaBu_texture = new Texture2D(originalTex.width, originalTex.height, TextureFormat.ARGB32, false);
    
    // 关键：将原图像素拷贝给新图
    HuaBu_texture.SetPixels(originalTex.GetPixels());
    HuaBu_texture.Apply();

    // 赋值给 RawImage
    HuaBu.texture = HuaBu_texture;

      
    }


    // public void SetImagePixel(Vector3 HitPoint, Color color)
    // {
    //     Vector3 InversePoint = HuaBu.transform.InverseTransformPoint(HitPoint);
    //     for(int i = (int)(InversePoint.x - BiShuaSize); i < (int)(InversePoint.x + BiShuaSize); i++)
    //     {
    //         for(int j = (int)(InversePoint.y - BiShuaSize); j < (int)(InversePoint.y + BiShuaSize); j++)
    //         {
    //             HuaBu_texture.SetPixel(i+ HuaBu_texture.width/2, j + HuaBu_texture.height/2, color);
    //         }
    //     }

    //     HuaBu_texture.Apply();

    // }

    public void SetImagePixel(Vector3 HitPoint, Color color)
{
    // 获取组件的 Rect
    RectTransform rect = HuaBu.GetComponent<RectTransform>();
    // 将世界坐标转为本地坐标
    Vector3 localPoint = rect.InverseTransformPoint(HitPoint);
    
    // 归一化到 0-1 (假设 Rect 中心是 pivot)
    float u = (localPoint.x / rect.rect.width) + 0.5f;
    float v = (localPoint.y / rect.rect.height) + 0.5f;

    int pixelX = (int)(u * HuaBu_texture.width);
    int pixelY = (int)(v * HuaBu_texture.height);

    // 绘制笔刷区域
    for(int x = pixelX - BiShuaSize; x < pixelX + BiShuaSize; x++)
    {
        for(int y = pixelY - BiShuaSize; y < pixelY + BiShuaSize; y++)
        {
            if(x >= 0 && x < HuaBu_texture.width && y >= 0 && y < HuaBu_texture.height)
            {
                HuaBu_texture.SetPixel(x, y, color);
            }
        }
    }
    HuaBu_texture.Apply();
}
}