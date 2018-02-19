﻿using System;
using System.Collections.Generic;
using Akka.Actor;
using log4net;
using SportingSolutions.Udapi.Sdk.Events;
using SportingSolutions.Udapi.Sdk.Model.Message;
using SdkErrorMessage = SportingSolutions.Udapi.Sdk.Events.SdkErrorMessage;

namespace SportingSolutions.Udapi.Sdk.Actors
{
    public class ErrorControllerActor : ReceiveActor
    {
        private IActorRef subscriber;

        private readonly ILog _logger = LogManager.GetLogger(typeof(ErrorControllerActor));

        public const string ActorName = "ErrorControllerActor";

        public ErrorControllerActor()
        {
            Receive<CriticalActorRestartedMessage>(message => OnActorRestarted(message, true));
            Receive<PathMessage>
            
            (message =>
            {
                _logger.Info($"Registering subscriber path={Sender}");
                subscriber = Sender;
                subscriber.Tell(new PathMessage());
                
            });
        }

        //public 

        public void OnActorRestarted(CriticalActorRestartedMessage message, bool isCritical)
        {
            subscriber.Tell(new SdkErrorMessage($"Actor restarted {message.ActorName}", isCritical) );
        }
    }
}
