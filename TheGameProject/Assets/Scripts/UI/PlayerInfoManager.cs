using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerInfoManager : MonoBehaviour {

	private float mScore = 0.0f, mHealth=100.0f;
	private static PlayerInfoManager mInstance;

	public Text ScoreText, HealthText;

	//Singleton
	public static PlayerInfoManager Instance
	{
		get
		{
			if (mInstance == null)
				mInstance = new PlayerInfoManager();

			return mInstance;
		}
	}

	private PlayerInfoManager()
	{
	}

	void Awake()
	{
		if (mInstance == null)
		{
			mInstance = this;
		}
		else
		{
			DestroyImmediate(this);
		}
	}

	void Start()
	{
		UpdateScoreText ();
		UpdateHealthText ();
	}	

	public void ResetScore()
	{
		mScore = 0;
		UpdateScoreText();
	}

	public void SetScore(float value)
	{
		mScore = value;
		UpdateScoreText();
	}

	public void IncreaseScore(float value)
	{
		mScore += value;
		UpdateScoreText();
	}

	private void UpdateScoreText()
	{
		ScoreText.text = mScore.ToString();
	}


	public void IncreaseHealth(float value)
	{
		mHealth += value;
		mHealth = mHealth > 100 ? 100 : mHealth;
		UpdateHealthText();
	}

	public void DecreaseHealth(float value)
	{
		mHealth -= value;
		mHealth = mHealth < 0 ? 0 : mHealth;
		UpdateHealthText();
	}

	public float GetHealth()
	{
		return mHealth;
	}

	private void UpdateHealthText()
	{
		HealthText.text = mHealth.ToString();
	}
}
