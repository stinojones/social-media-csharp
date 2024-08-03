public class Login : UserHandler
{
// ---------------------------------------variables-------------------------------------------




public bool _loggedIn = false;
public FileHandler fileHandler = new FileHandler();
public string brackets = "========SOCIAL========";
private string _userinput;
private bool logincomplete;
protected string _usernameinput;
protected string _passwordinput;


   // ------------------------------Paths-------------------------------------
        protected string _usernamePath = "username.txt";
        protected string _passwordPath = "password.txt";


// ----------------------------------------constructor-------------------------------------------
public Login()
{
       FileHandler fileHandler = new FileHandler();
            _usernameList = fileHandler.LoadFile(_usernamePath);
            _passwordList = fileHandler.LoadFile(_passwordPath);
}
// -----------------------------------------methods----------------------------------------------


public void CheckLogin()
{
    Console.WriteLine("Username: ");
    _usernameinput = Console.ReadLine();
    Console.WriteLine("Password: ");
    _passwordinput = Console.ReadLine();


foreach (string _username in _usernameList)
{
if(_usernameinput == _username)
{
_usernameIndex = _usernameList.IndexOf(_username);
}
}

_passwordIndex = _usernameIndex;

if(_passwordinput == _passwordList[_passwordIndex])
{
logincomplete = true;
}

LoggedInDisplay();

if (logincomplete == true)
{
    LogIn();
}
}
public void CreateAccount()
{
Console.WriteLine("New Username: ");
_username = Console.ReadLine();
_usernameList.Add(_username);
Console.WriteLine("New Password: ");
_password = Console.ReadLine();
_passwordList.Add(_password);
fileHandler.SaveFile(_usernameList, _usernamePath);
fileHandler.SaveFile(_passwordList, _passwordPath);
User user = new User(_username, _followerList, _followingList, _postList);

}

public void LogIn()
{
    _loggedIn = true;
}
public void LogOut()
{
    _loggedIn = false;
}

public void LoggedInDisplay()
{
    if (logincomplete == true)
    {
        Console.WriteLine("You are logged in");
    }
    else
    {
        Console.WriteLine("Wrong username or password. Try again");
    }
}


public void DisplayLogin()
{
    while(_loggedIn == false)
    {
    Console.WriteLine(brackets);
    Console.WriteLine("[L]ogin");
    Console.WriteLine("[C]reate Account");
    Console.WriteLine(" User: ");
    _userinput = Console.ReadLine();

    
    

    if(_userinput == "l" || _userinput == "L")
    {
        CheckLogin();
    }
    else if (_userinput == "c" || _userinput == "C")
    {
        CreateAccount();
    }
    }

}








}