﻿using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class BannerAd : MonoBehaviour
{
    private BannerView bannerView;
    
    public void Start()
    {
        #if UNITY_ANDROID
            string appId = "ca-app-pub-3940256099942544~3347511713";
        #elif UNITY_IPHONE
            string appId = "ca-app-pub-1390464978763074~7137335710";
        #else
            string appId = "unexpected_platform";
        #endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        this.RequestBanner();
    }

    private void RequestBanner()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-1390464978763074/1682663208";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
    }
}
