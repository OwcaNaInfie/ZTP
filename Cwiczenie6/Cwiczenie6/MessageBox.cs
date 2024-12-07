namespace Cwiczenie6
{
    public class MessageBox
    {
        private List<Message> messages = new List<Message>();
        private int nextId = 1;

        public void AddMessage(Message message)
        {
            message.Id = nextId++;
            messages.Add(message);
        }

        public Message GetMessageById(int id)
        {
            return messages.Find(m => m.Id == id);
        }

        public void DisplayAllMessageTitles()
        {
            Console.WriteLine("\nLista wiadomości:");
            if (messages.Count == 0)
            {
                Console.WriteLine("Brak wiadomości w skrzynce.");
            }
            else
            {
                foreach (var message in messages)
                {
                    Console.WriteLine($"ID: {message.Id} - {message.Title}");
                }
            }
        }
    }
    }
