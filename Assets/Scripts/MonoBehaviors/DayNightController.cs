using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manage the time in the game, and the sun. Keep the current phase (Day/Night)
/// </summary>
public class DayNightController : MonoBehaviour
{
    public Light sun;
    public float dayDuration = 120f;
    public AudioClip nightSound;
    public AudioClip daySound;
    public float volume;
    private AudioSource source;

    float sunInitialIntensity;

    public float currentTimeOfDay = 0;

    void Start()
    {
        source = GetComponent<AudioSource>();
        sunInitialIntensity = sun.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSun();

        if (getHours() == 6 && getMinutes() == 0)
            source.PlayOneShot(this.daySound);
        if (getHours() == 18 && getMinutes() == 0)
            source.PlayOneShot(this.nightSound);

        currentTimeOfDay += (Time.deltaTime / dayDuration);

        if (currentTimeOfDay >= 1)
            currentTimeOfDay = 0;
    }

    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        float intensityMultiplier = 1;
        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f)
        {
            intensityMultiplier = 0;
        }
        else if (currentTimeOfDay <= 0.25f)
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }
        else if (currentTimeOfDay >= 0.73f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
        }

        sun.intensity = sunInitialIntensity * intensityMultiplier;
    }

    public float getHours()
    {
        return Mathf.Floor(this.currentTimeOfDay * 24);
    }

    public float getMinutes()
    {
        float currentHour = this.currentTimeOfDay * 24;
        return Mathf.Floor((currentHour - Mathf.Floor(currentHour)) * 60);
    }

    private void playNightSound()
    {

    }

    private void playDaySound()
    {

    }

    public bool IsNight()
    {
        return getHours() < 6 || getHours() > 18;
    }
}
