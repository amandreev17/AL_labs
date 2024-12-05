namespace lab02_3
{
    public class Program3
    {
        public static void Main(string[] args)
        {
            DocumentWorker document = new DocumentWorker();
            document.OpenDocument();
            Console.WriteLine("Введите пароль или иначе нажмите \"0\":");
            string? password = Console.ReadLine();
            if (password == "0")
            {
                document.SafeDocument();
                document.EditDocumet();
            }
            else if (password == "1234")
            {
                document = new ProDocumentWorker();
                document.EditDocumet();
            }
            else if (password == "4321")
            {
                document = new ExpertDocumentWorker();
                document.SafeDocument();
            }
        }
    }

    class DocumentWorker
    {
        public virtual void OpenDocument()
        {
            Console.WriteLine("Документ открыт");
        }

        public virtual void EditDocumet()
        {
            Console.WriteLine("Редактирование документа доступно в версии Pro");
        }

        public virtual void SafeDocument()
        {
            Console.WriteLine("Сохранение документа доступно в версии Pro");
        }
    }

    class ProDocumentWorker : DocumentWorker
    {
        public override void EditDocumet()
        {
            Console.WriteLine("Документ отредактирован");
        }

        public override void SafeDocument()
        {
            Console.WriteLine("Документ сохранен в старом формате, сохранение в остальных форматах доступно в версии Expert");
        }
    }

    class ExpertDocumentWorker : DocumentWorker
    {
        public override void SafeDocument()
        {
            Console.WriteLine("Документ сохранен в новом формате");
        }
    }
}

