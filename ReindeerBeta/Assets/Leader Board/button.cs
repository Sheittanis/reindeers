using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using UnityEngine.UI;

public class button : MonoBehaviour {

    int level = 3210;
    string uname = "No name";
    public GameObject namebox;
    int score = 3210;

	private string secretKey = "mySecretKey";

	public string AddUserURL = "http://loose.hol.es/AddUsers.php?";

	public string showAllUsersURL = "http://loose.hol.es/SelectAllUsers.php?";

    public void OnButtonClick()
	{
        //Get values and add to table
        level = PlayerPrefs.GetInt("levelToPlay");

        //Name no longer set by fb script

        uname = namebox.GetComponent <Text>().text;

        score = PlayerPrefs.GetInt("previousScore");
        
        //Add score
        AddUser(level, uname, score);

        //Display leaderboard
        display();
    }

    public void display()
    {          
        //Display leaderboard
        UnityEngine.UI.Text textLabel = GameObject.Find("Text1").GetComponent<UnityEngine.UI.Text>();
        string original = GetAllUsers();

        if (!original.StartsWith("You"))
        {

            string display;
            //split into lines
            string[] lines = original.Split('\n');

            int linesWeWant = 5;
            string[] lines4level = new string[linesWeWant];
            //get only lines that have the right level value
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith(PlayerPrefs.GetInt("levelToPlay").ToString()) && linesWeWant > 0)
                {
                    //only get 5
                    lines4level[5 - linesWeWant] = lines[i];
                    linesWeWant--;
                }
            }
            //add leaderboard position
            for (int line = 0; line < lines4level.Length; line++)
            {
                if (lines4level[line] != null)
                {
                    lines4level[line] = (line + 1).ToString() + ". " + lines4level[line].Substring(lines4level[line].IndexOf('\t') + 1);
                }
            }
            //print dat shiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii
            display = lines4level[0] + "\n\n" + lines4level[1] + "\n\n" + lines4level[2] + "\n\n" + lines4level[3] + "\n\n" + lines4level[4];
            textLabel.text = display;
        }
        else
        {
            textLabel.text = original;
        }
    }

	public string GetAllUsers()
	{
        float timer = 0.0f;


        //go to url
		WWW GetUsers = new WWW (showAllUsersURL);
        //debugging
		while (!GetUsers.isDone) 
		{
            //Timer breaks out if takes more than 100 seconds to get data from database
            timer += Time.deltaTime;
            print(timer);
            if (timer >= 100.0f)
            {
                return ("You are not connected to the internet or our server is down for maintanence, sorry.");
            }
		}

		if (GetUsers.error != null) 
		{
			Debug.Log ("There was an error getting the high score: " + GetUsers.error);
		}
        //return text
		return GetUsers.text;
        
	}

	public void AddUser(int level, string userName, int score)
	{
        float timer = 0.0f;

        //make url
        string hash = CreateMD5(level + userName + score + secretKey).ToLower();
        
        //string post_url = AddUserURL + "Email=" + WWW.EscapeURL(userName) + "&Password=" + password + "&hash=" + hash;    
        string post_url = AddUserURL + "Level=" + WWW.EscapeURL(level.ToString()) + "&Name=" + WWW.EscapeURL(uname) + "&Score=" + WWW.EscapeURL(score.ToString()) + "&hash=" + hash;

        //go to site
        WWW post = new WWW(post_url);
        //debugging
        while (!post.isDone)
        {
            //Timer breaks out if more than 100 seconds to add user
            timer += Time.deltaTime;            
            if (timer >= 100.0f)
            {
                return;
            }
        }
        if(post.error != null)
        {
            print("There was an error posting the user data: " + post.error);
        }
        
	}

    public static string CreateMD5(string input)
    {
        //Use input string to calculate MD5 hash
        MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        byte[] hashBytes = md5.ComputeHash(inputBytes);

        //Convert the byte array to hexadecimal string
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < hashBytes.Length; i++)
        {
            sb.Append(hashBytes[i].ToString("X2"));
        }
        return sb.ToString();
    }
}