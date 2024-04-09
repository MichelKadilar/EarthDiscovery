using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

public class TricolorLights : MonoBehaviour
{
    public MeshRenderer firstLight;
    public MeshRenderer secondLight;
    public MeshRenderer thirdLight;

    public Color offColor = Color.black;
    public Color onColor = Color.red;
    public Color goColor = Color.green;

    public Light firstLightBulb;
    public Light secondLightBulb;
    public Light thirdLightBulb;

    private void Start()
    {
        SetAllLightsOff();
    }

    public void SetAllLightsOff()
    {
        SetAllLights(offColor);
    }

    public void SetProgress(int number)
    {
        // Shut off all lights first
        SetAllLightsOff();
        if (number == 1)
        {
            firstLightBulb.color = onColor;
            firstLight.materials[0].color = onColor;
        }
        else if (number == 2)
        {
            secondLightBulb.color = onColor;
            firstLightBulb.color = onColor;
            firstLight.materials[0].color = onColor;
            secondLight.materials[0].color = onColor;
        }
        else if (number == 3) SetAllLights(onColor);
        else if (number == 4) SetAllLights(goColor);
    }

    public void SetAllLights(Color color)
    {
        // We need to get the second material on the mesh renderer because 2 materials are applied to it
        // and we want to change the color of the light bulb, not the ring
        firstLight.materials[0].color = color;
        secondLight.materials[0].color = color;
        thirdLight.materials[0].color = color;
        firstLightBulb.color = color;
        secondLightBulb.color = color;
        thirdLightBulb.color = color;
    }
}
