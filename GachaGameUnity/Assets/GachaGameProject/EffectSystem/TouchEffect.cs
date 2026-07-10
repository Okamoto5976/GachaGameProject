using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

public class TouchEffect : MonoBehaviour
{
    public static TouchEffect Instance { get; private set; }

    [SerializeField] private VisualEffect m_visualEffectPrefab;
    [SerializeField] Camera m_camera;
    [SerializeField] private Transform m_transform;

    private VisualEffect m_visualEffect;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(this.gameObject);

        m_visualEffect = Instantiate(m_visualEffectPrefab);
    }

    private void Update()
    {
        var current = Mouse.current;

        if (current == null)
        {
            return;
        }

        var leftButton = current.leftButton;

        if (leftButton.wasPressedThisFrame)
        {
            Debug.Log("Pressed left button");
            Vector3 mousePos = current.position.ReadValue();
            mousePos.z = 5.0f;

            Vector3 effectPos = m_camera.ScreenToWorldPoint(mousePos);
            m_visualEffect.transform.position = effectPos;
            m_visualEffect.SendEvent("OnClick");
            
        }
    }
}
