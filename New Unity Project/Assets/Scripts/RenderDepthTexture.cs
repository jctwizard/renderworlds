using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderDepthTexture : MonoBehaviour {

    public bool screenshot;
    public Material depthMaterial;
    public Material RGBMaterial;
    public bool depth = true;

	// Use this for initialization
	void OnValidate () {
        Camera.main.depthTextureMode = DepthTextureMode.Depth;

        if (screenshot)
        {
            if (depth)
            {
                ScreenCapture.CaptureScreenshot("Assets/Textures/CameraRenderDepth.png");
            }
            else
            {
                ScreenCapture.CaptureScreenshot("Assets/Textures/CameraRenderRGB.png");
            }

            screenshot = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //method which is automatically called by unity after the camera is done rendering
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (depth)
        {
            //draws the pixels from the source texture to the destination texture
            Graphics.Blit(source, destination, depthMaterial);
        }
        else
        {
            Graphics.Blit(source, destination, RGBMaterial);
        }
    }
}
