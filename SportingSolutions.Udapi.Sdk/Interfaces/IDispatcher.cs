﻿//Copyright 2012 Spin Services Limited

//Licensed under the Apache License, Version 2.0 (the "License");
//you may not use this file except in compliance with the License.
//You may obtain a copy of the License at

//    http://www.apache.org/licenses/LICENSE-2.0

//Unless required by applicable law or agreed to in writing, software
//distributed under the License is distributed on an "AS IS" BASIS,
//WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//See the License for the specific language governing permissions and
//limitations under the License.


using System;

namespace SportingSolutions.Udapi.Sdk.Interfaces
{
    internal interface IDispatcher : IDisposable
    {
        bool HasConsumer(IConsumer consumer);

        void AddConsumer(IConsumer consumer);

        void RemoveConsumer(IConsumer consumer);

        void RemoveAll();

        bool DispatchMessage(string consumerId, string message);

        int ConsumersCount { get; }

        /// <summary>
        ///     This method make sure that the IDispatcher object
        ///     can be safely used.
        /// 
        ///     The main purpose of this method is to ensure the order
        ///     of the updates for a consumer.
        /// 
        ///     As an example, if the IDispatcher is busy removing a 
        ///     consumer, that consumer can't be added until the
        ///     operation is completed.
        /// 
        ///     Returns false if the IDispatcher is not ready.
        /// </summary>
        bool EnsureAvailability();
    }
}