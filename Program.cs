using ConsumerClient;

namespace WinFormsApp1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var sendForm = new Form1();

            var receiveForm =
                new ConsumerClient.Form1();

            receiveForm.Show();

            Application.Run(sendForm);
        }
    }
}