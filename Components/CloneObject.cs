namespace HorizonPollyC.Components
{
    public class CloneObject
    {
        public static T Clone<T>(T input)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(input);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }
    }
}
