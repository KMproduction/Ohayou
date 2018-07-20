using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using System.IO;

public class gasha_reward : MonoBehaviour
{
    public GameObject scriptbox;
    string json;
    //IOSAdUnit ID
    public string IosUnitId;

    //AndroidAdUnit ID
    public string AndroidUnitId;

    //RewardVideoAd.
    private RewardBasedVideoAd RewardAd = null;

    protected string AdUnitID = null;

    // Start
    void Start()
    {
        requestRewardAd();
    }

    // OnDestroy
    void OnDestroy()
    {
    }

    public bool IsActive { private set; get; }

    //requestRewardMovie Ad。
    private void requestRewardAd()
    {
#if UNITY_ANDROID
    AdUnitID = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
    AdUnitID = IosUnitId;
#else
        AdUnitID = "unexpected_platform";
#endif

        this.RewardAd = RewardBasedVideoAd.Instance;

        RewardAd.OnAdLoaded += OnAdLoaded;
        RewardAd.OnAdFailedToLoad += OnAdLoadFailed;
        RewardAd.OnAdStarted += OnAdStarted;
        RewardAd.OnAdClosed += OnAdClosed;
        RewardAd.OnAdRewarded += OnAdRewarded;
        RewardAd.OnAdLeavingApplication += OnAdLeavingApp;
    }

    public void LoadStart()
    {
        AdRequest request = new AdRequest.Builder().Build();
        this.RewardAd.LoadAd(request, AdUnitID);

        IsActive = true;

#if UNITY_EDITOR
    OnAdRewarded(null, null);
    OnAdClosed(null, null);
#endif
    }

    protected void OnAdLoaded(object _sender, System.EventArgs _args)
    {
        Debug.Log("AdLoaded");
        //Justincase.
        if (RewardAd.IsLoaded() == true)
            RewardAd.Show();
    }

    protected void OnAdLoadFailed(object _sender, AdFailedToLoadEventArgs _args)
    {
        Debug.Log("AdLoadFailed");
        IsActive = true;
    }

    protected void OnAdStarted(object _sender, System.EventArgs _args)
    {
        Debug.Log("AdStarted");
        IsActive = true;
    }

    protected void OnAdClosed(object _sender, System.EventArgs _args)
    {
        Debug.Log("AdClosed");
        IsActive = false;
    }

    protected void OnAdRewarded(object _sender, Reward _args)
    {
        Debug.Log("AdRewarded!!!");

        if (_args != null)
        {
            Debug.Log("AdRewardedRewardType[" + _args.Type + "]");
            Debug.Log("AdRewardedRewardAmount[" + _args.Amount.ToString() + "]");
        }
        json = File.ReadAllText(Application.persistentDataPath + "/data.json");//読み取ってるよ
        json = encryption.DecryptString(json);
        savedata sv = new savedata();
        JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ
        sv._yobi1 = sv._yobi1 + 250;
        json = JsonUtility.ToJson(sv);
        json = encryption.EncryptString(json);
        File.WriteAllText(Application.persistentDataPath + "/data.json", json);//結局これでよかった  
        mypoint mp = scriptbox.GetComponent<mypoint>();
        mp.Load();
        // DailyBonusData.Instance.addSpecialBonusNotice("AD_REWARD_1");

        IsActive = true;
    }

    protected void OnAdLeavingApp(object _sender, System.EventArgs _args)
    {
        Debug.Log("AdLeavingApplication");
        IsActive = false;
    }
}