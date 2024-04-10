using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[ExecuteInEditMode]
public class TeleportationScript : MonoBehaviour
{
   
    [Space(10)]
    [Header("Toggle for the gui on off")]
    public bool GuiOn;


    public ParticleSystem lightning;

    public Light lightningLight;
    
    [Space(10)]
    [Header("The text to Display on Trigger")]
    [Tooltip("To edit the look of the text Go to Assets > Create > GUIskin. Add the new Guiskin to the Custom Skin proptery. If you select the GUIskin in your project tab you can now adjust the Label section to change this text")]
    public string Text = "Turn Back";

    [Tooltip("This is the window Box's size. It will be mid screen. Add or reduce the X and Y to move the box in Pixels. ")]
    public Rect BoxSize = new Rect( 0, 0, 200, 100);


    [Space(10)]
    [Tooltip("To edit the look of the text Go to Assets > Create > GUIskin. Add the new Guiskin to the Custom Skin proptery. If you select the GUIskin in your project tab you can now adjust the font, colour, size etc of the text")]
    public GUISkin customSkin;


    void Update()
    {
        if (GuiOn && GameObject.Find("kirbyBurnScript").GetComponent<BurnScript>().isKirbyBurned && Input.GetKeyDown(KeyCode.F))
        {
            var emission = lightning.emission;
            for (int i = 0; i < 10000; i++)
            {
                float emissionRate = emission.rateOverTime.constant;
                emission.rateOverTime = emissionRate + i/10;
                lightningLight.intensity += i /10;
            }
        }
    }
    
    IEnumerator awaiter()
    {
        yield return new WaitForSeconds(1);
    }

    // if this script is on an object with a collider display the Gui
    void OnTriggerEnter() 
    {
        GuiOn = true;
    }


    void OnTriggerExit() 
    {
        GuiOn = false;
    }

    void OnGUI()
    {

        if (customSkin != null)
        {
            GUI.skin = customSkin;
        }

        if (GuiOn == true && GameObject.Find("kirbyBurningScript").GetComponent<BurnScript>().isKirbyBurned )
        {
            // Make a group on the center of the screen
            GUI.BeginGroup (new Rect ((Screen.width - BoxSize.width) / 2, (Screen.height - BoxSize.height) / 2, BoxSize.width, BoxSize.height));
            // All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.

            GUI.Label(BoxSize, Text);

            // End the group we started above. This is very important to remember!
            GUI.EndGroup ();

        }


    } 
}
