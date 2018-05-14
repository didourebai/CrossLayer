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
     XmlConfigurator.Configure(logRepository, new FileInfo("App.config"));67            var logger = LogManager.GetLogger(typeof(Program));89            logger.Error("Hello World!");10If we want to use this in an ASP.NET Core 2.0, a web application, we need to add a log provider(LoggerProvider) that is an extension using ILoggerProvider.11This is an example:1213public LoggerProvider : ILoggerProvider14{15   private readonly string _log4NetConfigFile;16      private readonly ConcurrentDictionary<string, Logger> _loggers =17        new ConcurrentDictionary<string, Logger>();18   19    public Log4NetProvider(string log4NetConfigFile)20    {21        _log4NetConfigFile = log4NetConfigFile;22    }23    public ILogger CreateLogger(string categoryName)24    {25        return _loggers.GetOrAdd(categoryName, CreateLoggerImplementation);26    }2728    public void Dispose()29    {30        _loggers.Clear();31    }32    private Log4NetLogger CreateLoggerImplementation(string name)33    {34        return new Log4NetLogger(name, Parselog4NetConfigFile(_log4NetConfigFile));35    }3637    private static XmlElement Parselog4NetConfigFile(string filename)38    {39        XmlDocument log4netConfig = new XmlDocument();40        log4netConfig.Load(File.OpenRead(filename));41        return log4netConfig["log4net"];42    }   43    Finally we will add the extension of the LoggerFactory;44    







