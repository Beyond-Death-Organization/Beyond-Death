using Rewired;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    public FadeComponent FadeComponent;
    private Player player;
    
    private void Start() {
        player = ReInput.players.GetPlayer("Player01");
    }

    private void Update() {
        if(player.GetButtonDown("FadeIn"))
            FadeComponent.StartFadeIn(3);
        else if(player.GetButtonDown("FadeOut"))
            FadeComponent.StartFadeOut(6);
    }
}
