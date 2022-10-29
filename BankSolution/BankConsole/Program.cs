using System.Text.RegularExpressions;
using BankConsole;

if(args.Length == 0)
    EmailService.SendMail();
else
    ShowMenu();

void ShowMenu()
{
    Console.Clear();
    Console.WriteLine("Selecciona una opción: ");
    Console.WriteLine("1 - Crear un usuario nuevo");
    Console.WriteLine("2 - Eliminar un usuario existente");
    Console.WriteLine("3 - Salir");

    int option = 0;
    do
    {
        string input = Console.ReadLine();

        if(!int.TryParse(input, out option))
            Console.WriteLine("Debes ingresar un número (1, 2 o 3)");
        else if (option > 3)
            Console.WriteLine("Debes ingresar un número valido (1, 2 o 3)");
    } while (option == 0 || option > 3);

    switch (option)
    {
        case 1:
            CreateUser();
            break;
        case 2:
            DeleteUser();
            break;
        case 3:
            
            Environment.Exit(0);
            break;
    }

    void CreateUser()
    {
        Console.Clear();
        Console.WriteLine("Ingresa la información del usuario: ");
        int ID = 0, temp;
        do
        {
            // StreamReader file = new StreamReader(@"C:\Users\oziel\Documents\CDIS\.NET\BankSolution\BankConsole\bin\Debug\net6.0");
            // string content = file.ReadToEnd();
            
            Console.WriteLine("ID:");
            temp = int.Parse(Console.ReadLine());
            if(temp > 0)
                ID = temp;
            else
                Console.WriteLine("Favor de ingresar un número mayor a 0");
        } while (temp <= 0);
        
            

        Console.WriteLine("Nombre: ");
        string name = Console.ReadLine();

        Console.WriteLine("Email: ");
        string emailText = Console.ReadLine();

        Console.WriteLine("Saldo: ");
        decimal balance = 0, temporal;
        
        do
        {
           temporal = decimal.Parse(Console.ReadLine());
           if(temporal >= 0)
                balance = temporal;
            else
                Console.WriteLine("Ingresa un saldo positivo");
        } while (temporal < 0);

        Console.WriteLine("Escribe 'c' si el usuario es cliente, 'e' si es Empleado: ");
        char userType, tempo;
        
        User newUser;

        do
        {         
            tempo = char.Parse(Console.ReadLine());
            userType = tempo; 
            if(userType.Equals('c'))
            {
                
                Console.Write("Regimen fiscal: ");
                char TaxRegime = char.Parse(Console.ReadLine());

                newUser = new Client(ID, name, emailText, balance, TaxRegime);
                Storage.AddUser(newUser);
            }
            else if(userType.Equals('e'))
            {
                
                Console.Write("Departamento: ");
                string department = Console.ReadLine();

                newUser = new Employee(ID, name, emailText, balance, department);
                Storage.AddUser(newUser);
            }
            else{
                Console.WriteLine("Caractér incorrecto. Ingrese otro caractér");
            }
            
        } while (tempo != 'c' && tempo != 'e');

        
        Console.WriteLine("Usuario creado.");
        Thread.Sleep(2000);
        ShowMenu();
    }

     void DeleteUser()
    {
        Console.Clear();
            Console.Write("Ingresa el ID del usuario a eliminar: ");
            int ID = int.Parse(Console.ReadLine());
            string result = Storage.DeleteUser(ID);

        if (result.Equals("Success"))
        {
            Console.WriteLine("Usuario eliminado.");
            Thread.Sleep(2000);
            ShowMenu();
        }
        
    }
   
}



