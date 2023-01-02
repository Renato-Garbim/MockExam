namespace RequestLog.Entities
{
    public class HeroLog
    {                
        public int Id { get; private set; }
        public string RequestBody { get; private set; }
        public string Operation { get; private set; }
        public DateTime DateInsert { get; private set; }
        public DateTime DateUpdate { get; private set; }

        public HeroLog(int id, string requestBody, string operation, DateTime dateInsert, DateTime dateUpdate)
        {
            Id = id;
            RequestBody = requestBody;
            Operation = operation;
            DateInsert = dateInsert;
            DateUpdate = dateUpdate;
        }
    }
}