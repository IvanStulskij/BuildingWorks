using System.Windows;

namespace BuildingWorks.Models.BusinessLogic.Messages
{
    public class MessageBoxBehavior : IMessageBehavior
    {
        public void WriteMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
