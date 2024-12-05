namespace lab02_1
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Pupil pupil = new Pupil();
            ExcelentPupil pupil1 = new ExcelentPupil();
            GoodPupil pupil2 = new GoodPupil();
            BadPupil pupil3 = new BadPupil();
            ClassRoom classroom = new ClassRoom(pupil, pupil1, pupil2, pupil3);
            classroom.print();
        }
    }

    class ClassRoom
    {
        private Pupil[] classR;

        public ClassRoom(params Pupil[] pupils)
        {
            classR = pupils;
        }

        public void print()
        {
            foreach (Pupil p in classR)
            {
                p.Information();
                Console.WriteLine("");
            }
        }

    }

    class ExcelentPupil : Pupil
    {
        protected override void Study()
        {
            Console.WriteLine("Я учусь на отлично в школе");
        }

        protected override void Read()
        {
            Console.WriteLine("Я обожаю читать");
        }

        protected override void Write()
        {
            Console.WriteLine("Я очень красиво пишу");
        }

        protected override void Relax()
        {
            Console.WriteLine("Я мало отдыхаю");
        }
    }

    class GoodPupil : Pupil
    {
        protected override void Study()
        {
            Console.WriteLine("Я учусь на хорошо в школе");
        }

        protected override void Read()
        {
            Console.WriteLine("Я люблю читать");
        }

        protected override void Write()
        {
            Console.WriteLine("Я красиво пишу");
        }

        protected override void Relax()
        {
            Console.WriteLine("Я хорошо отдыхаю");
        }
    }

    class BadPupil : Pupil
    {
        protected override void Study()
        {
            Console.WriteLine("Я учусь на три в школе");
        }

        protected override void Read()
        {
            Console.WriteLine("Я не люблю читать");
        }

        protected override void Write()
        {
            Console.WriteLine("Я не красиво пишу");
        }

        protected override void Relax()
        {
            Console.WriteLine("Я много отдыхаю");
        }
    }

    class Pupil
    {
        public void Information()
        {
            Study();
            Read();
            Write();
            Relax();
        }

        protected virtual void Study()
        {
            Console.WriteLine("Я учусь в школе");
        }

        protected virtual void Read()
        {
            Console.WriteLine("Я люблю читать");
        }

        protected virtual void Write()
        {
            Console.WriteLine("Я красиво пишу");
        }

        protected virtual void Relax()
        {
            Console.WriteLine("Я мало отдыхаю");
        }
    }
}

