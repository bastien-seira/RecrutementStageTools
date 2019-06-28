using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class RewardedVideoButton : MonoBehaviour, IUnityAdsListener
{

    string gameId = "3203604";
    string placementId = "rewardedVideo";
    bool testMode = true;
    Button button;

    void Start()
    {
        button = GetComponent<Button>();
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

    public void ShowRewardedVideo()
    {
        Advertisement.Show(placementId);
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == this.placementId)
        {
            button.interactable = true;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {

    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.LogWarning("Ads dids error " + message);
    }
}
