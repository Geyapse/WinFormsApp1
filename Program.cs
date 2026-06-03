using WinFormsApp1.ConsumerClient;

namespace WinFormsApp1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var sendForm = new ProducerForm();

            var receiveForm =
                new ConsumerClient.ConsumerForm();

            receiveForm.Show();

            Application.Run(sendForm);
        }
    }
}