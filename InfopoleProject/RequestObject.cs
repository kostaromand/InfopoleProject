namespace InfopoleProject
{
    //Объект, описывающий стуктуру запроса
    public class RequestObject
    {
        //порядковые номера полей в источнике данных
        static int request = 3; 
        static int group = 5;
        static int phraseFreq = 11;
        static int accFreq = 12;
        
        public string Group { get; set; } //группа
        public string Request { get; set; } //запрос
        public int PhraseFrequency { get; set; } //фразовая частота
        public int AccurateFrequency { get; set; } //точная частота
        
        public RequestObject(string[] fields)
        {
            this.Group = fields[group];
            this.Request = fields[request];
            this.PhraseFrequency = int.Parse(fields[phraseFreq]);
            this.AccurateFrequency = int.Parse(fields[accFreq]);
        }
    }
}
