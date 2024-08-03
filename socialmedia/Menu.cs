public class Menu : Post
{

// ---------------------------------------variables-------------------------------------------
 string brackets = "========SOCIAL========";
private string _userinput = "";
Post post = new Post();

public string postinputString;
public int postinputNumber;
static string _postPath = "post.txt";


// ----------------------------------------constructor-------------------------------------------
public Menu()
{
}

// -----------------------------------------methods----------------------------------------------
public void Display()
{

    while (_userinput.ToLower() != "q")
    {
         
        
        Console.WriteLine(brackets);
        Console.WriteLine(" Main Menu");
        Console.WriteLine("[c]reate Post");
        Console.WriteLine("[v]iew Profile");
        Console.WriteLine("[l]ike Post");
        Console.WriteLine("[q]uit");
        Console.WriteLine(" User: ");
        _userinput = Console.ReadLine();
        switch (_userinput.ToLower())
        {
            case "c":
                post.CreatePost();
                
                break;
                
            case "v":
                
                post.DisplayPost();
                break;
            case "l":
            Console.WriteLine("Which Post # will you Like: ");
            postinputString = Console.ReadLine();
            postinputNumber = int.Parse(postinputString);
            LikePost(postinputNumber);
                break;
            case "q":
                Console.WriteLine("Thank You for Coming!");
                return;

        }
       

    }
    
}






}



