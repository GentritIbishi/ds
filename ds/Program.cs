using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ds
{
    public class Program
    {
        static void Main(string[] args)
        {
            Beale B = new Beale();
            Permutation P = new Permutation();
            Numerical N = new Numerical();
            Createuser C = new Createuser();
            Deleteuser D = new Deleteuser();
            ExportKey E = new ExportKey();
            ImportKey I = new ImportKey();
            EncryptMessage EM = new EncryptMessage();
            DecryptMessage DM = new DecryptMessage();
            Token T = new Token();
            TokenStatus S = new TokenStatus();


            try
            {
                if (args.Length <= 1 || args.Length > 5)
                {
                    Console.WriteLine("\nArgumentet Mungojne / Numri i argumenteve jo i lejuar!");
                    Console.WriteLine(
                        "\nPer ekzekutimin e funksionit Beale shtyp | ds Beale Encrypt <text> | ose | ds Beale Decrypt <text> |");
                    Console.WriteLine(
                        "\nPer ekzekutimin e funksionit Permutation shtyp | ds Permutation Encrypt <key><text> | ose | ds Permutation Decrypt <key><text> |");
                    Console.WriteLine(
                        "\nPer ekzekutimin e funksionit Numerical shtyp | ds Numerical Encode <text> | ose | ds Numerical Decode <text> |");
                    Console.WriteLine("\nPer ekzekutimin e funksionit CreateUser shtyp | ds create-user <name> |");
                    Console.WriteLine("\nPer ekzekutimin e funksionit DeleteUser shtyp | ds delete-user <name> |");
                    Console.WriteLine(
                        "\nPer ekzekutimin e funksionit ExportKey shtyp | ds export-key <public | private> <name> [file] |");
                    Console.WriteLine(
                        "\nPer ekzekutimin e funksionit ImportKey shtyp | ds import-key <name> <path> |");
                    Console.WriteLine(
                        "\nPer ekzekutimin e funksionit EncryptMessage shtyp | ds write-message <name> <message> [token | file] [file] |");
                    Console.WriteLine(
                        "\nPer ekzekutimin e funksionit DecryptMessage shtyp | ds read-message <encrypted-message> |");
                    Console.WriteLine("\nPer ekzekutimin e funksionit login shtyp | ds login <name> |");
                    Console.WriteLine("\nPer ekzekutimin e funksionit status shtyp | ds status <token> |");
                    Environment.Exit(1);
                }

                /*---------------Args per Numerical-----------------*/
                if (args[0].Equals("Numerical"))
                {
                    if (args[1].Equals("Encode"))
                    {
                        String text = args[2];
                        if (Regex.IsMatch(text, "^[a-z ]+$"))
                        {
                            string Cipher = N.Encode(text);
                            Console.WriteLine("Encoded text is: " + Cipher);
                        }
                        else
                        {
                            Console.Write(
                                "\nArgumenti i fundit lejohet te permbaje vetem shkronja te vogla sipas alfabetit anglez prej a-z!");
                        }
                    }
                    else if (args[1].Equals("Decode"))
                    {
                        String text = args[2];
                        if (Regex.IsMatch(text, "^[0-9]+"))
                        {
                            string Plain = N.Decode(text);
                            Console.WriteLine("Decoded cipher is: " + Plain);
                        }
                        else
                        {
                            Console.Write("\nArgumenti i fundit lejohet te permbaje vetem numra 0-9!");
                        }
                    }
                    else
                    {
                        Console.Write("\nArgumenti eshte jo valid! (Args must be | Encode | or | Decode |)");
                        Environment.Exit(1);
                    }
                }
                /*---------------Args per Permutation-----------------*/
                else if (args[0].Equals("Permutation"))
                {
                    if (args[1].Equals("Encrypt"))
                    {
                        String key = args[2];
                        String text = args[3];
                        if (Regex.IsMatch(key, "^[1-4]+$") && key.Length == 4)
                        {
                            Console.WriteLine();
                            P.Encrypt(key, text);
                        }
                        else if (Regex.IsMatch(key, "^[1-4]+$") && key.Length != 4)
                        {
                            Console.WriteLine(
                                "\nKey is either too long or too short (Make sure its 4 charecters only!");
                        }
                        else
                        {
                            throw new Exception(
                                "\nKeep in mind that the first argument allows only numbers from 1-4!");
                        }
                    }
                    else if (args[1].Equals("Decrypt"))
                    {
                        String key = args[2];
                        String text = args[3];
                        if (Regex.IsMatch(key, "^[1-4]+$") && key.Length == 4)
                        {
                            Console.WriteLine();
                            P.Decrypt(key, text);
                        }
                        else if (Regex.IsMatch(key, "^[1-4]+$") && key.Length != 4)
                        {
                            Console.WriteLine(
                                "\nKey is either too long or too short (Make sure its 4 charecters only!");
                        }
                        else
                        {
                            throw new Exception(
                                "\nKeep in mind that the first argument allows only numbers from 1-4!");
                        }
                    }
                    else
                    {
                        Console.Write(
                            "\nE R R O R  ! Make sure you passed the argument right | Encrypt | or | Decrypt |!");
                        Environment.Exit(1);
                    }
                }
                /*---------------Args per Beale-----------------*/
                else if (args[0].Equals("Beale"))
                {
                    if (args[1].Equals("Encrypt"))
                    {
                        String plainteksti = args[2];
                        if (Regex.IsMatch(plainteksti, "^[a-zA-Z ]+$"))
                        {
                            Console.Write("Encrypted plaintext is: ");
                            B.BealeEncrypt(plainteksti);
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine(
                                "\nArgumenti i fundit duhet te permbaje tekst a-z ose A-Z ne varesi nga teksti");
                        }
                    }
                    else if (args[1].Equals("Decrypt"))
                    {
                        String[] ciphertekst = args[2].Split(" ");
                        String Cipher = String.Concat(ciphertekst);
                        if (Regex.IsMatch(Cipher, "^[0-9]+$"))
                        {
                            Console.Write("Decrypted Ciphertext is: ");
                            B.BealeDecrypt(ciphertekst);
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("\nArgumenti i fundit duhet te permbaje vetem kod");
                        }
                    }
                    else
                    {
                        Console.Write("\nArgumenti eshte jo valid! (Args must be Encrypt or Decrypt) !");
                        Environment.Exit(1);
                    }
                }
                /*---------------Args per create-user-----------------*/
                else if (args[0].Equals("create-user"))
                {
                    string text = args[1];
                    if (Regex.IsMatch(text, "^[A-Za-z0-9_.]+$"))
                    {
                        //FilePath
                        string privateKeyfilePath = "keys//" + text + ".xml";
                        string publicKeyfilePath = "keys//" + text + ".pub.xml";

                        //Check nese egziston ndonje file me ate emer ne direktorin keys
                        bool privateKeyExist = File.Exists(privateKeyfilePath);
                        bool publicKeyExist = File.Exists(publicKeyfilePath);

                        if (!(privateKeyExist || publicKeyExist))
                        {
                            C.InsertIntoDB(text);
                            //Perdorimi i funksionit GenerateRsaKey per te krijuar qelesat privat dhe public me madhesi 1024(sipas deshires)
                            C.GenerateRsaKey(privateKeyfilePath, publicKeyfilePath, 1024);
                            //Trego qe u krijuan qelsat
                            Console.WriteLine("Eshte krijuar celesi privat " + "'keys//" + args[1] + ".xml'");
                            Console.WriteLine("Eshte krijuar celesi public " + "'keys//" + args[1] + ".pub.xml'");
                        }
                        else
                        {
                            Console.WriteLine("File me ate emer egziston ne folderin keys, provo tjeter emer!");
                        }
                    }
                    else
                    {
                        Console.WriteLine(
                            "Lejohen vetem Emra me shkonje te madhe apo te vogel, dhe numrat 0-9 dhe _ dhe .");
                        Environment.Exit(1);
                    }
                }
                /*---------------Args per delete-user-----------------*/
                else if (args[0].Equals("delete-user"))
                {
                    string text = args[1];
                    if (Regex.IsMatch(text, "^[A-Za-z0-9_.]+$"))
                    {
                        //FilePath
                        string privateKeyfilePath = "keys//" + text + ".xml";
                        string publicKeyfilePath = "keys//" + text + ".pub.xml";

                        //Check nese egziston ndonje file me ate emer ne direktorin keys
                        bool privateKeyExist = File.Exists(privateKeyfilePath);
                        bool publicKeyExist = File.Exists(publicKeyfilePath);

                        if ((privateKeyExist && publicKeyExist))
                        {
                            //Perdorimi i funksionit DeleteRsaKey per te fshire qelesat privat dhe public me madhesi 1024(sipas deshires)
                            D.DeletefromDB(text);
                            D.DeleteRsaKey(privateKeyfilePath, publicKeyfilePath, 1024);

                            //Trego qe u fshin qelsat
                            Console.WriteLine("Eshte larguar celesi privat " + "'keys//" + text + ".xml'");
                            Console.WriteLine("Eshte larguar celesi publik " + "'keys//" + text + ".pub.xml'");
                        }
                        else if (publicKeyExist)
                        {
                            D.DeletefromDB(text);
                            D.DeleteRsaKey(publicKeyfilePath, 1024);
                            Console.WriteLine("Eshte larguar celesi publik " + "'keys//" + text + ".pub.xml'");
                        }
                        else
                        {
                            Console.WriteLine("Celesi '" + args[1] + "' nuk ekziston.");
                        }
                    }
                    else
                    {
                        Console.WriteLine(
                            "Lejohen vetem Emra me shkonje te madhe apo te vogel, dhe numrat 0-9 dhe _ dhe .");
                        Environment.Exit(1);
                    }
                }
                /*-----args per export-key--------------*/
                else if (args[0].Equals("export-key"))
                {
                    string userKey = args[2];
                    if (args[1].Equals("public"))
                    {
                        try
                        {
                            if (args.Length == 3)
                            {
                                E.PublicKey(userKey);
                                Console.WriteLine();
                            }
                            else if (args.Length == 4)
                            {
                                string exportToPath = args[3];
                                E.PublicKey(userKey, exportToPath);
                                Console.WriteLine("Celesi publik u ruajt ne fajllin " + exportToPath);
                            }
                        }
                        catch
                        {
                            throw new Exception("Celesi publik " + args[2].ToString() + " nuk ekziston!");
                        }
                    }
                    else if (args[1].Equals("private"))
                    {
                        try
                        {
                            if (args.Length == 3)
                            {
                                E.PrivateKey(userKey);
                                Console.WriteLine();
                            }
                            else if (args.Length == 4)
                            {
                                string exportToPath = args[3];
                                E.PrivateKey(userKey, exportToPath);
                                Console.WriteLine("Celesi privat u ruajt ne fajllin " + exportToPath);
                            }
                        }
                        catch
                        {
                            throw new Exception("Celesi privat " + args[2].ToString() + " nuk ekziston!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Argument is not passed right! Make sure is Public or Private!");
                        Environment.Exit(1);
                    }
                }
                /*--------args per import key-----------*/
                else if (args[0].Equals("import-key"))
                {
                    string import = args[1];
                    string frompath = args[2];
                    if (Regex.IsMatch(import, "^[A-Za-z0-9_.]+$"))
                    {
                        try
                        {
                            I.Import(import, frompath);
                        }
                        catch
                        {
                            throw new Exception("Fajlli i dhene nuk eshte cels valid! Check the path right!");
                        }
                    }
                    else
                    {
                        Console.WriteLine(
                            "Lejohen vetem Emra me shkonje te madhe apo te vogel, dhe numrat 0-9 dhe _ dhe .");
                        Environment.Exit(1);
                    }
                }
                /*----Args per Encryption-----*/
                else if (args[0].Equals("write-message"))
                {
                    string userName = args[1];
                    string message = args[2];


                    if (args.Length == 3)
                    {
                        EM.Encrypt(userName, message);
                    }
                    else if (args.Length == 4)
                    {
                        object TokenorPath = args[3];
                        EM.Encrypt(userName, message, TokenorPath.ToString());
                    }
                    else if (args.Length == 5)
                    {
                        object TokenorPath = args[3];
                        string Path = args[4];
                        EM.Encrypt(userName, message, TokenorPath, Path);
                    }
                }
                /*-----Args per Decryption----*/
                else if (args[0].Equals("read-message"))
                {
                    try
                    {
                        string ciphertext = args[1];
                        DM.Decrypt(ciphertext);
                    }
                    catch (Exception exception)
                    {
                        if (exception is FormatException || exception is IndexOutOfRangeException)
                        {
                            throw new Exception("Mesazhi i dhene nuk paraqet cipher & sign ose path valid! ");
                        }

                        Console.WriteLine(exception.Message);
                    }
                }
                /*----Args per Login-----*/
                else if (args[0].Equals("login"))
                {
                    try
                    {
                        string username = args[1];
                        Console.Write("Jep passwordin: ");
                        string password = null;
                        while (true)
                        {
                            var key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.Enter)
                                break;
                            password += key.KeyChar;
                        }

                        Console.WriteLine();
                        T.Login(username, password);
                    }
                    catch (Exception error)
                    {
                        throw new Exception(error.Message);
                    }
                }
                /*----Args per status----*/
                else if (args[0].Equals("status"))
                {
                    try
                    {
                        String token = args[1];
                        S.Status(token);
                        S.PasstheValue();
                    }
                    catch
                    {
                        throw new Exception("Gabim: Vlera e dhene nuk eshte token valid.");
                    }
                }
                /*----Argument is wrong------*/
                else
                {
                    Console.WriteLine("First Argument is not valid! Make sure you passed it right!");
                    Console.WriteLine("Pass no arguments for DETAILS!");
                    Environment.Exit(1);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }

        /*--------------------------------------------------------------------------*/
    }
}