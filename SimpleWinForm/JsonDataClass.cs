

namespace SimpleWinForm
{
   internal class JsonDataClass
    {
       
       public string FullName { get; set; }

       public string CityName { get; set; }

       public string PhoneNumber { get; set; }

       public string EmailAddress { get; set; }

    }

   internal class RawJsonData
   {

       public string FullName { get; set; }
       public string CityName { get; set; }
       public string PhoneNumber { get; set; }
       public string EmailAddress { get; set; }
       public int Id { get; set; }

    }

   internal class RawJsonStepData
   {

       public string FullName { get; set; }
       public string CityName { get; set; }
       public string PhoneNumber { get; set; }
       public string EmailAddress { get; set; }
       public bool HasErrors { get; set; }
       public int ErrorCount { get; set; }
       public string PhoneError { get; set; }
       public string EmailError { get; set; }
       public string DisplayOutput { get; set; }


   }

   internal class RawJsonStepDisplay
   {

        public string DisplayName { get; set; }
        public string DisplayOutput { get; set; }
   }




}
