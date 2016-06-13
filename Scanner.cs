
using System.IO;
using System.Text.RegularExpressions;

public class Scanner
{
    int pointer = 0;
    string[] split;
    public Scanner(string filename){
        var content = File.ReadAllText(filename);
        content =  content
                    .Replace('\r', ' ')
                    .Replace('\n', ' ');


        RegexOptions options = RegexOptions.None;
        Regex regex = new Regex("[ ]{2,}", options);     
        content = regex.Replace(content, " ");
        content = regex.Replace(content, " ");
        content = regex.Replace(content, " ");
        //content = content.Replace(".", string.Empty);
        split = content.Split(' ' );
        //System.Console.WriteLine(split.Length);
    }

    public BiGram Next(){
        var biGram = new BiGram(){First = split[pointer], Second = split[pointer+1], Suffix = split[pointer+2]};
        pointer++;
        return biGram;
    }

    public bool IsEnd(){
        return (split.Length == pointer + 2);
    }
}