using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour
{
    public Text txtClock;
    DayNightController controller;

    void Awake()
    {
        controller = GameObject.FindGameObjectsWithTag("SunLight")
            .First()
            .GetComponent<DayNightController>();
    }

    // Update is called once per frame
    void Update()
    {
        string dayCycle = controller.IsNight() ? "Night" : "Day";
        this.txtClock.text = $"{controller.getHours()} : {controller.getMinutes()}  --- {dayCycle}";
    }
}
