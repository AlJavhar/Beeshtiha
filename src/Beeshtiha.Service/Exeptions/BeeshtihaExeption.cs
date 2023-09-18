namespace Beeshtiha.Service.Exeptions;

public class BeeshtihaExeption : Exception
{ 
    public int code { get; set; }
    public BeeshtihaExeption(int code = 500, string message = "Something went wrong") : base(message)
    {
        this.code = code;
    }
}
