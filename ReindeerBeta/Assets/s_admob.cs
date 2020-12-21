using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class s_admob : MonoBehaviour
{
    InterstitialAd interstitial;
    // Use this for initialization
    void Start()
    {
        //Request an Ad. This gets called once every time the leaderboard scene loads
        RequestInterstitial();
    }

    void Update()
    {
        //Keeps trying to load an ad until it shows one //unless ads are toggled off (player prefs)
        if (interstitial.IsLoaded() &&PlayerPrefs.GetInt("ads") == 1) 
        {
            interstitial.Show();
        }
    }

    public void RequestInterstitial()
    {
        string adUnitId;
        if (Application.isMobilePlatform)
            adUnitId = "ca-app-pub-8441415892213387/8315755751";
        else
            adUnitId = "unexpected_platform";

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);
    }
    /*
    public void DisableAds()
    {
        GameObject.Find("Ads").GetComponent<s_admob>().enabled = false;
    }*/
}
