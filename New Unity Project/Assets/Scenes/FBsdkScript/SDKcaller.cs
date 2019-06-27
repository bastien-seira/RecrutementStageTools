using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;

public class SDKcaller : MonoBehaviour
{

    void Awake()
    {
        if (FB.IsInitialized)
        {
            FB.ActivateApp();
        }
        else
        {
            FB.Init(() => { FB.ActivateApp(); });
        }
    }

    public void TriggerEventParameterless()
    {
        FB.LogAppEvent("Event_parameterless", null);
    }

    public void TriggerEventParams()
    {
        var parameters = new Dictionary<string, object>();
        parameters["valeur"] = 42;
        FB.LogAppEvent("Event_params", null, parameters);
    }

    public void TriggerEventFull()
    {
        var parameters = new Dictionary<string, object>();
        parameters["nom"] = "toto";
        FB.LogAppEvent("Event_full", 12, parameters);
    }

}
