using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using System.IO;

public class sv_reward : MonoBehaviour
{
    string json;
    public GameObject scriptbox;
    public GameObject AdButton;
    public GameObject RestartButton;
    public GameObject resultmenu;
    public GameObject a;
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
    AdUnitID = "ca-app-pub-3223134923583056/8741716027";
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
        AdButton.SetActive(false);
        a.SetActive(false);
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
        AdButton.SetActive(false);
        RestartButton.SetActive(true);
        // DailyBonusData.Instance.addSpecialBonusNotice("AD_REWARD_1");

        IsActive = true;
    }

    protected void OnAdLeavingApp(object _sender, System.EventArgs _args)
    {
        Debug.Log("AdLeavingApplication");
        IsActive = false;
    }

    public void restartbutton()
    {
        ScoreHolder sh = scriptbox.GetComponent<ScoreHolder>();
        timekeeper tk = scriptbox.GetComponent<timekeeper>();
        resultmenu.SetActive(false);
        RestartButton.SetActive(false);
        sh.left_jiki++;
        tk.flag=true;
        tk.deadonce = true;
    }
}