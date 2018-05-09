Project Status
To use this DLL you can refer to the sample as a Console App, this can be used in a Web App.
 var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());

            XmlConfigurator.Configure(logRepository, new FileInfo("App.config"));

            var logger = LogManager.GetLogger(typeof(Program));

            logger.Error("Hello World!");
