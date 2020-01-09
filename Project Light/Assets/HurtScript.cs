using UnityEngine;
using UnityEngine.UI;

public class HurtScript : MonoBehaviour
{
    Image image;
    public MovementScript player;
    Color color;


    private void Start()
    {
        image = gameObject.GetComponent<Image>();
        color = image.color;
    }


    private void Update()
    {
        if((player.health >= 80 && player.health <= 100) || player.health <= 0)
            Unharmed();
        if (player.health >= 50 && player.health < 80)
            LightlyInjured();
        if (player.health >= 20 && player.health < 50)
            ModeratelyInjured();
        if (player.health >= 1 && player.health < 20)
            GravelyInjured();
    }

    private void Unharmed()
    {
        color.a = 0;
        image.color = color;
    }

    private void LightlyInjured()
    {
        color.a = Mathf.Lerp(0.05f, 0.2f, Mathf.PingPong((Time.time / 2), 1));
        image.color = color;
    }

    private void ModeratelyInjured()
    {
        color.a = Mathf.Lerp(0.15f, 0.3f, Mathf.PingPong((Time.time / 2), 1));
        image.color = color;
    }
    private void GravelyInjured()
    {
        color.a = Mathf.Lerp(0.25f, 0.4f, Mathf.PingPong((Time.time / 2), 1));
        image.color = color;
    }
}
