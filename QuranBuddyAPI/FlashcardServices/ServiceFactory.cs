using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace QuranBuddyAPI.FlashcardServices
{
    public class ServiceFactory : IServiceFactory
    {
        
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ServiceFactory> _logger;

        public Dictionary<string, Type> SERVICES { get; set; }

        public ServiceFactory(IServiceProvider serviceProvider, ILogger<ServiceFactory> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            LoadTypes();
        }

        //public ServiceFactory()
        //{
        //    LoadTypes();

        //}

        private Type GetTypeToCreate(string serviceType)
        {
            foreach (var svr in SERVICES)
            {
                if (svr.Key.Contains(serviceType, StringComparison.OrdinalIgnoreCase))
                {
                    return SERVICES[svr.Key];

                }

                

            }
            return typeof(DefaultFlashcardService);


        }

        public IFlashcardService GetFlashcardService(string serviceType)
        {
            Type t = GetTypeToCreate(serviceType);

            //return _serviceProvider.GetService(t) as IFlashcardService;

            //return Activator.CreateInstance(t) as IFlashcardService;

            _logger.LogInformation($"Attempting to resolve service of type: {t.Name}");

            try
            {
                var service = _serviceProvider.GetRequiredService(t) as IFlashcardService;
                if (service == null)
                {
                    _logger.LogError($"Service of type {t.Name} could not be resolved.");
                }
                return service;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while resolving service of type {t.Name}");
                throw;
            }
        }


        private void LoadTypes()
        {
            SERVICES = new Dictionary<string, Type>();

            Type[] typesInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in typesInThisAssembly)
            {
                if (type.GetInterface(typeof(IFlashcardService).ToString()) != null)
                {
                    SERVICES.Add(type.Name, type);
                }
            }


        }
    }
}
