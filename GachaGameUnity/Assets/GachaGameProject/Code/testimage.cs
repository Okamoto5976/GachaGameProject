using UnityEngine;
using UnityEngine.UI;

public class testimage : MonoBehaviour
{
    [SerializeField] private Texture2D m_texture;

    [SerializeField] private Image m_renderer;

    public void OnClickCutImage()
    {
        Sprite sprite = Sprite.Create(
            m_texture,
            new Rect((m_texture.width - 300) / 2, 0, 300, m_texture.height),
            new Vector2(0.5f, 0.5f)
            );

        m_renderer.sprite = sprite;
    }

    public void OnViewImage(Texture2D texture)
    {
        Sprite sprite = Sprite.Create(
            texture,
            new Rect((texture.width - 300) / 2, 0, 300, texture.height),
            new Vector2(0.5f, 0.5f)
            );

        m_renderer.sprite = sprite;
    }
}
