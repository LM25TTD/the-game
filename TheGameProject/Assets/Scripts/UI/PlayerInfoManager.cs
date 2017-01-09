using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Player info manager. Singleton object the holds the Player informations like health and 
/// score. This class populate the UI.
/// </summary>
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

	/// <summary>
	/// Resets the score.
	/// </summary>
	public void ResetScore()
	{
		mScore = 0;
		UpdateScoreText();
	}

	/// <summary>
	/// Sets the score.
	/// </summary>
	/// <param name="value">Value.</param>
	public void SetScore(float value)
	{
		mScore = value;
		UpdateScoreText();
	}

	/// <summary>
	/// Increases the score.
	/// </summary>
	/// <param name="value">Value.</param>
	public void IncreaseScore(float value)
	{
		mScore += value;
		UpdateScoreText();
	}

	/// <summary>
	/// Updates the score text.
	/// </summary>
	private void UpdateScoreText()
	{
		ScoreText.text = mScore.ToString();
	}

	/// <summary>
	/// Increases the health.
	/// </summary>
	/// <param name="value">Value.</param>
	public void IncreaseHealth(float value)
	{
		mHealth += value;
		mHealth = mHealth > 100 ? 100 : mHealth;
		UpdateHealthText();
	}

	/// <summary>
	/// Decreases the health.
	/// </summary>
	/// <param name="value">Value.</param>
	public void DecreaseHealth(float value)
	{
		mHealth -= value;
		mHealth = mHealth < 0 ? 0 : mHealth;
		UpdateHealthText();
	}

	/// <summary>
	/// Gets the health.
	/// </summary>
	/// <returns>The health.</returns>
	public float GetHealth()
	{
		return mHealth;
	}

	/// <summary>
	/// Updates the health text.
	/// </summary>
	private void UpdateHealthText()
	{
		HealthText.text = mHealth.ToString();
	}
}
