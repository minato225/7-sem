using System.Text;
using static System.Net.Mime.MediaTypeNames;
public class R
{
    public string Text; 
    public R()
    {

    }
}
R MainText = new R();


Console.OutputEncoding = Encoding.GetEncoding("IBM437");
var text = new StringBuilder();
for (int i = 0; i < 256; i++)
{
    text.Append($"{(char)i}_{i.ToString("X2")}");
    if ((i + 1) % 16 == 0)
        text.Append("\n");
}

MainText.Text = text.ToString();