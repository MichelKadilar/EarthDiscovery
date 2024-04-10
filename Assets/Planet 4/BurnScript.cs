using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[ExecuteInEditMode]
public class BurnScript : MonoBehaviour
{
   
    [Space(10)]
    [Header("Toggle for the gui on off")]
    public bool GuiOn;

    public GameObject kirby;

    public ParticleSystem ps;
    
    public ParticleSystem lightning;

    public Light fireLight;
    public Light lightningLight;

    public bool isKirbyBurned = false;

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
        if (GuiOn && kirby == null && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(awaiter());
            Text =
                "Congratulations! you have now activated my quantum particle accelerator, you can now return chez toi.";
            var lightningEmission = lightning.emission;
            lightningEmission.rateOverTime = 400;
            lightningLight.intensity = 1f;
            isKirbyBurned = true;
        }
    }

    IEnumerator awaiter()
    {
        fireLight.intensity = 2f;
        var emission = ps.emission;
        emission.rateOverTime = 300;
        yield return new WaitForSeconds(1);
        emission.rateOverTime = 0;
        fireLight.intensity = 0.6f;
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

        if (GuiOn == true && kirby == null)
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
