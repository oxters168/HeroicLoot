using UnityEngine;
using UnityHelpers;
using Rewired;

public class PlayerInputBridge : MonoBehaviour
{
    public int playerId = 0;
    private Player player;

    [RequireInterface(typeof(IValueManager))]
    public GameObject controlledObject;
    private IValueManager controlValues;

    void Start()
    {
        player = ReInput.players.GetPlayer(playerId);
        controlValues = controlledObject.GetComponent<IValueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = player.GetAxis("Horizontal");
        float y = player.GetAxis("Vertical");

        controlValues.SetAxis("horizontal", x);
        controlValues.SetAxis("vertical", y);
        controlValues.SetToggle("crossBtn", player.GetButton("Jog"));
        controlValues.SetToggle("triangleBtn", player.GetButton("EnterExitVehicle"));
        controlValues.SetToggle("circleBtn", player.GetButton("Roll"));
        controlValues.SetToggle("squareBtn", player.GetButton("Attack"));
        controlValues.SetToggle("r1Btn", player.GetButton("Sheath"));
        controlValues.SetToggle("l2Btn", player.GetButton("Block"));
        controlValues.SetToggle("r2Btn", player.GetButton("Strafe"));
        controlValues.SetToggle("down", player.GetButton("ToggleAstral"));
    }
}
