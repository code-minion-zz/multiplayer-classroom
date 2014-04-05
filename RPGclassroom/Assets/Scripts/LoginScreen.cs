using UnityEngine;
using System.Collections;

public class LoginScreen : MonoBehaviour 
{
    public UserAuthentication userAuthentication;
    public string studentScene = "studentMain";
    public string teacherScene = "teacherMain";

    public UILabel usernameField;
    public UILabel passwordField;

    public void AttemptLogin()
    {
        bool loggedIn = userAuthentication.AttemptLogin(usernameField.text, passwordField.text);

        if (loggedIn)
        {
            Application.LoadLevel(studentScene);
        }
    }
}
