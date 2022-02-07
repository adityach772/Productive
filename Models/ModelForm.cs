using Microsoft.EntityFrameworkCore;
namespace Productive.Models
{
    public class ModelForm
    { 
        public int id { get; set; }
        public string Selection { get; set; }
        public string UNAME { get; set; }

        public int StartHour { get; set; }
        public string SMeridiem { get; set; }

        public int EndHour { get; set; }
        public string EMeridiem { get; set; }

    }

    public class samplemodel
    {
        public string UNAME { get; set; }
    }
   
}
