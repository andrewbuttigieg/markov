public class BiGram 
{
    public string First {get;set;}
    public string Second {get;set;}
    public string Suffix {get;set;}

    public string Hash(){
        return (this.First + "-" + this.Second).ToLower();
    }
}