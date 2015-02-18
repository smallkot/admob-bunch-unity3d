using System;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class AdmobBunch: MonoBehaviour {

	public enum AdSize{
		aGADAdSizeBanner,
		
		/// Taller version of kGADAdSizeBanner. Typically 320x100.
		aGADAdSizeLargeBanner,
		
		/// Medium Rectangle size for the iPad (especially in a UISplitView's left pane). Typically 300x250.
		aGADAdSizeMediumRectangle,
		
		/// Full Banner size for the iPad (especially in a UIPopoverController or in
		/// UIModalPresentationFormSheet). Typically 468x60.
		aGADAdSizeFullBanner,
		
		/// Leaderboard size for the iPad. Typically 728x90.
		aGADAdSizeLeaderboard,
		
		/// Skyscraper size for the iPad. Mediation only. AdMob/Google does not offer this size. Typically
		/// 120x600.
		aGADAdSizeSkyscraper,
		
		/// An ad size that spans the full width of the application in portrait orientation. The height is
		/// typically 50 pixels on an iPhone/iPod UI, and 90 pixels tall on an iPad UI.
		aGADAdSizeSmartBannerPortrait,
		
		/// An ad size that spans the full width of the application in landscape orientation. The height is
		/// typically 32 pixels on an iPhone/iPod UI, and 90 pixels tall on an iPad UI.
		aGADAdSizeSmartBannerLandscape
	};
	
	public enum BannerGravity
	{
		kBannerGravityNone = -1,
		kBannerGravityTopLeft = 0,
		kBannerGravityCenterLeft,
		kBannerGravityBottomLeft,
		kBannerGravityTopCenter,
		kBannerGravityCenter,
		kBannerGravityBottomCenter,
		kBannerGravityTopRight,
		kBannerGravityCenterRight,
		kBannerGravityBottomRight
	};

	private static string BUNCH = "AdmobBunch";

	private static AdmobBunch INSTANCE = null;

	public static AdmobBunch GetInstance() {
		return INSTANCE;
	}

	void Awake() {
		if (AdmobBunch.INSTANCE == null) {
			AdmobBunch.INSTANCE = this;
			BunchManager.registerBunch(BUNCH);
			GameObject.DontDestroyOnLoad(this);
		} else {
			GameObject.Destroy(this.gameObject);
		}
	}

	public void CreateBanner(string adUnitID, long adSizeBanner) {
		Debug.Log("createBanner");

		NativeGateway.dispatch(
			BUNCH,
			"createBanner",
			new Dictionary<string, object> () {
				{"adUnitID", adUnitID},
				{"adSizeBanner", adSizeBanner}
			}
		);
	}

	public void ShowBanner(double mX, double mY, double mWidth, double mHeight, int mGravity) {
		NativeGateway.dispatch(
			BUNCH,
			"showBanner",
			new Dictionary<string, object> () {
				{"mX", mX},
				{"mY", mY},
				{"mWidth", mWidth},
				{"mHeight", mHeight},
				{"mGravity", mGravity}
			}
		);
	}
	
	public void HideBanner() {
		NativeGateway.dispatch(
			BUNCH,
			"hideBanner",
			null
		);
	}
	
	public void CreateInterstitial(string adUnitID) {
		NativeGateway.dispatch(
			BUNCH,
			"createInterstitial",
			new Dictionary<string, object> () {
				{"adUnitID", adUnitID}
			}
		);
	}
	
	public void ShowInterstitial() {
		NativeGateway.dispatch(
			BUNCH,
			"showInterstitial",
			null
		);
	}
	
}
