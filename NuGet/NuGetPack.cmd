SET NUGET=..\src\.nuget\nuget
%NUGET% pack NServiceKit.Logging.Elmah\NServiceKit.logging.elmah.nuspec -symbols
%NUGET% pack NServiceKit.Logging.EntLib5\NServiceKit.logging.entlib5.nuspec -symbols
%NUGET% pack NServiceKit.Logging.EventLog\NServiceKit.logging.eventlog.nuspec -symbols
%NUGET% pack NServiceKit.Logging.Log4Net\NServiceKit.logging.log4net.nuspec -symbols
%NUGET% pack NServiceKit.Logging.Log4Netv129\NServiceKit.logging.log4netv129.nuspec -symbols
%NUGET% pack NServiceKit.Logging.Log4Netv1210\NServiceKit.logging.log4netv1210.nuspec -symbols
%NUGET% pack NServiceKit.Logging.NLog\NServiceKit.logging.nlog.nuspec -symbols

