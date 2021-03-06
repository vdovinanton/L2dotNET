﻿using System;
using log4net;
using L2dotNET.Services.Contracts;

namespace L2dotNET
{
    public class PreReqValidation : IInitialisable
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(PreReqValidation));

        private readonly ICheckService _checkService;
        public bool Initialised { get; private set; }

        public PreReqValidation(ICheckService checkService)
        {
            _checkService = checkService;
        }

        public void Initialise()
        {
            if (Initialised)
                return;

            if (_checkService.PreCheckRepository())
            {
                Initialised = true;
                return;
            }

            Log.Warn("Some checks have failed. Please correct the errors and try again.");
            Log.Info("Press ENTER to exit...");
            Console.Read();
            Environment.Exit(0);
        }
    }
}