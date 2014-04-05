using UnityEngine;
using System.Collections;

public class UserAuthentication : MonoBehaviour 
{
    // User? Student, Teacher
    // Username
    // Password

    public string username;
    public string password;

    public void CheckPassword()
    {
        // Set the WWWFORM to send to the PHP Page
        var sendLoginInfo = new WWWForm();
        sendLoginInfo.AddField("Username", username);
        sendLoginInfo.AddField("Password", password);

        // Send the WWWForm via WWW
    }
}
