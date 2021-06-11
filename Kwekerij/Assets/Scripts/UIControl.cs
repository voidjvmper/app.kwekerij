using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Shop.Events;

public class UIControl : MonoBehaviour
{
    [SerializeField] private Slider soilClay;
    [SerializeField] private Slider soilSilt;
    [SerializeField] private Slider soilSand;
    [SerializeField] private Slider soil_pH;

    [SerializeField] private Slider patchSunHours;
    [SerializeField] private Slider patchSunStrength;
    [SerializeField] private Button plot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePatch()
    {
        PatchArgs args = new PatchArgs(Mathf.CeilToInt(patchSunHours.value), Mathf.CeilToInt(patchSunStrength.value));
        EventQueue.QueueEvent(EventQueue.EventType.Patch_Update, this, args);

        
    }

    public void CalculateClay(bool pDisplayUpdate = false)
    {
        CalculateSoil(soilClay.value, 0, pDisplayUpdate);
    }

    public void CalculateSilt(bool pDisplayUpdate = false)
    {
        CalculateSoil(soilSilt.value, 1, pDisplayUpdate);
    }

    public void CalculateSand(bool pDisplayUpdate = false)
    {
        CalculateSoil(soilSand.value, 2, pDisplayUpdate);
    }

    public void UpdateSoil_pH()
    {
        UpdateSoil(new Vector3(soilClay.value, soilSilt.value, soilSand.value), soil_pH.value);
    }

    public void CalculateSoil(float pValue, int pOffset, bool pDisplayUpdate)
    {
        
            float[] modifiers =   { pValue * 1.0f,
                                100.0f - pValue,
                                100.0f - (pValue / 2.0f)
                              };

        const int VECTOR_DIMENSIONS = 3;
        Vector3 newSoilComposition = new Vector3();/* (modifiers[pOffset % VECTOR_DIMENSIONS],
                                                 modifiers[pOffset + 1 % VECTOR_DIMENSIONS],
                                                 modifiers[pOffset + 2 % VECTOR_DIMENSIONS]);*/

        for (int i = 0; i < VECTOR_DIMENSIONS ; i++)
        {
            newSoilComposition[(pOffset + i) % VECTOR_DIMENSIONS] = modifiers[i];
        }

        //Gets around the update to the slider's value firing another OnValueChanged event, looping the process
        //if (pDisplayUpdate)
        //{
            UpdateSoil(newSoilComposition, soil_pH.value);
        //}
    }

    public void UpdateSoil(Vector3 pSoilComposition, float pPH)
    {
        soilClay.value = pSoilComposition.x;
        soilSilt.value = pSoilComposition.y;
        soilSand.value = pSoilComposition.z;

        //SoilArgs args = new SoilArgs(new Vector4(pSoilComposition.x, pSoilComposition.y, pSoilComposition.z, pPH));
        SoilArgs args = new SoilArgs(new Vector4(soilClay.value, soilSilt.value, soilSand.value, pPH));
        EventQueue.QueueEvent(EventQueue.EventType.Soil_Update, this, args);
    }

    public void UpdateSun()
    {
        SunArgs args = new SunArgs(Mathf.CeilToInt(patchSunHours.value), Mathf.CeilToInt(patchSunStrength.value));
        EventQueue.QueueEvent(EventQueue.EventType.Sun_Update, this, args);
    }
}
