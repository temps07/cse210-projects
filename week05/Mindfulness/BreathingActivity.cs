public class BreathingActivity : Activity
{
    private int _count;
    public BreathingActivity() : base(
        "Breathing", 
        "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
        _count = 0;
    }
    public override void Run()
    {
        DisplayStartingMessage();            
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);    
        bool breatheIn = true;    
        while (DateTime.Now < endTime)
        {
            if (breatheIn)
            {
                Console.WriteLine();
                Console.Write("Breathe in... ");
                ShowCountDown(4);
                _count++;
            }
            else
            {
                Console.WriteLine();
                Console.Write("Breathe out... ");
                ShowCountDown(6);
                _count++;
            }
            breatheIn = !breatheIn;
        }            
        DisplayEndingMessage();
    }
}