using System.Text.RegularExpressions;
using Newtonsoft.Json;
namespace BankConsole;

public class User
{
    [JsonProperty]
    protected int ID{get; set;}
    [JsonProperty]
    protected string Name { get; set; }
    [JsonProperty]
    protected string Email { get; set; }
    [JsonProperty]
    protected decimal Balance { get; set; }
    [JsonProperty]
    protected DateTime RegisterDate { get; set; }

    public User(){}

    public User(int ID, string Name, string Email, decimal Balance)
    {
        this.ID = ID;
        this.Name = Name;
        this.Email = Email;
        this.RegisterDate = DateTime.Now;
    }

    public int GetID()
    {
        return ID;
    }

    public DateTime GetRegisterDate()
    {
        return RegisterDate;
    }

    public virtual void SetBalance(decimal amount)
    {
        decimal quantity = 0;
        if(amount < 0)
            quantity = 0;
        else
            quantity = amount;
        this.Balance += quantity;
    }
    public virtual string ShowData()
    {
        return $"ID: {this.ID} \nNombre: {this.Name} \nCorreo: {this.Email} \nSaldo: {this.Balance} \nFecha de Registro: {this.RegisterDate.ToShortDateString()}";
    }

    public string ShowData(string initialMessage) //Sobrecargar
    {
        return $"{initialMessage}\nNombre: {this.Name} \nCorreo: {this.Email} \nSaldo: {this.Balance} \nFecha de Registro: {this.RegisterDate}";
    }

    public static bool ValidarEmail(string email)
    {
        return email != null && Regex.IsMatch(email, "^(([\\w-]+\\.)+[\\w-]+|([a-zA-Z]{1}|[\\w-]{2,}))@(([a-zA-Z]+[\\w-]+\\.){1,2}[a-zA-Z]{2,4})$");
    }
    
}