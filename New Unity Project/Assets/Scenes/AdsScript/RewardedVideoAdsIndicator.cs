using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class RewardedVideoAdsIndicator : MonoBehaviour, IUnityAdsListener
{

    string gameId = "3203604";
    string placementId = "rewardedVideo";
    bool testMode = true;
    RawImage image;

    void Start()
    {
        image = GetComponent<RawImage>();
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("Ads failed to finish because an error occured");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == this.placementId)
        {
            image.color = Color.green;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        image.color = Color.red;
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.LogWarning("Ads dids error " + message);
    }
}
