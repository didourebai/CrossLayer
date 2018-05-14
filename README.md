Project Status
To use this DLL you can refer to the sample as a Console App, this can be used in a Web App.
 var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());

            XmlConfigurator.Configure(logRepository, new FileInfo("App.config"));

            var logger = LogManager.GetLogger(typeof(Program));

            logger.Error("Hello World!");
If we want to use this in an ASP.NET Core 2.0, a web application, we need to add a log provider(LoggerProvider) that is an extension using ILoggerProvider.
This is an example:

public LoggerProvider : ILoggerProvider
{
   private readonly string _log4NetConfigFile;
      private readonly ConcurrentDictionary<string, Logger> _loggers =
        new ConcurrentDictionary<string, Logger>();
   
    public Log4NetProvider(string log4NetConfigFile)
    {
        _log4NetConfigFile = log4NetConfigFile;
    }
    public ILogger CreateLogger(string categoryName)
    {
        return _loggers.GetOrAdd(categoryName, CreateLoggerImplementation);
    }

    public void Dispose()
    {
        _loggers.Clear();
    }
    private Log4NetLogger CreateLoggerImplementation(string name)
    {
        return new Log4NetLogger(name, Parselog4NetConfigFile(_log4NetConfigFile));
    }

    private static XmlElement Parselog4NetConfigFile(string filename)
    {
        XmlDocument log4netConfig = new XmlDocument();
        log4netConfig.Load(File.OpenRead(filename));
        return log4netConfig["log4net"];
    }   
Finally we will add the extension of the LoggerFactory:			

public static class Log4netExtensions
{
    public static ILoggerFactory AddLog4Net(this ILoggerFactory factory, string log4NetConfigFile)
    {
        factory.AddProvider(new Log4NetProvider(log4NetConfigFile));
        return factory;
    }

    public static ILoggerFactory AddLog4Net(this ILoggerFactory factory)
    {
        factory.AddProvider(new Log4NetProvider("log4net.config"));
        return factory;
    }


And now, we can use it il our web application in this way:

  public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddLog4Net();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvcWithDefaultRoute();
        }




