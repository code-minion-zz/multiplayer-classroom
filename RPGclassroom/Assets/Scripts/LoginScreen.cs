using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(UserAuthentication))]
[RequireComponent(typeof(UserRetrieveData))]
public class LoginScreen : MonoBehaviour 
{
    public string studentScene = "studentMain";
    public string teacherScene = "teacherMain";

    public const int INVALID_ID = -1;
    public UIInput usernameField;
    public UIInput passwordField;

    private UserAuthentication userAuthentication;
    private UserRetrieveData userRetrieveData;
    private bool succeeded;

	private float elapsedTime = 0;
	private float fadeInTime = 1f;
	private GameObject uiObject;

    public void Awake()
    {
        // Setup the observers.
        userAuthentication = GetComponent<UserAuthentication>();
        userRetrieveData = GetComponent<UserRetrieveData>();
        userAuthentication.onLoginAttempt += OnLoginAttempt;
        userRetrieveData.onDataRetrieved += OnUserDataRetrieved;
		uiObject = GameObject.Find("UI");
		NGUITools.SetActive(uiObject, false);
    }

	public void Update()
	{
		if (uiObject.activeInHierarchy) return;
		if (elapsedTime > fadeInTime) NGUITools.SetActive(uiObject, true);
		else elapsedTime += Time.deltaTime;
	}

    public void AttemptLogin()
    {
        if (succeeded == false)
        {
            userAuthentication.AttemptLogin(usernameField.value, passwordField.value);
        }
    }

    /// <summary>
    /// This is an observer that will only be called after attempt login on the userAuthentication has been called.
    /// </summary>
    /// <param name="data"></param>
    private void OnLoginAttempt(WWW data)
    {
        // Check if the data contains TRUE flag
        bool.TryParse(data.text, out succeeded);

        if (succeeded == false)
        {
            Debug.LogWarning("Invalid username or password.");
        }
        else
        {
            // Get the UserID from the response.
            int userId = INVALID_ID;
            Int32.TryParse(data.responseHeaders["ID"], out userId);

            if (userId != INVALID_ID)
            {
                // Now retrieve all the data.
                Debug.Log("Succeeded: UserID=" + userId);
                userRetrieveData.RetrieveData(userId);
            }
            else
            {
                succeeded = false;
            }
        }
    }

    private void OnUserDataRetrieved()
    {
        Debug.Log("Data Retrieved");
        Application.LoadLevel(studentScene);
    }
}
