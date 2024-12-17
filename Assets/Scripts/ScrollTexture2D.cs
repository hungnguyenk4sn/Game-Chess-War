using UnityEngine;

public class ScrollTexture2D : MonoBehaviour
{
    [SerializeField] float _scrollSpeedX = 0.5f; // Tốc độ cuộn theo trục X
    public float ScrollSpeedX
    {
        set { _scrollSpeedX = value; }
        get { return _scrollSpeedX; }
    }

    [SerializeField] float scrollSpeedY = 0.5f; // Tốc độ cuộn theo trục Y
    private Material material;       // Lưu Material từ Sprite Renderer
    private Vector2 offset;          // Lưu giá trị offset

    void Start()
    {
        // Lấy Material từ Sprite Renderer
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            material = spriteRenderer.material;
            offset = material.mainTextureOffset; // Lưu giá trị offset ban đầu
        }
    }

    void Update()
    {
        if (material != null)
        {
            // Tính toán offset mới và sử dụng % 1 để đảm bảo giá trị luôn trong khoảng [0, 1]
            float offsetX = (offset.x + Time.deltaTime * _scrollSpeedX) % 1;
            float offsetY = (offset.y + Time.deltaTime * scrollSpeedY) % 1;
            offset = new Vector2(offsetX, offsetY);

            // Gán offset vào material
            material.mainTextureOffset = offset;
        }
    }
}
