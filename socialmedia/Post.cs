public class Post : UserHandler
{
// ---------------------------------------variables-------------------------------------------
public int _likes;
protected List<string> _commentList = new List<string>();
public string _comment;
public string _quote;
public DateTime currentDateTime = DateTime.Now;
protected int postNumber;
public FileHandler fileHandler = new FileHandler();
 protected List<string> postStringList = new List<string>();
protected string _stringPost;

    string[] lines = File.ReadAllLines(_postPath);


 

// -------------------------------paths--------------------------------

static string _postPath = "post.txt";

// ----------------------------------------constructor-------------------------------------------
     public Post(string quote = "", int likes = 0)
{
    _quote = quote;
    _likes = likes;
}

    // -----------------------------------------methods----------------------------------------------

  
public void CreatePost()
{
    Console.WriteLine("Post: ");
    string quote = Console.ReadLine();
    Post post = new Post(quote);

    string csv = $"{post._quote},{post._likes}";

    string filePath = "post.txt";

    using (StreamWriter sw = File.AppendText(filePath))
    {
        sw.WriteLine(csv);
    }

    _postList.Add(post);
}


public void DisplayPost()
{
    LoadPostsToPostList();
    foreach (Post post in _postList)
    {

        int postNumber = _postList.IndexOf(post) + 1;
        Console.WriteLine($"{postNumber}. {post._quote} || {post._likes} Likes || {currentDateTime}");
    }
}


public void LikePost(int postNumber)
{
    LoadPostsFromFile();
    if (postNumber <= 0 || postNumber > _postList.Count)
    {
        Console.WriteLine("Invalid post number.");
        return;
    }

    Post post = _postList[postNumber - 1];
    post._likes++;

    UpdatePostInFile(post, postNumber); // Update the liked post in the file

    Console.WriteLine($"Post number {postNumber} liked. Current likes: {post._likes}");
}

// Update the liked post in the file
private void UpdatePostInFile(Post post, int postNumber)
{
    string[] lines = File.ReadAllLines(_postPath);

    if (postNumber <= lines.Length)
    {
        lines[postNumber - 1] = $"{post._quote},{post._likes}";
        File.WriteAllLines(_postPath, lines);
    }
}
    public void SavePostsToFile()
    {
        List<string> postStringList = new List<string>();
        foreach (Post post in _postList)
        {
            string postString = $"{post._quote},{post._likes}";
            postStringList.Add(postString);
        }

        File.WriteAllLines(_postPath, postStringList);
    }

    // Load posts from the file
    public void LoadPostsFromFile()
    {
        _postList.Clear(); 
        string[] lines = File.ReadAllLines(_postPath);

        foreach (string line in lines)
        {
            string[] postItems = line.Split(',');
            if (postItems.Length >= 2)
            {
                string quote = postItems[0];
                int likes = int.Parse(postItems[1]);
                Post post = new Post(quote, likes);
                _postList.Add(post);
            }
        }
    }





    public void LoadPostsToPostList()
    {
        _postList.Clear(); 

        string[] lines = File.ReadAllLines(_postPath);

        foreach (string line in lines)
        {
            string[] postItems = line.Split(',');
            if (postItems.Length >= 2)
            {
                string quote = postItems[0];
                int likes = int.Parse(postItems[1]);
                Post post = new Post(quote, likes);
                _postList.Add(post);
            }
        }
}
}






