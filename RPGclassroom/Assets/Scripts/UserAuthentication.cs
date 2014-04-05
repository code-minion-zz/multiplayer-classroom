using UnityEngine;
using System.Collections;

public class UserAuthentication : MonoBehaviour 
{
    public string loginURL = "http://localhost/unity_test/addscore.php?";
    public string sceneToLoad = "";

    private string username;
    private string password;

    private bool canLogin;

    IEnumerator CheckPassword()
    {
        // Set the WWWFORM to send to the PHP Page
        var sendLoginInfo = new WWWForm();
        sendLoginInfo.AddField("Username", username);
        sendLoginInfo.AddField("Password", password);

        // Send the WWWForm via WWW
        var getData = new WWW(loginURL, sendLoginInfo);
        yield return getData; // Wait for the data return
        bool.TryParse(getData.text, out canLogin); // Check if the data contains TRUE flag

        if (canLogin)
        {
            Application.LoadLevel(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Invalid username or password.");
        }
    }
}
