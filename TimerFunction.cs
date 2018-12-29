using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Drawing;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace blightfunctions
{
  public static class TimerFunction
  {
    

    // public static void Run([TimerTrigger("0 30 * * * *")]TimerInfo myTimer, ILogger log)
    [FunctionName("TimerFunction")]
    public static void Run([TimerTrigger("0 0 4,14 * * *")]TimerInfo myTimer, ILogger log)
    {
      log.LogInformation("Running!");
      string username = Environment.GetEnvironmentVariable("username"); // todo: urlEncode the username;
      string password = Environment.GetEnvironmentVariable("password");
      Blight blight = new Blight(username, password, log);
            
      string game = Environment.GetEnvironmentVariable("gameID");
      var gameState = blight.togglePause(game);
      if (gameState)
      {
        log.LogInformation("Success!");
      }
      else{
        log.LogInformation("Failure!");
      }
    }
  }
}