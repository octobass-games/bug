using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UnlockedCollectable : MonoBehaviour
{
    public Image Image;
    public GameObject Panel;
    public TMPro.TextMeshProUGUI Text;

    public void Render(CollectableData collectable)
    {
        Image.sprite = collectable.sprite;
        Text.text = "Unlocked " + collectable.Name + "!";
        Panel.SetActive(true);
    }

    public void RenderAlreadyUnlocked(CollectableData collectable)
    {
        Image.sprite = collectable.sprite;
        Text.text = collectable.Name + "!";
        Panel.SetActive(true);
    }
}