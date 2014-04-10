using UnityEngine;
using System.Collections;

public class UserAuthentication : MonoBehaviour 
{
    public delegate void LoginEvent(WWW data);
    public event LoginEvent onLoginAttempt;

    private string username;
    private string password;
    private WWW fetchData;

    public void AttemptLogin(string email, string password)
    {
        this.username = email;
        this.password = password;
        fetchData = null;

        WWWForm sendLoginInfo = new WWWForm();
        sendLoginInfo.AddField("email", username);
        sendLoginInfo.AddField("password", password);

        StartCoroutine(AuthenticateInfo());
    }

    IEnumerator AuthenticateInfo()
    {
        // Set the WWWFORM to send to the PHP Page
        var sendLoginInfo = new WWWForm();
        sendLoginInfo.AddField("email", username);
        sendLoginInfo.AddField("password", password);

        // Send the WWWForm via WWW
        fetchData = new WWW(URLHelper.authenticateURL, sendLoginInfo);
        // Wait for the data return
        yield return fetchData;

        if (onLoginAttempt != null)
        {
            onLoginAttempt(fetchData);
        }
    }
}
