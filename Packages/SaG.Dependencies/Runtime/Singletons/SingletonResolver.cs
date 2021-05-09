namespace SaG.Dependencies.Singletons
{
    public class SingletonResolver
    {
        public static ISingletonResolver Instance { get; set; } = new FindObjectOfTypeSingletonResolver();
        
        public static ISingletonResolver Default { get; } = new FindObjectOfTypeSingletonResolver();
    }
}