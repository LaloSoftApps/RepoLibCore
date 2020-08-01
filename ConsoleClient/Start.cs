using System;
using System.Data;
using Microsoft.Extensions.Configuration;


using Libs;

namespace ConsoleClient
{
    class Start
    {
        static void Main()
        {
            
            //--------------- Ejemplo de Config ---------------
            Config config = new Config();
            var AppConfig = config.Read();
            Console.WriteLine($"Version de la App: {AppConfig["App_Version"]}");
            Console.WriteLine($"Desarrollado por : {AppConfig["App_Developer"]}" );

            /*
            //---------------  Ejemplo ZIP ---------------
            Compress Zipear = new Compress();
            Zipear.CompressFile = @"C:\Users\root\Desktop\Mycompress.zip";
            Zipear.FileZip(@"D:\Carpeta1\data.txt");
            Zipear.FileZip(@"C:\Carpeta889\otracosa.txt");
            
            //--------------- Ejemplo UNZIP ---------------
            Compress Unzipear = new Compress();
            Unzipear.CompressFile = @"C:\Users\root\Desktop\Mycompress.zip";
            Unzipear.FileUnzip(@"C:\Users\root\Desktop\Test");

            //--------------- Ejemplo LIST ---------------
            Compress Listar = new Compress();
            Listar.CompressFile = @"C:\Users\root\Desktop\Mycompress.zip";
            foreach (string item in Listar.FilesList())
            {
                Console.WriteLine(item);
            }
            */

            /*
            //--------------- Ejemplo Email ---------------
            Config config = new Config();
            var AppConfig = config.Read();

            EMail correo = new EMail();

            correo.UsrLogin = AppConfig["EMail_UsrLogin"];
            correo.UsrPwd = AppConfig["EMail_UsrPwd"];
            correo.FromAddress = AppConfig["EMail_FromAddress"];
            correo.FromDescription = AppConfig["EMail_FromDescription"];
            correo.Smtp = AppConfig["EMail_Smtp"];
            correo.Port = Convert.ToInt16(AppConfig["EMail_Port"]);
            correo.Ssl = Convert.ToBoolean(AppConfig["EMail_Ssl"]);

            correo.Html = true;
            correo.To = "a_alguien@gmail.com";
            correo.MailSubject = "aca va el asunto";
            correo.MailBody = "" +
                "Este es el cuerpo del mensaje en <b>HTML</b><br />" +
                "Bye!<br /><br />" +
                "<a href='mailto:mi_cta@gmail.com'>Gonzalo Santilli</a>.-";

            try
            {
                correo.Send();
                Console.WriteLine("[Info] El EMail fue Enviado Correctamente!");
            } catch (Exception ex)
            {
                Console.WriteLine($"[Error] {ex.Message}");
            }
            */
        }
    }
}
