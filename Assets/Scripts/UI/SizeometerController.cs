using UnityEngine;
using UnityEngine.UI;

public class SizeometerController : MonoBehaviour
{
    public Image SizeometerImage; 
    public BallSizeController BsC;
    public Sprite RedSprite;
    public Sprite GreenSprite;
    public GameObject Snowball;
    public Slider SizeSlider;

    private float MinSize = 5f;
    private float MaxSize = 20f;
    private float FlipToRed = 15f;

    void Awake()
    {
        SizeSlider.value = 8f;  
    }

    void Start()
    {
        SizeSlider.minValue = MinSize;
        SizeSlider.maxValue = MaxSize;
    }

    void Update()
    {
        SizeSlider.value = Snowball.transform.localScale.x;
        if (SizeSlider.value >= FlipToRed)
        {
            SizeometerImage.sprite = RedSprite;
        }
        else
        {
            SizeometerImage.sprite = GreenSprite;
        }
    }
}
