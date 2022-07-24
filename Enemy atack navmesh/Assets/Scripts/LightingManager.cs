using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightingManager : MonoBehaviour
{
    //References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    //Variables
    [SerializeField, Range(0, 240)] private float TimeOfDay;
    public Text clockTxt;
    float dakika;
    float saniye;
    //spawner
    [SerializeField] Transform orcSpawnTransform;
    [SerializeField] GameObject OrcGameObject;
    

    private void Update()
    { 

        if (Preset == null)
            return;
        if (Application.isPlaying)
        {
            if (TimeOfDay < 120)
            {
                TimeOfDay += Time.deltaTime;
                TimeOfDay %= 240;
                UpdateLighting(TimeOfDay / 240f);
            }
            else if (TimeOfDay >= 120)
            {
                TimeOfDay += Time.deltaTime*2;
                TimeOfDay %= 240;
                UpdateLighting(TimeOfDay / 240f);
            }
            

        }
        else
        {
            UpdateLighting(TimeOfDay / 240f);
        }

    
        saniye +=Time.deltaTime;
        if (saniye >= 60)
        {
            saniye = 0;
            dakika++;
            // gecici kod
            OrcSpawner();
        }

        clockTxt.text = ((int)dakika + ":" + (int)saniye).ToString();

  

    }

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        if(DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) , 170f, 0));
        }
    }

    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        if(RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if(light.type== LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }


    void OrcSpawner()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(OrcGameObject, orcSpawnTransform.position, transform.rotation);
        }
    }
}
