using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;


public class AdMob : MonoBehaviour
{

    private BannerView bannerView;

    void Start()
    {
        //ページの読み込みと同時にバナーを作成
        RequestBanner();
    }

    void Update()
    {

    }

    //バナーを作成
    private void RequestBanner()
    {
#if UNITY_EDITOR
        string adUnitId = "ca-app-pub-3223134923583056/5418931575";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-3223134923583056/5418931575";
#elif UNITY_IPHONE
        string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        //AdRequest request = new AdRequest.Builder().Build();

        //Create a test ad request.
        AdRequest request = new AdRequest.Builder()
        .AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
        .AddTestDevice("ca-app-pub-3940256099942544/6300978111")  // My test device.
        .Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

    //バナー表示の停止
    public void StopBanner()
    {
        bannerView.Hide();
        bannerView.Destroy();
    }
}