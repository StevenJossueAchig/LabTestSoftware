namespace Laboratorio2_Achig.Models
{
    public class Calculator
    {
        // prop  +  tab para crear los getters y setters
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }

        public int Add()
        {
            return FirstNumber + SecondNumber;
        }
    }   
}
